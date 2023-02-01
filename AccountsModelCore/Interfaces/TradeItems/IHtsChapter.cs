using AccountsModelCore.Classes.TradeItems;
using System.Collections.Generic;

namespace AccountsModelCore.Interfaces.TradeItems
{
    public interface IHtsChapter
    {
        string Name { get; set; }

        int HtsSectionId { get; set; }
        HtsSection HtsSection { get; set; }

        ICollection<TradeItem> Headings { get; set; }

    }
}
