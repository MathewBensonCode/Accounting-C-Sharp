using System.Collections.Generic;
using AccountsModelCore.Interfaces;
using AccountsModelCore.Interfaces.TradeItems;

namespace AccountsModelCore.Classes.TradeItems
{
    public class HtsSection : IHtsSection, IDbModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<HtsChapter> HtsChapters { get; set; }
    }
}
