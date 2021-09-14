namespace KWFBlazorWasm.Configuration.Assemblies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class AppAssemblyInjector : IAppAssemblyInjector, IAppAssemblyInjectorSetup
    {
        private AppAssemblyInjector(Type typeOfMainProject)
        {
            this.MainAssembly = typeOfMainProject.Assembly;
            if (!typeof(AppAssemblyInjector).Assembly.Equals(this.MainAssembly))
            {
                this.AdditionalAssemblies = new[] { typeof(AppAssemblyInjector).Assembly };
            }
        }

        private AppAssemblyInjector(Type typeOfMainProject, IEnumerable<Type> additionalTypes) : this(typeOfMainProject)
        {
            var validTypes = additionalTypes.Distinct().Where(x => !x.Assembly.Equals(typeOfMainProject.Assembly) && !x.Assembly.Equals(typeof(AppAssemblyInjector).Assembly));

            if (validTypes.Any())
            {
                if (this.AdditionalAssemblies == null)
                {
                    this.AdditionalAssemblies = validTypes.Select(x => x.Assembly);
                }
                else
                {
                    var assemblies = this.AdditionalAssemblies.ToList();
                    assemblies.AddRange(validTypes.Select(x => x.Assembly));
                    this.AdditionalAssemblies = assemblies;
                }
            }
        }

        public Assembly MainAssembly { get; private set; }
        public IEnumerable<Assembly> AdditionalAssemblies { get; private set; }

        public static IAppAssemblyInjectorSetup Initialize(Type typeOfMainProject)
        {
            return new AppAssemblyInjector(typeOfMainProject);
        }

        public static IAppAssemblyInjectorSetup Initialize(Type typeOfMainProject, IEnumerable<Type> aditionalTypes)
        {
            return new AppAssemblyInjector(typeOfMainProject, aditionalTypes);
        }

        public IAppAssemblyInjectorSetup AddAdditionalAssembly(Type typeInAssembly)
        {
            var assembly = typeInAssembly.Assembly;
            if (this.MainAssembly == assembly || (this.AdditionalAssemblies?.Any(x => x.Equals(assembly))?? false))
            {
                return this;
            }

            var assemblyList = this.AdditionalAssemblies == null ? new List<Assembly>() : this.AdditionalAssemblies.ToList();
            assemblyList.Add(assembly);
            this.AdditionalAssemblies = assemblyList;

            return this;
        }

        public IAppAssemblyInjector Build()
        {
            return this;
        }
    }
}
