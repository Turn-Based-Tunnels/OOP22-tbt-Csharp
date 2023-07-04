using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Api
{
    /// <summary>
    /// The <c>AllyNPC</c> interface represents an ally non-player character (NPC).
    /// It extends the <see cref="NPC"/> interface and provides access to the associated ally character.
    /// </summary>
    internal interface AllyNPC : NPC
    {
        /// <summary>
        /// Gets the ally character associated with the ally NPC.
        /// </summary>
        /// <returns>The ally character.</returns>
        Dummy.Ally GetAlly();
    }
}
