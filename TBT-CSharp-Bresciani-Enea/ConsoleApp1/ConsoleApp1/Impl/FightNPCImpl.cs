using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Impl
{
    /// <summary>
    /// The <c>FightNPCImpl</c> class is an implementation of the <see cref="FightNPC"/> interface.
    /// It extends the <see cref="AbstractNPCImpl"/> class and represents an NPC that triggers fights.
    /// </summary>
    public class FightNPCImpl : AbstractNPCImpl, Api.FightNPC//, StateTrigger, KillableEntity non di mia competenza
    {
        private readonly Dummy.FightModel fightModel;
        //private KillObserver killObserver;
        //private StateObserver stateObserver;

        /// <summary>
        /// Constructs a new instance of the FightNPCImpl class with the specified name, position, dimensions, and fight model.
        /// </summary>
        /// <param name="name">The name of the fight NPC.</param>
        /// <param name="x">The X coordinate of the fight NPC's position.</param>
        /// <param name="y">The Y coordinate of the fight NPC's position.</param>
        /// <param name="height">The height of the fight NPC.</param>
        /// <param name="width">The width of the fight NPC.</param>
        /// <param name="fightModel">The fight model associated with the NPC.</param>
        public FightNPCImpl(string name, int x, int y, int height, int width, Dummy.FightModel fightModel)
            : base(name, x, y, height, width)
        {
            this.fightModel = fightModel ?? throw new ArgumentNullException(nameof(fightModel));
            //this.killObserver = null;
        }

        /*
         * Implementazione di classi o interfaccie di non mia competenza
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

            if (stateObserver == null)
            {
                throw new InvalidOperationException("StateObserver not set");
            }

            if (killObserver == null)
            {
                throw new InvalidOperationException("KillObserver not set");
            }

            fightModel.InitializeParty(party);
            stateObserver.OnFight(fightModel);
            killObserver.OnKill(this);
        }
        */

        /// <summary>
        /// Gets the fight model associated with the NPC.
        /// </summary>
        /// <returns>The fight model.</returns>
        public Dummy.FightModel GetFightModel()
        {
            return fightModel;
        }

        /*
         * Implementazione di classi o interfaccie di non mia competenza
         * 
        /// <summary>
        /// Sets the state observer for the NPC.
        /// </summary>
        /// <param name="stateObserver">The state observer.</param>
        public void SetStateObserver(StateObserver stateObserver)
        {
            this.stateObserver = stateObserver;
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
