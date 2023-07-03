using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBT_CSharp_Bekic_Dario.Other;

namespace TBT_CSharp_Bekic_Dario
{
    public interface IParty : IMovableEntity
    {
        /// <summary>
        /// Moves the party.
        /// </summary>
        /// <param name="xv">The x-axis velocity.</param>
        /// <param name="yv">The y-axis velocity.</param>
        void Move(int xv, int yv);

        /// <summary>
        /// Gets the current room.
        /// </summary>
        /// <returns>The current room.</returns>
        IRoom GetCurrentRoom();

        /// <summary>
        /// Sets the current room.
        /// </summary>
        /// <param name="room">The room to set as the current room.</param>
        void SetCurrentRoom(IRoom room);
    }
}
