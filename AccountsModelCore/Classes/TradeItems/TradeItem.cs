using System.Collections.Generic;
using AccountLib.Interfaces;
using AccountLib.Interfaces.TradeItems;

namespace AccountLib.Model.TradeItems
{
    public class TradeItem : ITradeItem, IDbModel
    {
        public int Id { get; set; }

        public string HtsNo { get; set; }
        public string StatSuffix { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public string UnitofQuantity { get; set; }
        public string Col1Rate { get; set; }
        public string SpecialRate { get; set; }
        public string Col2Rate { get; set; }
        public string FootNoteComments { get; set; }

        public int HtsChapterId { get; set; }
        public HtsChapter HtsChapter { get; set; }

        public virtual ICollection<SubTradeItem> ChildTradeItems { get; set; }

    }
}
