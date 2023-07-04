using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Api
{
    /// <summary>
    /// The <c>HealerNPC</c> interface represents a non-player character (NPC) that can heal entities.
    /// It extends the <see cref="NPC"/> interface and provides a method to retrieve the heal amount.
    /// </summary>
    public interface HealerNPC : NPC
    {
        /// <summary>
        /// Gets the amount of healing provided by the NPC.
        /// </summary>
        /// <returns>The heal amount.</returns>
        int GetHealAmount();
    }
}
