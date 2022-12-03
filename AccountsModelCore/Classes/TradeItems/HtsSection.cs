using System.Collections.Generic;
using AccountLib.Interfaces;
using AccountLib.Interfaces.TradeItems;

namespace AccountLib.Model.TradeItems
{
    public class HtsSection : IHtsSection, IDbModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<HtsChapter> HtsChapters { get; set; }
    }
}
