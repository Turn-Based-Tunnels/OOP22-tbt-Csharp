using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBT_CSharp_Bekic_Dario
{
    /// <summary>
    /// This interface represents the conceptual contract
    /// that each view should implement in order to be accepted by the rest of the architecture.
    /// The only method needed by every view is the render method.
    /// </summary>
    public interface GameView
    {
        /// <summary>
        /// The view render logic.
        /// </summary>
        void Render();
    }
}
