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
    /// <summary>
    /// Base class that is implemented by all component based controllers.
    /// </summary>
    public abstract class ControllerBase :ComponentBase, IAsyncDisposable
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
        /// Identifier assigned to the controller. Used for java script execution.
        /// </summary>
        private readonly string _controllerId = Guid.NewGuid().ToString("D", CultureInfo.InvariantCulture);

        /// <summary>
        /// Dispose handler for location changing
        /// </summary>
        private IDisposable? _locationChangeSubscription;

        /// <summary>
        /// Flag that tracks if the user should be prompted before a navigation event occurs.
        /// </summary>
        private bool _promptForNavigationChange = false;

        /// <summary>
        /// The prompt message that should be displayed to the user.
        /// </summary>
        private string _promptMessage = DefaultPromptMessage;

        
        /// <summary>
        /// <see cref="IJSRuntime"/> service.
        /// </summary>
        [Inject]
        protected IJSRuntime JSRuntime { get; set; } = default!;

        /// <summary>
        /// <see cref="NavigationManager"/> service.
        /// </summary>
        [Inject]
        protected NavigationManager NavManager { get; set; } = default!;

        /// <summary>
        /// Parameter that registers a event callback that will be called by the controller to check a navigation change should be stopped.
        /// </summary>
        [Parameter]
        public EventCallback<NavigationCancelInfo> CheckStopNavigationChange { get; set; }

        /// <summary>
        /// Handles the <see cref="NavigationManager.LocationChanged"/> event from the navigation manager.
        /// </summary>
        /// <param name="context">The context of the location that is changing.</param>
        private async ValueTask OnLocationChanging(LocationChangingContext context)
        {

            if (_promptForNavigationChange & CheckStopNavigationChange.HasDelegate)
            {
                var cancelInfo = new NavigationCancelInfo();

                cancelInfo.PromptMessage = _promptMessage;

                await CheckStopNavigationChange.InvokeAsync(cancelInfo);

                if (cancelInfo.CancelNavigationChange) context.PreventNavigation();
            }
        }

        /// <summary>
        /// Subscribes to navigation change events and also tells the browser to prompt before navigation change events occur.
        /// </summary>
        private async Task SubscribeToNotificationsAsync()
        {
             _locationChangeSubscription  ??= NavManager.RegisterLocationChangingHandler(OnLocationChanging);

            await JSRuntime.InvokeVoidAsync(JavaScriptEnableNavigationPrompt, _controllerId);
        }

        /// <summary>
        /// Releases  navigation change events and also tells the browser to not prompt before navigation change events occur.
        /// </summary>
        private async Task ReleaseNotificationsAsync()
        {
            _locationChangeSubscription?.Dispose();

            try
            {
                await JSRuntime.InvokeVoidAsync(JavaScriptDisableNavigationPrompt, _controllerId);
            }
            catch (JSException)
            { 
                //Intentionally blank
            }
            
        }

        /// <summary>
        /// Triggers the disposal of resource consumed by this controller.
        /// </summary>
        /// <returns></returns>
        public virtual async ValueTask DisposeAsync()
        {
           
            await ReleaseNotificationsAsync();
             
        }

        /// <summary>
        /// Determines if the controller should prompt before navigation changes are allowed to complete.
        /// </summary>
        /// <param name="promptForNavigationChange">Flag that determines if the navigation should be prompted before executing.</param>
        /// <param name="promptMessage">Optional parameter, sets the message to be displayed when prompting to leave.</param>
        public async Task PromptForNavigationChangeAsync(bool promptForNavigationChange, string promptMessage = null)
        { 
            _promptForNavigationChange = promptForNavigationChange;

            _promptMessage = promptMessage ?? DefaultPromptMessage;

            if (_promptForNavigationChange) 
            {
                await SubscribeToNotificationsAsync();
            }
            else
            {
                await ReleaseNotificationsAsync();
            }
        }
    }
}
