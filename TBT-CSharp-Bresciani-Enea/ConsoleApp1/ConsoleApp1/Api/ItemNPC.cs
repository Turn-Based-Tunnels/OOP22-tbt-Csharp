using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Api
{
    /// <summary>
    /// The <c>ItemNPC</c> interface represents a non-player character (NPC) that provides items.
    /// It extends the <see cref="NPC"/> interface and provides a method to retrieve the available items.
    /// </summary>
    public interface ItemNPC : NPC
    {
        /// <summary>
        /// Gets the dictionary of available items provided by the NPC.
        /// The dictionary keys represent the items, and the values represent the quantity of each item.
        /// </summary>
        /// <returns>The dictionary of items and their quantities.</returns>
        Dictionary<Dummy.Item, int> GetItems();
    }
}
