using System.Text.RegularExpressions;
using AccountsViewModel.Factories.Interfaces.RegexFactories;
using Unity;
using Unity.Resolution;

namespace AccountsViewModel.Factories.Unity
{
    public class RegexFactory
        : IRegexFactory
    {
        private readonly IUnityContainer _container;
        public RegexFactory(IUnityContainer container)
        {
            _container = container;
        }
        public Regex CreateRegex(string regexpr)
        {
            return _container.Resolve(typeof(Regex), null,
                new ResolverOverride[]
                {
                    new ParameterOverride("pattern", regexpr)
                }) as Regex;
        }
    }
}
