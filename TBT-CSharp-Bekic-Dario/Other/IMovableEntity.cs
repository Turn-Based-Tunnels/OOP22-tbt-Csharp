using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBT_CSharp_Bekic_Dario.Other
{
    /// <summary>
    /// Generic entity with a variable position in space.
    /// </summary>
    public interface IMovableEntity : ISpatialEntity
    {
        /// <summary>
        /// Sets the X coordinate.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        void SetX(int x);

        /// <summary>
        /// Sets the Y coordinate.
        /// </summary>
        /// <param name="y">The Y coordinate.</param>
        void SetY(int y);
    }
}
