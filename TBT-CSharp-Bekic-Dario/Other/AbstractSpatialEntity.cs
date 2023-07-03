using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBT_CSharp_Bekic_Dario.Other
{
    /// <summary>
    /// Generic entity with a position in space.
    /// </summary>
    public abstract class AbstractSpatialEntity : ISpatialEntity
    {
        private readonly int x;
        private readonly int y;
        private readonly int width;
        private readonly int height;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        protected AbstractSpatialEntity(string name, int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Gets the X coordinate.
        /// </summary>
        /// <returns>The X coordinate.</returns>
        public int GetX()
        {
            return x;
        }

        /// <summary>
        /// Gets the Y coordinate.
        /// </summary>
        /// <returns>The Y coordinate.</returns>
        public int GetY()
        {
            return y;
        }

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <returns>The height.</returns>
        public int GetHeight()
        {
            return height;
        }

        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <returns>The width.</returns>
        public int GetWidth()
        {
            return width;
        }
    }
}
