using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Api
{
    /// <summary>
    /// The <c>NPC</c> interface represents a non-player character (NPC) in the game world.
    /// It extends the <see cref="SpatialEntity"/> interface and the <see cref="Interactable"/> interface.
    /// </summary>
    public interface NPC //: SpatialEntity, Interactable Interfacce non di mia competenza
    {
        /// <summary>
        /// Retrieves the name of the NPC.
        /// </summary>
        /// <returns>The name of the NPC.</returns>
        string GetName();
    }
}
