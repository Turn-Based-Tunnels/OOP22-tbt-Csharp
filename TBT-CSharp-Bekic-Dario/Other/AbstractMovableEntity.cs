using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBT_CSharp_Bekic_Dario.Other
{
    public class AbstractMovableEntity : IMovableEntity
    {
        private int x;
        private int y;
        private readonly int width;
        private readonly int height;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="x">The initial X coordinate.</param>
        /// <param name="y">The initial Y coordinate.</param>
        /// <param name="width">The width of the entity.</param>
        /// <param name="height">The height of the entity.</param>
        public AbstractMovableEntity(
            int x,
            int y,
            int width,
            int height
        )
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
        /// Sets the X coordinate.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        public void SetX(int x)
        {
            this.x = x;
        }

        /// <summary>
        /// Sets the Y coordinate.
        /// </summary>
        /// <param name="y">The Y coordinate.</param>
        public void SetY(int y)
        {
            this.y = y;
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
