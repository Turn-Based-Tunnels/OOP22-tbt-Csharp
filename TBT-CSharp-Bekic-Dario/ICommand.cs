using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBT_CSharp_Bekic_Dario
{
    /// <summary>
    /// Interface wrapper for input corresponding logic.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Action that the Command should be doing.
        /// </summary>
        void Execute();
    }
}
