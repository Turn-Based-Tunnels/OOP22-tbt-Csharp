using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBT_CSharp_Bekic_Dario
{
    /// <summary>
    /// The <c>InputListener</c> interface represents an input listener that handles key press events.
    /// Implementations of this interface can be registered to receive key press events.
    /// </summary>
    public interface InputListener
    {
        /// <summary>
        /// Called when a key is pressed.
        /// </summary>
        /// <param name="key">The key code of the pressed key.</param>
        void OnKeyPressed(int key);
    }
}
