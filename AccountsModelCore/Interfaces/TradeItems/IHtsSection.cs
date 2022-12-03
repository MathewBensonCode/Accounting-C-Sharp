using System.Collections.Generic;
using AccountLib.Model.TradeItems;

namespace AccountLib.Interfaces.TradeItems
{
    public interface IHtsSection
    {
        string Name { get; set; }

        ICollection<HtsChapter> HtsChapters { get; set; }
    }
}
