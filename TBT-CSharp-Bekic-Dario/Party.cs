using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBT_CSharp_Bekic_Dario.Other;

namespace TBT_CSharp_Bekic_Dario
{
    /// <summary>
    /// Dummy implementation of Party class, includes only operations to move the Party.
    /// </summary>
    public class Party : AbstractMovableEntity, IParty, IStateTrigger
    {
        private IRoom? currentRoom;
        private IStateObserver? stateObserver;
        public Party(int x, int y, int width, int height) : base(x, y, width, height) { }

        public IRoom GetCurrentRoom()
        {
            if(this.currentRoom == null) { throw new InvalidOperationException("Player has no room assigned to it."); }
            return this.currentRoom;
        }

        public void Move(int xv, int yv)
        {
            if (this.GetCurrentRoom().IsValidCoordinates(xv + GetX(), yv + GetY(), GetWidth(), GetHeight()))
            {
                SetX(GetX() + xv);
                SetY(GetY() + yv);
            }
        }

        public void SetCurrentRoom(IRoom room)
        {
            this.currentRoom = room;
            if (this.stateObserver != null) { this.stateObserver.OnExplore(); }
        }

        public void SetStateObserver(IStateObserver stateObserver)
        {
            this.stateObserver = stateObserver;
        }
    }
}
