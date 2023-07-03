using System;
using System.Collections.Generic;

namespace TBT_CSharp_Bekic_Dario
{
    public interface IViewControllerManager
    {
        /// <summary>
        /// Returns an optional list of commands. If it is empty, no command has been added.
        /// </summary>
        /// <returns>An optional list of commands.</returns>
        List<ICommand> GetCommands();

        /// <summary>
        /// Renders the view associated with the game state and provides it with the model state for rendering its data.
        /// The hasChanged parameter notifies the manager if the provided game state has already been rendered,
        /// so no additional steps are needed to create the view.
        /// </summary>
        /// <param name="gameState">The current game state.</param>
        /// <param name="modelState">The model state modeling the current game state.</param>
        /// <param name="hasChanged">Boolean representing if a new view is needed or just rendering is sufficient.</param>
        void RenderView(GameState gameState, ModelState modelState, bool hasChanged);

        /// <summary>
        /// Cleans the commands of the current controller.
        /// </summary>
        void CleanCommands();
    }
}