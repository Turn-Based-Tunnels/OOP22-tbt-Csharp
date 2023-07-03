using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBT_CSharp_Bekic_Dario.Test
{
    [TestFixture]
    public class TestMove
    {
        [Test]
        public void TestMovementInRoom()
        {
            var x = new Party(25, 25, 50, 50);
            IRoom room1 = new Room(Room.DEFAULT_WIDTH_ROOM, Room.DEFAULT_HEIGHT_ROOM);
            x.SetCurrentRoom(room1);
            x.Move(30, 30);
            Assert.AreEqual(x.GetX(), 55);
            Assert.AreEqual(x.GetY(), 55);
            int distanceBorder = x.GetCurrentRoom().GetWidth() - x.GetX() - (x.GetWidth() / 2);
            while(distanceBorder>=0)
            {
                var current = x.GetX();
                x.Move(1, 0);
                if(distanceBorder!=0)
                {
                    Assert.True(x.GetX() == current + 1);
                } else
                {
                    Assert.True(x.GetX() != current + 1); //Should not be able to go past border of the Room.
                }
                distanceBorder--;
            }

        }
    }
}
