using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBT_CSharp_Bekic_Dario
{
    /// <summary>
    /// GameState Transition Manager, it is a StateObserver because it wants
    /// to be alerted on every State change.
    /// </summary>
    public interface ITransitionManager : IStateObserver
    {
        /// <summary>
        /// Operations to set the TransitionManager in motion.
        /// </summary>
        void Init();

        /// <summary>
        /// Gets the current GameState if the TransitionManager has been initialized.
        /// </summary>
        /// <returns>The current GameState.</returns>
        GameState GetState();

        /// <summary>
        /// Gets the current ModelState if the TransitionManager has been initialized.
        /// </summary>
        /// <returns>The current ModelState.</returns>
        ModelState GetCurrentModelState();

        /// <summary>
        /// Checks if a State change has been observed and it's the first time
        /// this method has been called since the State change has been observed.
        /// </summary>
        /// <returns>True if a State change has occurred and this is the first call
        /// after the change; otherwise, false.</returns>
        bool HasStateChanged();
    }
}
