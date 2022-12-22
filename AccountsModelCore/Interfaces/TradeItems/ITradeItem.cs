using AccountsModelCore.Classes.TradeItems;
using System.Collections.Generic;

namespace AccountsModelCore.Interfaces.TradeItems
{
    public interface ITradeItem
    {
        string HtsNo { get; set; }
        string StatSuffix { get; set; }
        int Level { get; set; }
        string Description { get; set; }
        string UnitofQuantity { get; set; }
        string Col1Rate { get; set; }
        string SpecialRate { get; set; }
        string Col2Rate { get; set; }
        string FootNoteComments { get; set; }

        int HtsChapterId { get; set; }
        HtsChapter HtsChapter { get; set; }

        ICollection<SubTradeItem> ChildTradeItems { get; set; }
    }
}
