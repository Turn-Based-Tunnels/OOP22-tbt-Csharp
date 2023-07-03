using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBT_CSharp_Bekic_Dario
{
    /// <summary>
    /// Interface of the Room with only the methods needed for moving.
    /// </summary>
    public interface IRoom
    {
        /// <summary>
        /// Gets the height of the room.
        /// </summary>
        /// <returns>The height of the room.</returns>
        int GetHeight();

        /// <summary>
        /// Gets the width of the room.
        /// </summary>
        /// <returns>The width of the room.</returns>
        int GetWidth();

        /// <summary>
        /// Checks if the rectangle formed by the specified coordinates and dimensions is within the room boundaries.
        /// </summary>
        /// <param name="xCenter">The x-coordinate of the rectangle's center.</param>
        /// <param name="yCenter">The y-coordinate of the rectangle's center.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        /// <returns>True if the rectangle does not exceed the room boundaries; otherwise, false.</returns>
        bool IsValidCoordinates(int xCenter, int yCenter, int width, int height);
    }
}
