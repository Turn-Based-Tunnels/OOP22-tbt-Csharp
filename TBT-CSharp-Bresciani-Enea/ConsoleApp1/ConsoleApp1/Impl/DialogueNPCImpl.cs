using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Impl
{
    /// <summary>
    /// The <c>DialogueNPCImpl</c> class is an implementation of the <see cref="DialogueNPC"/> interface.
    /// It extends the <see cref="AbstractNPCImpl"/> class and represents an NPC with dialogue.
    /// </summary>
    public class DialogueNPCImpl : AbstractNPCImpl, Api.DialogueNPC
    {
        private readonly string dialogue;

        /// <summary>
        /// Constructs a new instance of the DialogueNPCImpl class with the specified name, position, dimensions, and dialogue.
        /// </summary>
        /// <param name="name">The name of the dialogue NPC.</param>
        /// <param name="x">The X coordinate of the dialogue NPC's position.</param>
        /// <param name="y">The Y coordinate of the dialogue NPC's position.</param>
        /// <param name="height">The height of the dialogue NPC.</param>
        /// <param name="width">The width of the dialogue NPC.</param>
        /// <param name="dialogue">The dialogue associated with the NPC.</param>
        /// <exception cref="System.ArgumentException">Thrown if name or dialogue is null or empty, or if height or width is negative.</exception>
        public DialogueNPCImpl(string name, int x, int y, int height, int width, string dialogue)
            : base(name, x, y, height, width)
        {
            if (string.IsNullOrEmpty(dialogue))
            {
                throw new ArgumentException("Dialogue cannot be null or empty");
            }
            this.dialogue = dialogue;
        }

        /// <summary>
        /// Gets the dialogue provided by the NPC.
        /// </summary>
        /// <returns>The dialogue string.</returns>
        public string GetDialogue()
        {
            return this.dialogue;
        }

        /*
         * 
         *  
         
        /// <summary>
        /// Handles the interaction with the NPC.
        /// </summary>
        /// <param name="interactable">The spatial entity triggering the interaction.</param>
        public void OnInteraction(SpatialEntity interactable)
        {
            if (interactable is IParty party)
            {
                party.Dialogue = new KeyValuePair<string, string>(this.Name, this.GetDialogue());
            }
        }
        */
    }
}
