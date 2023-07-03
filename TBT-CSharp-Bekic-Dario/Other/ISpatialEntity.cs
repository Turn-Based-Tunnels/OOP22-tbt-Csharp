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
    public interface ISpatialEntity
    {
        /// <summary>
        /// Gets the X coordinate.
        /// </summary>
        /// <returns>The X coordinate.</returns>
        int GetX();

        /// <summary>
        /// Gets the Y coordinate.
        /// </summary>
        /// <returns>The Y coordinate.</returns>
        int GetY();

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <returns>The height.</returns>
        int GetHeight();

        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <returns>The width.</returns>
        int GetWidth();
    }
}
