using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace TBT_CSharp_Bekic_Dario.Test
{
    [TestFixture]
    public class TestTransition
    {
        [Test]
        public void TransitionTest()
        {
            IRoom room1 = new Room(Room.DEFAULT_WIDTH_ROOM, Room.DEFAULT_HEIGHT_ROOM);
            IRoom room2 = new Room(400, 400);
            var party = new Party(25, 25, 50, 50);
            var x = new TransitionManager(party);
            //Exception is throw. No GameState has been triggered.
            Assert.Throws<InvalidOperationException>(() =>
            {
                x.GetCurrentModelState();
            });
            x.Init();
            //After the init, still no GameState has been triggered.
            Assert.Throws<InvalidOperationException>(() =>
            {
                x.GetCurrentModelState();
            });
            //Triggers GameState change.
            party.SetCurrentRoom(room1); 
            Assert.AreEqual(x.GetState(), GameState.EXPLORE);
            Assert.True(x.HasStateChanged());
            Assert.False(x.HasStateChanged());
        }

    }
}
