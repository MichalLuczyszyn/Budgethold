namespace Budgethold.Bootstrapper;

using System.Reflection;
using Shared.Abstractions.Modules;

internal static class ModuleLoader
{
    public static IList<Assembly> LoadAssemblies(IConfiguration configuration)
    {
        const string modulePart = "Budgethold.Modules.";
        var assembly = AppDomain.CurrentDomain.GetAssemblies().ToList();
        var locations = assembly.Where(x => !x.IsDynamic).Select(x => x.Location).ToArray();

        var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
            .Where(x => !locations.Contains(x, StringComparer.InvariantCultureIgnoreCase)).ToList();

        var disabledModules = new List<string>();
        foreach (var file in files)
        {
            if (!file.Contains(modulePart))
            {
                continue;
            }

            var moduleName = file.Split(modulePart)[1].Split(".")[0].ToLowerInvariant();
            var enabled = configuration.GetValue<bool>($"{moduleName}:module:enabled");
            if (!enabled)
            {
                disabledModules.Add(file);
            }
        }

        foreach (var module in disabledModules)
        {
            files.Remove(module);
        }
        
        files.ForEach(x => assembly.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(x))));

        return assembly;
    }

    public static IList<IModule> LoadModules(IEnumerable<Assembly> assemblies)
        => assemblies
            .SelectMany(x => x.GetTypes())
            .Where(x => typeof(IModule).IsAssignableFrom(x) && !x.IsInterface)
            .OrderBy(x => x.Name)
            .Select(Activator.CreateInstance)
            .Cast<IModule>()
            .ToList();
}
