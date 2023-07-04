using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Api
{
    /// <summary>
    /// The <c>DialogueNPC</c> interface represents a non-player character (NPC) that provides dialogue.
    /// It extends the <see cref="NPC"/> interface and provides a method to retrieve the dialogue.
    /// </summary>
    public interface DialogueNPC : NPC
    {
        /// <summary>
        /// Gets the dialogue provided by the NPC.
        /// </summary>
        /// <returns>The dialogue string.</returns>
        string GetDialogue();
    }
}
