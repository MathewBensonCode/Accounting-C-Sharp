using System.Collections.Generic;
using AccountsModelCore.Classes.TradeItems;

namespace AccountsModelCore.Interfaces.TradeItems
{
    public interface IHtsSection
    {
        string Name { get; set; }

        ICollection<HtsChapter> HtsChapters { get; set; }
    }
}
