using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBT_CSharp_Bekic_Dario.Other;

namespace TBT_CSharp_Bekic_Dario
{
    public interface GameViewFactory
    {

        /**
         * @param menuController
         * @param menuState
         * @return the Menu view which renders the menuState data and has InputHandling done by menuController.
         */
        GameView CreateMenu(ViewController menuController, MenuState menuState);

        /**
         * @param menuController the controller to be passed the view
         * @param menuState the state the view will need to render
         * @return the Menu view which renders the menuState data and has InputHandling done by menuController.
         */
        GameView CreatePause(ViewController menuController, MenuState menuState);
        /**
         * @param exploreController the controller to be passed the view
         * @param exploreState the state the view will need to render
         * @return the GameView for the {@link it.tbt.model.GameState#EXPLORE} Game State
         */
        GameView CreateRoom(ViewController exploreController, IExploreState exploreState);

        /**
         * @param shopController the controller to be passed the view
         * @param shopState the state the view will need to render
         * @return the GameView for the {@link it.tbt.model.GameState#SHOP} Game State
         */
        GameView CreateShop(ShopController shopController, ShopState shopState);

        /**
         * @param fightController the controller to be passed the view
         * @param fightState the state the view will need to render
         * @return the GameView for the {@link it.tbt.model.GameState#FIGHT} Game State
         */
        GameView CreateFight(ViewController fightController, FightState fightState);

        /**
         * @param inventoryController the controller to be passed the view
         * @param inventoryState the state the view will need to render
         * @return the GameView for the {@link it.tbt.model.GameState#INVENTORY} Game State
         */
        GameView CreateInventory(ViewController inventoryController, InventoryState inventoryState);

        /**
         * @param endViewController the controller to be passed the view
         * @param endState the state the view will need to render
         * @return the GameView for the {@link it.tbt.model.GameState#ENDING} Game State
         */
        GameView CreateEndScreen(ViewController endViewController, EndState endState);

    }

}
