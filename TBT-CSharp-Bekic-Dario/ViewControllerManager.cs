using System;
using System.Collections.Generic;

using System;
using System.Collections.Generic;
using TBT_CSharp_Bekic_Dario.Other;

namespace TBT_CSharp_Bekic_Dario
{
    public class ViewControllerManager : IViewControllerManager
    {
        private readonly GameViewFactory gameViewFactory;
        private ViewController? currentController;
        private GameView? currentGameView;

        public ViewControllerManager(GameViewFactory gameViewFactory)
        {
            this.gameViewFactory = gameViewFactory;
            
        }

        public List<ICommand> GetCommands()
        {
            return this.currentController!=null?(this.currentController.GetCommands()):new List<ICommand>();
        }

        public void RenderView(GameState gameState, ModelState modelState, bool hasChanged)
        {
            if (hasChanged)
            {
                switch (gameState)
                {
                    case GameState.EXPLORE:
                        HandleViewState<IExploreState, ExploreController>(modelState,
                                        typeof(IExploreState),
                                        typeof(ExploreController),
                                        (controller, state) => this.gameViewFactory.CreateRoom(state, controller));
                        break;
                    case GameState.MENU:
                        HandleViewState<MenuState, MainMenuController>(modelState,
                                        typeof(MenuState),
                                        typeof(MainMenuController),
                                        (controller, state) => this.gameViewFactory.CreateMenu(state, controller));
                        break;
                    case GameState.SHOP:
                        HandleViewState<ShopState, ShopController>(modelState,
                                        typeof(ShopState),
                                        typeof(ShopController),
                                        (controller, state) => this.gameViewFactory.CreateShop(state, controller));
                        break;
                    case GameState.PAUSE:
                        HandleViewState<MenuState, PauseMenuController>(modelState,
                                        typeof(MenuState),
                                        typeof(PauseMenuController),
                                        (controller, state) => this.gameViewFactory.CreatePause(state, controller));
                        break;
                    case GameState.FIGHT:
                        HandleViewState<FightState, FightControllerImpl>(modelState,
                                        typeof(FightState),
                                        typeof(FightControllerImpl),
                                        (controller, state) => this.gameViewFactory.CreateFight(state, controller));
                        break;
                    case GameState.INVENTORY:
                        HandleViewState<InventoryState, InventoryViewController>(modelState,
                                        typeof(InventoryState),
                                        typeof(InventoryViewController),
                                        (controller, state) => this.gameViewFactory.CreateInventory(state, controller));
                        break;
                    case GameState.ENDING:
                        HandleViewState<EndState, EndViewController>(modelState,
                                        typeof(EndState),
                                        typeof(EndViewController),
                                        (controller, state) => this.gameViewFactory.CreateEndScreen(state, controller));
                        break;
                    default:
                        throw new InvalidOperationException("GameState not handled by ViewManager.");
                }
            }
            if(this.currentGameView!=null)
            {
                this.currentGameView.Render();
            }
        }

        public void CleanCommands()
        {
            if (this.currentController != null)
            {
                this.currentController.Clean();
            }
        }

        private void HandleViewState<T, C>(ModelState modelState, Type stateClass, Type controllerClass, Func<T, C, GameView> createViewFunction)
            where T : ModelState
            where C : ViewController
        {
            try
            {
                if (!stateClass.IsInstanceOfType(modelState) || !typeof(C).IsAssignableFrom(controllerClass))
                {
                    throw new InvalidOperationException("Data passed to View Manager inconsistent.");
                }
                T state = (T)modelState;
                var x = Activator.CreateInstance(controllerClass, state);
                if (x is C controller)
                {
                    GameView view = createViewFunction(state, controller);
                    this.currentController = controller;
                    this.currentGameView = view;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}