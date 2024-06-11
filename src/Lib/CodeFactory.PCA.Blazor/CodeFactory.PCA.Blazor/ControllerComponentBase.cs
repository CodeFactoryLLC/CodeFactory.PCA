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
    public abstract class ControllerComponentBase :ComponentBase, IAsyncDisposable,IController,IPresentationCallback
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
        /// Injecting notification service into the controller.
        /// </summary>
        [Inject]
        private INotificationService NotificationService { get; set; }

        /// <summary>
        /// Injecting the dialog service into the controller.
        /// </summary>
        [Inject]
        private IDialogService DialogService { get; set; }


        /// <summary>
        /// Service that allows you to raise a notification to the central notification handler.
        /// </summary>
        protected INotificationSubmission CentralNotification => NotificationService;

        /// <summary>
        /// Service that allows you to raise a dialog to the central dialog handler. 
        /// </summary>
        protected IDialogSubmission CentralDialog => DialogService;


         /// <inheritdoc/>
        protected override void OnAfterRender(bool firstRender)
        {
            try
            {
                if (firstRender) InitializeController();
            }
            finally
            {
                base.OnAfterRender(firstRender);
            }
            
        }


        /// <summary>
        /// Initialization logic for the controller during the first render of the controller.
        /// </summary>
        protected virtual void InitializeController()
        { 
            //Intentionally blank
        }

        /// <inheritdoc/>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

                if (firstRender) await InitializeControllerAsync(); 

                await base.OnAfterRenderAsync(firstRender);
        }

        /// <summary>
        /// Initialization logic for the controller during the first render of the controller.
        /// </summary>
        protected virtual Task InitializeControllerAsync()
        { 
            return Task.CompletedTask;
        }

        /// <summary>
        /// Handles the <see cref="NavigationManager.LocationChanged"/> event from the navigation manager.
        /// </summary>
        /// <param name="context">The context of the location that is changing.</param>
        protected virtual async ValueTask OnLocationChanging(LocationChangingContext context)
        {

            if (_promptForNavigationChange)
            {
                var cancelInfo = new NavigationCancelInfo();

                cancelInfo.PromptMessage = _promptMessage;

                var stayOnPage = await CentralDialog.RaiseConfirmationAsync(_promptMessage, "Sure you want to leave?", "Leave Page", "Stay");

                if (stayOnPage) context.PreventNavigation();
            }
        }

        /// <summary>
        /// Subscribes to navigation change events and also tells the browser to prompt before navigation change events occur.
        /// </summary>
        private async Task SubscribeToNotificationsAsync()
        {
             _locationChangeSubscription = NavManager.RegisterLocationChangingHandler(OnLocationChanging);

            await JSRuntime.InvokeVoidAsync(JavaScriptEnableNavigationPrompt, _controllerId);
        }

        /// <summary>
        /// Releases  navigation change events and also tells the browser to not prompt before navigation change events occur.
        /// </summary>
        private async Task ReleaseNotificationsAsync()
        {
            

            try
            {
                _locationChangeSubscription?.Dispose();
                _locationChangeSubscription = null;
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
