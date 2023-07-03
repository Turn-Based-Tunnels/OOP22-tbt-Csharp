using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBT_CSharp_Bekic_Dario
{
    /// <summary>
    /// AbstractViewController for all ViewController objects.
    /// </summary>
    public abstract class AbstractViewController : ViewController
    {
        private readonly List<ICommand> commands;

        /// <summary>
        /// Creates the command list.
        /// </summary>
        protected AbstractViewController()
        {
            this.commands = new List<ICommand>();
        }

        /// <summary>
        /// Gets the list of Commands intercepted.
        /// </summary>
        /// <returns>The list of Commands intercepted.</returns>
        public List<ICommand> GetCommands()
        {
            return commands.ToList();
        }

        /// <summary>
        /// Cleans the Commands this ViewController currently has.
        /// </summary>
        public void Clean()
        {
            commands.Clear();
        }

        /// <summary>
        /// Adds a command to the list.
        /// </summary>
        /// <param name="command">The command to add to the list.</param>
        protected void AddCommand(ICommand command)
        {
            commands.Add(command);
        }

        public abstract void OnKeyPressed(int key);
    }
}
