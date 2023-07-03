using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBT_CSharp_Bekic_Dario
{
    /// <summary>
    /// Interface for objects that want to change the GameState.
    /// </summary>
    public interface IStateTrigger
    {
        /// <summary>
        /// Sets the StateObserver to be notified for changes in the GameState.
        /// </summary>
        /// <param name="stateObserver">The StateObserver to be set.</param>
        void SetStateObserver(IStateObserver stateObserver);
    }
}
