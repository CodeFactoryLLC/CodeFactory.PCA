using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Routing;
using IComponent = Microsoft.AspNetCore.Components.IComponent;
using System.Net.Http.Headers;
using System.Globalization;
using Microsoft.JSInterop;
using System.Security.Cryptography;

namespace CodeFactory.PCA.Blazor
{
    public abstract class ControllerBase :IComponent,IHandleAfterRender, IAsyncDisposable
    {
        /// <summary>
        /// Java script function name to enable prompting for navigation changes. 
        /// </summary>
        private const string JavaScriptEnableNavigationPrompt = "Blazor._internal.NavigationLock.enableNavigationPrompt";

        /// <summary>
        /// Java script function name to disable prompting for navigation changes.
        /// </summary>
        private const string JavaScriptDisableNavigationPrompt = "Blazor._internal.NavigationLock.disableNavigationPrompt";

        /// <summary>
        /// Default prompt message to display to users if they try to navigate from a page where 
        /// </summary>
        private const string DefaultPromptMessage = "Data has changed are you sure you want to leave the page?";

        /// <summary>
        /// Indentifier assigned to the controller. Used for java script execution.
        /// </summary>
        private readonly string _controllerId = Guid.NewGuid().ToString("D", CultureInfo.InvariantCulture);

        private RenderHandle _renderHandle;

        private IDisposable? _locationChangeSubscription;

        private bool _calledOnAfterRender = false;

        private bool _blockNavigationChange = false;

        private string _promptMessage = null;

        

        [Inject]
        private IJSRuntime JSRuntime { get; set; } = default!;

        [Inject]
        protected NavigationManager NavManager { get; set; } = default!;


        void IComponent.Attach(RenderHandle renderHandle)
        {
            _renderHandle = renderHandle;
        }

        Task IComponent.SetParametersAsync(ParameterView parameters)
        {
            parameters.SetParameterProperties(this);

            return Task.CompletedTask;
        }

        async Task IHandleAfterRender.OnAfterRenderAsync()
        {
            var firstRender = !_calledOnAfterRender;

            _calledOnAfterRender = true;

            if (_locationChangeSubscription == null) 
            { 
                _locationChangeSubscription = NavManager.RegisterLocationChangingHandler(OnLocationChanging);
            }
            OnAfterRender(firstRender);

            await OnAfterRenderAsync(firstRender);
        }

        /// <summary>
        /// Handles the <see cref="NavigationManager.LocationChanged"/> event from the navigation manager.
        /// </summary>
        /// <param name="context">The context of the location that is changing.</param>
        private ValueTask OnLocationChanging(LocationChangingContext context)
        { 
            if (_blockNavigationChange) context.PreventNavigation();

            return ValueTask.CompletedTask;
        
        }

        protected virtual void OnAfterRender(bool firstRender)
        { 
            //Intentionally blank
        }

        protected virtual Task OnAfterRenderAsync(bool firstRedner) => Task.CompletedTask;

        public virtual async ValueTask DisposeAsync()
        {

            _locationChangeSubscription?.Dispose();

            if(_blockNavigationChange) 
            {
                try
                {
                    await JSRuntime.InvokeVoidAsync(JavaScriptDisableNavigationPrompt, _controllerId);
                }
                catch (JSDisconnectedException)
                {
                    //Intentionally blank
                }
            }
             
        }


        /// <summary>
        /// Determines if the controller should prompt before navigation changes are allowed to complete.
        /// </summary>
        /// <param name="promptNavigationChange">Flag that determines if the navigation should be prompted before executing.</param>
        /// <param name="promptMessage">Optional parameter, sets the message to be displayed when prompting to leave.</param>
        public async Task PromptForNavigationChangeAsync(bool promptNavigationChange, string promptMessage = null)
        { 
            _blockNavigationChange = promptNavigationChange;

            if (_blockNavigationChange) 
            {
                await JSRuntime.InvokeVoidAsync(JavaScriptEnableNavigationPrompt, _controllerId);
            }
            else
            {
                await JSRuntime.InvokeVoidAsync(JavaScriptDisableNavigationPrompt, _controllerId);
            }
        }
    }
}
