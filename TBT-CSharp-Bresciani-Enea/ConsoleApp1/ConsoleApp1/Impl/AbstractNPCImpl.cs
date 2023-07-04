using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Impl
{
    /// <summary>
    /// The <c>AbstractNPCImpl</c> class is an abstract implementation of the <see cref="NPC"/> interface.
    /// It extends the <see cref="EntityImpl"/> class and provides basic functionality for NPCs.
    /// </summary>
    public abstract class AbstractNPCImpl : Api.NPC//, EntityImpl classe non di mia competenza
    {
        private readonly int x;
        private readonly int y;
        private readonly int height;
        private readonly int width;
        private readonly string name;

        /// <summary>
        /// Constructs a new instance of the AbstractNPCImpl class with the specified name, position, and dimensions.
        /// </summary>
        /// <param name="name">The name of the NPC.</param>
        /// <param name="x">The X coordinate of the NPC's position.</param>
        /// <param name="y">The Y coordinate of the NPC's position.</param>
        /// <param name="height">The height of the NPC.</param>
        /// <param name="width">The width of the NPC.</param>
        /// <exception cref="System.ArgumentException">Thrown if name is null or empty, or if height or width is negative.</exception>
        public AbstractNPCImpl(string name, int x, int y, int height, int width)// : base(name) EntityImpl non di mia competenza
        {
            if (height < 0)
            {
                throw new System.ArgumentException("Height cannot be negative");
            }
            if (width < 0)
            {
                throw new System.ArgumentException("Width cannot be negative");
            }
            this.x = x;
            this.y = y;
            this.height = height;
            this.width = width;
            this.name = name;
        }

        /// <summary>
        /// Gets the X coordinate of the NPC's position.
        /// </summary>
        /// <returns>The X coordinate of the NPC's position.</returns>
        public int GetX()
        {
            return x;
        }

        /// <summary>
        /// Gets the Y coordinate of the NPC's position.
        /// </summary>
        /// <returns>The Y coordinate of the NPC's position.</returns>
        public int GetY()
        {
            return y;
        }

        /// <summary>
        /// Gets the height of the NPC.
        /// </summary>
        /// <returns>The height of the NPC.</returns>
        public int GetHeight()
        {
            return height;
        }

        /// <summary>
        /// Gets the width of the NPC.
        /// </summary>
        /// <returns>The width of the NPC.</returns>
        public int GetWidth()
        {
            return width;
        }
        /// <summary>
        /// Gets the name of the NPC.
        /// </summary>
        /// <returns>The name of the NPC.</returns>
        public string GetName()
        {
            return name;
        }
    }
}
