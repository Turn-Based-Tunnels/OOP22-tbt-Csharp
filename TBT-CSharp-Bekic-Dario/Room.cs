using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBT_CSharp_Bekic_Dario.Other;

namespace TBT_CSharp_Bekic_Dario
{
    public class Room : IRoom
    {
        private readonly int roomWidth;
        private readonly int roomHeight;
        private readonly HashSet<ISpatialEntity> entities;

        public const int DEFAULT_HEIGHT_ROOM = 300;
        public const int DEFAULT_WIDTH_ROOM = 300;

        public Room(int roomWidth, int roomHeight)
        {
            this.roomWidth = roomWidth;
            this.roomHeight = roomHeight;
            this.entities = new HashSet<ISpatialEntity>();
        }

        public int GetHeight()
        {
            return this.roomHeight;
        }

        public int GetWidth()
        {
            return this.roomWidth;
        }

        public bool IsValidCoordinates(int xCenter, int yCenter, int width, int height)
        {
            int left = xCenter - (width / 2);
            int right = xCenter + (width / 2);
            int top = yCenter - (height / 2);
            int bottom = yCenter + (height / 2);
            return !(left < 0 || right > roomWidth || top < 0 || bottom > roomHeight);
        }
    }
}
