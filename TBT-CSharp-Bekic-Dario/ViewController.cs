using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBT_CSharp_Bekic_Dario
{
    /// <summary>
    /// Interface for the input hub for the current view/state.
    /// </summary>
    public interface ViewController : InputListener
    {
        /// <summary>
        /// Gets the list of intercepted Commands.
        /// </summary>
        /// <returns>The list of intercepted Commands.</returns>
        List<ICommand> GetCommands();

        /// <summary>
        /// Cleans the Commands that this ViewController currently has.
        /// </summary>
        void Clean();
    }
}
