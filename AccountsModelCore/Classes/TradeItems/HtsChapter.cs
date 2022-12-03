using AccountLib.Interfaces;
using AccountLib.Interfaces.TradeItems;
using System.Collections.Generic;

namespace AccountLib.Model.TradeItems
{
    public class HtsChapter : IHtsChapter, IDbModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int HtsSectionId { get; set; }
        public virtual HtsSection HtsSection { get; set; }

        public virtual ICollection<TradeItem> Headings { get; set; }
    }
}
