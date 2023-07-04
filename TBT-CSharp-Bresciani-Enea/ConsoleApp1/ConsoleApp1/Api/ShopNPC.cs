using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Api
{
    /// <summary>
    /// The <c>ShopNPC</c> interface represents an NPC that operates a shop in the game.
    /// It extends the <see cref="NPC"/> interface.
    /// </summary>
    public interface ShopNPC : NPC
    {
        /// <summary>
        /// Retrieves the shop associated with the NPC.
        /// </summary>
        /// <returns>The shop operated by the NPC.</returns>
        Dummy.Shop GetShop();
    }
}
 