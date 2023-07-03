using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBT_CSharp_Bekic_Dario.Other;

namespace TBT_CSharp_Bekic_Dario
{
    /// <summary>
    /// Interface implemented by the object that wants to be able to handle GameState transitions and define an appropriate response.
    /// </summary>
    public interface IStateObserver
    {
        /// <summary>
        /// Defines the action to be taken when the EXPLORE GameState is triggered.
        /// </summary>
        void OnExplore();

        /// <summary>
        /// Defines the action to be taken when the MENU GameState is triggered.
        /// </summary>
        void OnMenu();

        /// <summary>
        /// Defines the action to be taken when the PAUSE GameState is triggered.
        /// </summary>
        void OnPause();

        /// <summary>
        /// Defines the action to be taken when the FIGHT GameState is triggered.
        /// </summary>
        /// <param name="fightModel">Object modeling the fight.</param>
        void OnFight(IFightModel fightModel);

        /// <summary>
        /// Defines the action to be taken when the INVENTORY GameState is triggered.
        /// </summary>
        void OnInventory();

        /// <summary>
        /// Defines the action to be taken when the SHOP GameState is triggered.
        /// </summary>
        /// <param name="shop">The shop object.</param>
        void OnShop(Shop shop);

        /// <summary>
        /// Defines the action to be taken when the ENDING GameState is triggered.
        /// </summary>
        /// <param name="message">The ending message.</param>
        void OnEnding(string message);
    }
}
