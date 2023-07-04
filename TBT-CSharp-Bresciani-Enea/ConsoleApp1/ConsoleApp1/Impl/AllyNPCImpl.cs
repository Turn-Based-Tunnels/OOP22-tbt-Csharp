using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Impl
{
    /// <summary>
    /// The <c>AllyNPCImpl</c> class is an implementation of the <see cref="AllyNPC"/> interface.
    /// It extends the <see cref="AbstractNPCImpl"/> class and represents an NPC ally.
    /// </summary>
    public class AllyNPCImpl : AbstractNPCImpl, Api.AllyNPC//, KillableEntity non di mia competenza
    {
        private readonly Dummy.Ally ally;
        //private KillObserver killObserver; non di mia competenza

        /// <summary>
        /// Constructs a new instance of the AllyNPCImpl class with the specified name, position, dimensions, and ally.
        /// </summary>
        /// <param name="name">The name of the ally NPC.</param>
        /// <param name="x">The X coordinate of the ally NPC's position.</param>
        /// <param name="y">The Y coordinate of the ally NPC's position.</param>
        /// <param name="height">The height of the ally NPC.</param>
        /// <param name="width">The width of the ally NPC.</param>
        /// <param name="ally">The ally associated with the NPC.</param>
        /// <exception cref="System.ArgumentException">Thrown if the name is null or empty, or if the ally is null.</exception>
        public AllyNPCImpl(string name, int x, int y, int height, int width, Dummy.Ally ally)
            : base(name, x, y, height, width)
        {
            if (ally == null)
            {
                throw new System.ArgumentException("Ally cannot be null");
            }

            this.ally = ally;
            //this.killObserver = null;
        }

        /// <summary>
        /// Gets the ally associated with the ally NPC.
        /// </summary>
        /// <returns>The ally character.</returns>
        public Dummy.Ally GetAlly()
        {
            return this.ally;
        }

        /*
         * Metodi ereditati da interfacce o classi non di mia competenza
         * 
         * 
         * 
         * 
         * 
        /// <summary>
        /// Handles the interaction with the NPC.
        /// </summary>
        /// <param name="interactionTrigger">The spatial entity triggering the interaction.</param>
        public void OnInteraction(SpatialEntity interactionTrigger)
        {
            if (interactionTrigger is IParty party)
            {
                List<Ally> temp = new List<Ally>(party.Members);
                temp.Add(ally);
                party.Members = temp;
            }
            this.killObserver?.OnKill(this);
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
