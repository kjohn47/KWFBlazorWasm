namespace KWFBlazorWasm.Context.Application
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ApplicationContext : IApplicationContext
    {
        private Action forceAppRenderAction;
        private List<Action> initializeActions;
        private List<Task> initializeActionsAsync;

        public ApplicationContext()
        { 
            this.initializeActions = new List<Action>();
            this.initializeActionsAsync = new List<Task>();
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
