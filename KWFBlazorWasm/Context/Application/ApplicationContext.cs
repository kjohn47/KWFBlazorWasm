namespace KWFBlazorWasm.Context.Application
{
    using KWFBlazorWasm.Configuration.Application;
    using KWFBlazorWasm.Configuration.Assemblies;
    using KWFBlazorWasm.Configuration.Json;

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ApplicationContext : IApplicationContext
    {
        private readonly IKwfAppConfiguration configuration;
        private readonly IAppAssemblyInjector appAssemblies;
        private readonly KwfJsonSerializerOptions standartAppJsonSettings;

        private Action forceAppRenderAction;
        private List<Action> initializeActions;
        private List<Task> initializeActionsAsync;

        public ApplicationContext(IKwfAppConfiguration configuration, IAppAssemblyInjector appAssemblies)
        {
            if (appAssemblies == null || appAssemblies.MainAssembly == null)
            {
                throw new ArgumentNullException(nameof(appAssemblies), "App assemblies was not defined, Main assembly is necessary");
            }

            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration), "App configuration was not defined");
            this.appAssemblies = appAssemblies;
            this.initializeActions = new List<Action>();
            this.initializeActionsAsync = new List<Task>();
            this.standartAppJsonSettings = new KwfJsonSerializerOptions();
        }

        public IKwfAppConfiguration Configuration { 
            get 
            {
                return this.configuration;
            } 
        }

        public IAppAssemblyInjector AppAssemblies
        {
            get
            {
                return this.appAssemblies;
            }
        }

        public KwfJsonSerializerOptions StandartAppJsonSettings 
        {
            get
            {
                return this.standartAppJsonSettings;
            }
        }

        public void ForceAppRender()
        {
            if (this.forceAppRenderAction != null)
            {
                this.forceAppRenderAction.Invoke();
            }
        }

        public void ExecuteInitializeActions(Action updateStateAction)
        {
            this.forceAppRenderAction = updateStateAction;

            if (this.initializeActions.Count == 0)
            {
                return;
            }

            foreach (var action in this.initializeActions)
            {
                action.Invoke();
            }
        }

        public async Task ExecuteInitializeActionsAsync(Task baseTask)
        {
            if (this.initializeActionsAsync.Count == 0)
            {
                return;
            }

            foreach (var action in this.initializeActionsAsync)
            {
                await action;
            }

            await baseTask;
        }

        public ApplicationContext SetInitializeActions(IList<Action> actions)
        {
            if (actions != null && actions.Count > 0)
            {
                this.initializeActions.AddRange(actions);
            }
            return this;
        }
        public ApplicationContext SetInitializeActionsAsync(IList<Task> actions)
        {
            if (actions != null && actions.Count > 0)
            {
                this.initializeActionsAsync.AddRange(actions);
            }
            return this;
        }
    }
}
