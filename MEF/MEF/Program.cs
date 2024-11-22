using System;
using System.Composition;
using System.Composition.Convention;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Runtime.Loader;
internal class Program
{
    private static void Main(string[] args)
    {
        var conventions = new ConventionBuilder();

        conventions
            .ForTypesDerivedFrom<IPlugin>()
            .Export<IPlugin>()
            .Shared();
    }
}

public static class ContainerConfigurationExtensions
{
    public static ContainerConfiguration WithAssembliesInPath(this ContainerConfiguration configuration,
        string path, SearchOption searchOption = SearchOption.TopDirectoryOnly)
    {
        return WithAssembliesInPath(configuration, path, null, searchOption);
    }

    public static ContainerConfiguration WithAssembliesInPath(this ContainerConfiguration configuration, 
        string path, AttributedModelProvider conventions, SearchOption searchOption = SearchOption.TopDirectoryOnly)
    {
        var assemblies = Directory
            .GetFiles(path, "*.dll", searchOption)
            .Select(AssemblyLoadContext.Default.LoadFromAssemblyPath);

        configuration = configuration.WithAssemblies(assemblies, conventions);
        return configuration;
    }
}