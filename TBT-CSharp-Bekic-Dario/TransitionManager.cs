using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBT_CSharp_Bekic_Dario.Other;

namespace TBT_CSharp_Bekic_Dario
{
    public class TransitionManager : ITransitionManager
    {

        private ModelState? currentModelState;
        private GameState currentGameState;
        private Boolean stateChanged = false;
        private IParty party;

        public TransitionManager(IParty party)
        {
            this.party = party;
        }

        public ModelState GetCurrentModelState()
        {
            if(currentModelState == null) {
                throw new InvalidOperationException("ModelState has not been set.");
            }
            return currentModelState;
        }

        public GameState GetState()
        {
            return currentGameState;
        }

        public bool HasStateChanged()
        {
            var x = false;
            if (this.stateChanged)
            {
                x = true;
                this.stateChanged = false;
            }
            return x;
        }

        public void Init()
        {
            if (this.party is IStateTrigger stateTrigger){
                stateTrigger.SetStateObserver(this);
            }
        }

        public void OnEnding(string message)
        {
            throw new NotImplementedException();
        }

        public void OnExplore()
        {
            StateUpdate(GameState.EXPLORE, new ExploreState(this.party.GetCurrentRoom(),
                this.party));
        }

        public void OnFight(IFightModel fightModel)
        {
            throw new NotImplementedException();
        }

        public void OnInventory()
        {
            throw new NotImplementedException();
        }

        public void OnMenu()
        {
            throw new NotImplementedException();
        }

        public void OnPause()
        {
            throw new NotImplementedException();
        }

        public void OnShop(Shop shop)
        {
            throw new NotImplementedException();
        }

        private void StateUpdate(GameState gameState, ModelState modelState)
        {
            stateChanged = true;
            currentGameState = gameState;
            currentModelState = modelState;
        }
    }
}
