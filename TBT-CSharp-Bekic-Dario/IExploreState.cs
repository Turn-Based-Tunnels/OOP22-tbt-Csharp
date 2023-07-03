using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBT_CSharp_Bekic_Dario
{
    public interface IExploreState : ModelState
    {
        /// <summary>
        /// Gets the party used by the player.
        /// </summary>
        /// <returns>The party used by the player.</returns>
        IParty GetParty();

        /// <summary>
        /// Gets the current room where the player finds themselves in.
        /// </summary>
        /// <returns>The current room where the player is located.</returns>
        IRoom GetRoom();
    }
}
