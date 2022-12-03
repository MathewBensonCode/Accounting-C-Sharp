using System.Text.RegularExpressions;

namespace AccountsViewModel.Factories.Interfaces.RegexFactories
{
    public interface IRegexFactory
    {
        Regex CreateRegex(string regexpr);
    }
}
