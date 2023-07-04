using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Api
{
    /// <summary>
    /// The <c>FightNPC</c> interface represents a non-player character (NPC) that participates in fights.
    /// It extends the <see cref="NPC"/> interface and provides a method to retrieve the associated fight model.
    /// </summary>
    public interface FightNPC : NPC
    {
        /// <summary>
        /// Gets the fight model associated with the NPC.
        /// </summary>
        /// <returns>The fight model.</returns>
        Dummy.FightModel GetFightModel();
    }
}
