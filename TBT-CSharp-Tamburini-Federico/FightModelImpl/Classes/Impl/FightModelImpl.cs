using Classes.Api;
using Dummy.Api;
using Dummy.Impl;

namespace Classes.Impl
{
    public sealed class FightModelImpl : IFightModel
    {

        #region variabili
        private const double BASECRITCHANCE = 0.05;
        private const double ENEMYPOISONCHANCE = 0.03;
        private const double POISONDAMAGE = 0.05;
        private const double BOOSTEDCRITCHANCE = 0.25;
        private const int ENEMYLIMIT = 5;
        private static readonly Random RANDOM = new Random();

        private Dictionary<Item, double> drops;
        private List<Ally> allies = default!;
        private List<Enemy> enemies;
        private List<Character> turnOrder = default!;
        private Ally CurrentAlly = default!;
        private Character currentCharacter = default!;
        private Party Party = default!;
        private int selectedTargetIndex;
        private bool usingSkill;
        private bool usingPotion;
        private bool usingAntidote;

        #endregion
        public FightModelImpl(int averageEnemyStat, Dictionary<Item, double> drops)
        {
            if (averageEnemyStat < 1 || drops == null)
            {
                throw new ArgumentException("è stato passato un argomento non lecito alla creazione di FightModelImpl");
            }

            enemies = new List<Enemy>();
            for (int c = 1; c < ENEMYLIMIT; c++)
            {
                enemies.Add(CharacterFactory.CreateRandomEnemy($"Enemy {c}", averageEnemyStat));
            }

            selectedTargetIndex = 0;
            usingSkill = false;
            usingPotion = false;
            usingAntidote = false;
            this.drops = new Dictionary<Item, double>(drops);
        }

        public FightModelImpl(Party party, int averageEnemyStat, Dictionary<Item, double> drops)
        {
            if (party == null || averageEnemyStat < 1 || drops == null)
            {
                throw new ArgumentException("è stato passato un argomento non lecito alla creazione di FightModelImpl");
            }

            this.enemies = new List<Enemy>();
            for (int c = 1; c < ENEMYLIMIT; c++)
            {
                this.enemies.Add(CharacterFactory.CreateRandomEnemy($"Enemy {c}", averageEnemyStat));
            }

            this.selectedTargetIndex = 0;
            this.usingSkill = false;
            this.usingPotion = false;
            this.usingAntidote = false;
            this.drops = new Dictionary<Item, double>(drops);

            InitializeParty(party);
        }

        public void InitializeParty(Party party)
        {
            if (party == null)
            {
                throw new ArgumentException("è stato passato un argomento non lecito a initializeParty");
            }

            this.Party = party;

            if (this.Party.Members == null)
            {
                throw new InvalidOperationException("La lista dei membri del party è null");
            }

            List<Ally> tmpAllies = new List<Ally>(party.Members);
            allies = new List<Ally>();

            int limit = Math.Min(4, tmpAllies.Count);

            for (int i = 0; i < limit; i++)
            {
                if (tmpAllies[i] != null)
                {
                    // per curare gli alleati quando inizia un fight
                    allies.Add(party.Members[i]);
                }
            }

            if (limit < 4)
            {
                for (int i = limit; i < 4; i++)
                {
                    allies.Add(CharacterFactory.CreateAlly("", 0, 0, 0));
                }
            }

            turnOrder = new List<Character>();
            turnOrder.AddRange(allies);
            turnOrder.AddRange(enemies);

            // ordina il turno in base alla speed, in modo decrescente
            turnOrder = turnOrder.OrderByDescending(character => character.Speed).ToList();

            currentCharacter = turnOrder[0];

            if (currentCharacter is Ally)
            {
                CurrentAlly = (Ally)currentCharacter;
            }
            else
            {
                EnemyAttack();
            }
        }

        public List<Ally> GetAllies()
        {
            return new List<Ally>(allies);
        }

        public List<Enemy> GetEnemies()
        {
            return new List<Enemy>(enemies);
        }

        public Ally GetCurrentAlly()
        {
            Ally returnAlly = new Ally(
                CurrentAlly.Name,
                CurrentAlly.MaxHP,
                CurrentAlly.Attack,
                CurrentAlly.Speed,
                new List<Skill>(CurrentAlly.GetSkills())
            );

            foreach (Status s in CurrentAlly.Status)
            {
                returnAlly.AddStatus(s);
            }

            int armor = CurrentAlly.GetArmor() ?? 0;
            returnAlly.EquipeArmor(armor);

            int weapon = CurrentAlly.GetArmor() ?? 0;
            returnAlly.EquipeWeapon(weapon);

            //soluzione per equipaggiamento arma e armatura qui: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/nullable-warnings?f1url=%3FappId%3Droslyn%26k%3Dk(CS8629)#possible-null-assigned-to-a-nonnullable-reference

            return returnAlly;
        }

        public Ally GetSelectedAlly()
        {
            return allies[selectedTargetIndex];
        }

        public Enemy GetSelectedEnemy()
        {
            return enemies[selectedTargetIndex];
        }

        public int GetSelectedTargetIndex()
        {
            return selectedTargetIndex;
        }

        public bool IsUsingSkill()
        {
            return usingSkill;
        }

        public bool IsUsingPotion()
        {
            return usingPotion;
        }

        public bool IsUsingAntidote()
        {
            return usingAntidote;
        }

        public void SelectPreviousTarget()
        {
            int previousTarget = Math.Max(0, selectedTargetIndex - 1);
            if (IsUsingSkill() || (!IsUsingAntidote() && !IsUsingPotion() && !IsUsingSkill())
                && enemies[previousTarget].MaxHP != 0)
            {
                selectedTargetIndex = previousTarget;
            }
            else if ((IsUsingAntidote() || IsUsingPotion()) && allies[previousTarget].MaxHP != 0)
            {
                selectedTargetIndex = previousTarget;
            }
        }

        public void SelectNextTarget()
        {
            int nextTarget = Math.Min(enemies.Count - 1, selectedTargetIndex + 1);
            if (IsUsingSkill() || (!IsUsingAntidote() && !IsUsingPotion() && !IsUsingSkill())
                && enemies[nextTarget].MaxHP != 0)
            {
                selectedTargetIndex = nextTarget;
            }
            else if ((IsUsingAntidote() || IsUsingPotion()) && allies[nextTarget].MaxHP != 0)
            {
                selectedTargetIndex = nextTarget;
            }
        }

        public void SelectAction(bool changeUsingSkillState, bool changeUsingPotionState, bool changeUsingAntidoteState)
        {
            selectedTargetIndex = 0;
            usingSkill = changeUsingSkillState;
            usingPotion = changeUsingPotionState;
            usingAntidote = changeUsingAntidoteState;
        }

        public void PerformSelectedAction()
        {
            if (CurrentAlly.GetSkills() == null)
            {
                throw new InvalidOperationException("L'alleato corrente non ha la lista di skills istanziata");
            }

            Character character = (Character)this.CurrentAlly;
            Character selectedAlly = (Character)this.GetSelectedAlly();
            Character target = (Character)this.GetSelectedEnemy();

            if (usingSkill && CurrentAlly.GetSkills().Count != 0)
            {
                if (CurrentAlly.GetSkills()[0] == null)
                {
                    throw new InvalidOperationException("La prima skill dell'alleato corrente non è istanziata");
                }

                if (target.HP != 0)
                {
                    Skill skill = CurrentAlly.GetSkills()[0];
                    if (skill.RemainingCooldown == 0)
                    {
                        double damage = (character.Attack + character.GetWeaponAttack()) * skill.AttackMultiplier;
                        double critProb = RANDOM.NextDouble();
                        if (critProb <= FightModelImpl.BASECRITCHANCE
                                || skill.IncProbCritical && critProb <= FightModelImpl.BOOSTEDCRITCHANCE)
                        {
                            damage *= 2.0;
                            // Console.WriteLine("Critical Hit!");
                        }
                        target.TakeDamage((int)damage);
                        if (skill.PossibleStatus.HasValue && skill.PossibleStatus.Value == Status.POISONED)
                        {
                            target.AddStatus(Status.POISONED);
                        }
                        skill.ResetCooldown();
                        usingSkill = false;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else if (usingSkill)
            {
                return;
            }
            else if (usingPotion)
            {
                if (selectedAlly.MaxHP == selectedAlly.HP)
                {
                    return;
                }

                if (Party.Inventory == null)
                {
                    throw new InvalidOperationException("L'inventario del party non è istanziato");
                }

                List<Potion> potions = new List<Potion>();
                foreach (var item in Party.Inventory.GetItems().Keys)
                {
                    if (item is Potion potion && item.Value > 0)
                    {
                        potions.Add(potion);
                    }
                }

                if (potions.Count == 0)
                {
                    return;
                }

                int missingHealth = selectedAlly.MaxHP - selectedAlly.HP;
                Potion? currentPotion = null;
                foreach (var p in potions)
                {
                    if (currentPotion == null)
                    {
                        currentPotion = p;
                    }
                    else if (currentPotion.HealPower > p.HealPower && p.HealPower > missingHealth && currentPotion.HealPower > missingHealth)
                    {
                        currentPotion = p;
                    }
                    else if (p.HealPower < missingHealth && currentPotion.HealPower > missingHealth)
                    {
                        currentPotion = p;
                    }
                    else if (p.HealPower < missingHealth && currentPotion.HealPower < missingHealth && currentPotion.HealPower < p.HealPower)
                    {
                        currentPotion = p;
                    }
                }

                if (currentPotion == null)
                {
                    return;
                }

                int healAmount = selectedAlly.HP + currentPotion.HealPower;
                int scartoHeal = healAmount - selectedAlly.MaxHP;
                if (scartoHeal > 0)
                {
                    healAmount -= scartoHeal;
                }
                selectedAlly.SetHealth(healAmount);

                Party.RemoveItemFromInventory(currentPotion);

                usingPotion = false;
            }
            else if (usingAntidote)
            {
                Antidote? antidote = null;
                foreach (var item in Party.Inventory.GetItems().Keys)
                {
                    if (item is Antidote && item.Value > 0)
                    {
                        antidote = (Antidote)item;
                    }
                }

                if (antidote == null || !selectedAlly.Status.Contains(Status.POISONED))
                {
                    return;
                }

                selectedAlly.RemoveStatus(Status.POISONED);
                Party.RemoveItemFromInventory(antidote);
                usingAntidote = false;
            }
            else if (target.HP != 0)
            {
                double damage = character.Attack + character.GetWeaponAttack();
                if (RANDOM.NextDouble() <= FightModelImpl.BASECRITCHANCE)
                {
                    damage *= 2.0;
                    // Console.WriteLine("Critical Hit!");
                }
                target.TakeDamage((int)damage);
            }
            else if (target.HP == 0)
            {
                // Console.WriteLine("Stai attaccando un nemico con 0 hp");
                return;
            }
            else
            {
                // Console.WriteLine("???");
                return;
            }

            if (!CheckBattleEnd())
            {
                AdvanceTurn();
            }
        }

        private void DecreaseCooldowns()
        {
            foreach (Ally ally in allies)
            {
                if (ally == null)
                {
                    throw new InvalidOperationException("C'è un alleato non istanziato");
                }

                if (ally.GetSkills() == null)
                {
                    throw new InvalidOperationException("La lista di skills di un alleato non è istanziata");
                }

                if (ally.GetSkills().Count >= 1)
                {
                    if (ally.GetSkills()[0] == null)
                    {
                        throw new InvalidOperationException("La prima skill di un alleato non è istanziata");
                    }

                    ally.GetSkills()[0].DecreaseCooldown();
                }
            }
        }

        private void ApplyPoisonDamage()
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy == null)
                {
                    throw new InvalidOperationException("C'è un nemico non istanziato");
                }

                if (enemy.GetStatuses() == null)
                {
                    throw new InvalidOperationException("La lista di status di un nemico non è istanziata");
                }

                if (enemy.GetStatuses().Contains(Status.POISONED))
                {
                    double poisonDamage = enemy.MaxHP * FightModelImpl.POISONDAMAGE + 1;
                    enemy.TakeDamage((int)poisonDamage);
                }
            }

            foreach (Ally ally in allies)
            {
                if (ally == null)
                {
                    throw new InvalidOperationException("C'è un alleato non istanziato");
                }

                if (ally.Status == null)
                {
                    throw new InvalidOperationException("La lista di status di un alleato non è istanziata");
                }

                if (ally.Status.Contains(Status.POISONED))
                {
                    double poisonDamage = ally.MaxHP * FightModelImpl.POISONDAMAGE + 1;
                    ally.TakeDamage((int)poisonDamage);
                }
            }
        }

        public void EnemyAttack()
        {
            if (CheckBattleEnd())
            {
                return;
            }

            Enemy currentEnemy = (Enemy)this.currentCharacter;
            int currentTarget = RANDOM.Next(0, 4);

            while (this.allies[currentTarget].HP == 0)
            {
                currentTarget = RANDOM.Next(0, 4);
            }

            double damage = currentEnemy.Attack;

            if (RANDOM.NextDouble() <= FightModelImpl.BASECRITCHANCE)
            {
                damage *= 2.0;
                // Console.WriteLine("Critical Hit!");
            }

            this.allies[currentTarget].TakeDamage(Math.Max(((int)damage) - this.allies[currentTarget].GetArmorDefence(), 0));

            if (RANDOM.NextDouble() <= FightModelImpl.ENEMYPOISONCHANCE)
            {
                this.allies[currentTarget].AddStatus(Status.POISONED);
                // Console.WriteLine(this.allies[currentTarget].GetName() + " è stato avvelenato!");
            }

            if (!CheckBattleEnd())
            {
                AdvanceTurn();
            }
        }

        public void AdvanceTurn()
        {
            if (CheckBattleEnd())
            {
                return;
            }

            int currentIndex = turnOrder.IndexOf(this.currentCharacter);
            int nextIndex = (currentIndex + 1) % this.turnOrder.Count;

            while (this.turnOrder[nextIndex].HP == 0)
            {
                nextIndex++;
                nextIndex = nextIndex % this.turnOrder.Count;
            }

            this.currentCharacter = this.turnOrder[nextIndex];

            if ((nextIndex) % this.turnOrder.Count == 0)
            {
                DecreaseCooldowns();
                ApplyPoisonDamage();
                // Console.WriteLine("cooldown skill diminuito e danno da veleno applicato");

                if (CheckBattleEnd())
                {
                    return;
                }
            }

            if (this.currentCharacter is Ally)
            {
                this.CurrentAlly = (Ally)currentCharacter;
            }
            else
            {
                EnemyAttack();
            }
        }

        private bool CheckBattleEnd()
        {
            bool allAlliesDefeated = true;

            foreach (Ally ally in allies)
            {
                if (ally == null)
                {
                    throw new InvalidOperationException("C'è un alleato non istanziato");
                }

                if (ally.HP > 0)
                {
                    allAlliesDefeated = false;
                    break;
                }
            }

            bool allEnemiesDefeated = true;

            foreach (Enemy enemy in enemies)
            {
                if (enemy == null)
                {
                    throw new InvalidOperationException("C'è un nemico non istanziato");
                }

                if (enemy.HP > 0)
                {
                    allEnemiesDefeated = false;
                    break;
                }
            }

            if (allAlliesDefeated)
            {
                // Console.WriteLine("Enemies win!");
                this.Party.Members = this.allies;
            }
            else if (allEnemiesDefeated)
            {
                this.Party.Members = this.allies;
                // Console.WriteLine("Allies win!");

                foreach (KeyValuePair<Item, double> e in this.drops)
                {
                    if (RANDOM.NextDouble() <= e.Value)
                    {
                        this.Party.AddItemToInventory(e.Key);
                        // Console.WriteLine("Hai droppato " + e.Key.Tostring());
                    }
                }

                foreach (Enemy e in this.enemies)
                {
                    this.Party.AddCash(e.MaxHP);
                }

            }

            return allAlliesDefeated || allEnemiesDefeated;
        }


    }
}