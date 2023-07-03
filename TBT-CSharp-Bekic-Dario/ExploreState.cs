using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBT_CSharp_Bekic_Dario
{
    /// <summary>
    /// Default implementation of the Explore GameState wrapper. (SIMPLIFIED).
    /// </summary>
    public class ExploreState : IExploreState
    {
        private readonly IRoom room;
        private readonly IParty party;
        public ExploreState(IRoom room, IParty party)
        {
            this.room = room;
            this.party = party;
        }
        /// <summary>
        /// Gets the party used by the player.
        /// </summary>
        /// <returns>The party used by the player.</returns>
        public IParty GetParty()
        {
            return this.party;
        }

        /// <summary>
        /// Gets the current room.
        /// </summary>
        /// <returns>The current room.</returns>
        public IRoom GetRoom()
        {
            return this.room;
        }
    }
}
