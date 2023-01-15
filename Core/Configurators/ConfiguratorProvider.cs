using DAL.Core.Configurators.Interfaces;

namespace DAL.Core.Configurators
{
    internal static class ConfiguratorProvider
    {
        public static List<IConfigurator> Provide()
        {
            var configuratorTypes = typeof(IConfigurator).Assembly.GetTypes()
                .Where(t => !t.IsAbstract && !t.IsInterface && t.IsClass && t.ReflectedType == null)
                .Where(t => t.GetInterfaces().Any(it => it == typeof(IConfigurator)))
                .ToArray();

            var configurators = configuratorTypes
                .Select(t => Activator.CreateInstance(t) as IConfigurator)
                .ToArray();

            var orderedConfigurators = configurators
                .Where(c => !c.DependsOn.Any())
                .ToArray();

            while (configurators.Length != orderedConfigurators.Length)
            {
                var readyDependencies = orderedConfigurators
                    .Select(oc => oc.Type)
                    .ToArray();

                var resolvedConfigurators = configurators
                    .Where(c => c.DependsOn.All(t => readyDependencies.Contains(t)))
                    .Where(c => orderedConfigurators.All(oc => oc.Type != c.Type))
                    .ToArray();

                if (!resolvedConfigurators.Any()) throw new InvalidDataException();

                orderedConfigurators = orderedConfigurators
                    .Concat(resolvedConfigurators)
                    .ToArray();
            }

            return orderedConfigurators.ToList();
        }
    }
}
