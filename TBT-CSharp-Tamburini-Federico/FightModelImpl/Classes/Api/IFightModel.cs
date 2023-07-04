using Dummy.Impl;

namespace Classes.Api
{
    public interface IFightModel
    {
        Ally GetCurrentAlly();
        List<Ally> GetAllies();
        List<Enemy> GetEnemies();
        int GetSelectedTargetIndex();
        void SelectPreviousTarget();
        void SelectNextTarget();
        void PerformSelectedAction();
        bool IsUsingSkill();
        void SelectAction(bool b, bool c, bool d);
        bool IsUsingPotion();
        bool IsUsingAntidote();
        void InitializeParty(Party party);
    }

}