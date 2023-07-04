using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Impl
{
    /// <summary>
    /// The <c>HealerNPCImpl</c> class is an implementation of the <see cref="HealerNPC"/> interface.
    /// It extends the <see cref="AbstractNPCImpl"/> class and represents an NPC that can heal allies.
    /// </summary>
    public class HealerNPCImpl : AbstractNPCImpl, Api.HealerNPC//, KillableEntity non di mia competenza
    {
        private readonly int healAmount;
        //private KillObserver killObserver;

        /// <summary>
        /// Constructs a new instance of the HealerNPCImpl class with the specified name, position, dimensions, and heal amount.
        /// </summary>
        /// <param name="name">The name of the healer NPC.</param>
        /// <param name="x">The X coordinate of the healer NPC's position.</param>
        /// <param name="y">The Y coordinate of the healer NPC's position.</param>
        /// <param name="height">The height of the healer NPC.</param>
        /// <param name="width">The width of the healer NPC.</param>
        /// <param name="healAmount">The amount of healing provided by the NPC.</param>
        public HealerNPCImpl(string name, int x, int y, int height, int width, int healAmount)
            : base(name, x, y, height, width)
        {
            if (healAmount < 0)
            {
                throw new ArgumentException("Heal amount cannot be negative", nameof(healAmount));
            }

            this.healAmount = healAmount;
            //this.killObserver = null;
        }

        /// <summary>
        /// Gets the amount of healing provided by the NPC.
        /// </summary>
        /// <returns>The heal amount.</returns>
        public int GetHealAmount()
        {
            return healAmount;
        }

        /*
         * Implementazione di classi o interfaccie non di mia competenza
         * 
         
        /// <summary>
        /// Handles the interaction with the NPC.
        /// </summary>
        /// <param name="interactable">The spatial entity triggering the interaction.</param>
        public void OnInteraction(SpatialEntity interactable)
        {
            if (!(interactable is IParty party))
            {
                throw new ArgumentException("Interactable must be an instance of IParty");
            }

            foreach (Ally ally in party.GetMembers())
            {
                if (ally.Health + GetHealAmount() <= ally.MaxHealth)
                {
                    ally.Health += GetHealAmount();
                }
                else
                {
                    ally.Health = ally.MaxHealth;
                }
            }

            killObserver?.OnKill(this);
        }

        /// <summary>
        /// Sets the kill observer for the NPC.
        /// </summary>
        /// <param name="killObserver">The kill observer.</param>
        public void SetKillObserver(KillObserver killObserver)
        {
            this.killObserver = killObserver;
        }

        */
    }
}
  