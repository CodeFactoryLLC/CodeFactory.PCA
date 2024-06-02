
using Microsoft.AspNetCore.Components;
using Telerik.Blazor;
using Telerik.Blazor.Components;
using CodeFactory.PCA.Blazor;

namespace CodeFactory.PCA.Blazor.Tel
{
    public partial class TelerikCentralNotification: CentralNotificationComponentBase
    {

        private TelerikNotification NotificationReference { get; set; }

        /// <summary>
        /// Allows to override the default styling set on the central notification. For documentation details see https://docs.telerik.com/blazor-ui/components/notification/appearance
        /// </summary>
        [Parameter]
        public string Class { get; set; } = "pca-central-telerik-notification";

        /// <summary>
        /// The animation type for notification. Takes the enum <see cref="Telerik.Blazor.AnimationType"/> default value is Fade.
        /// </summary>
        [Parameter]
        public AnimationType AnimationType { get; set; } = AnimationType.Fade;

        /// <summary>
        /// The vertical position the notification is displayed at. Takes the enum <see cref="Telerik.Blazor.Components.NotificationVerticalPosition"/> default value is Top.
        /// </summary>
        [Parameter]
        public NotificationVerticalPosition VerticalPosition { get; set; } = NotificationVerticalPosition.Top;

        /// <summary>
        /// The horizonal position the notification is displayed at. Takes the enum <see cref="Telerik.Blazor.Components.NotificationHorizontalPosition"/> default value is Center.
        /// </summary>
        [Parameter]
        public NotificationHorizontalPosition HorizontalPosition { get; set; } = NotificationHorizontalPosition.Center;

        /// <summary>
        /// Sets the CSS class that will be used by the notification.
        /// </summary>
        /// <returns>the current css class.</returns>
        private string SetClass() => Class;

        /// <summary>
        /// Sets the type of animation that will be used with the notification.
        /// </summary>
        /// <returns>Animation type.</returns>
        private AnimationType SetAnimationType() => AnimationType;

        /// <summary>
        /// Sets the horizonal position for the notification.
        /// </summary>
        /// <returns>Horizonal position.</returns>
        private NotificationHorizontalPosition SetHorizonalPosition() => HorizontalPosition;

        /// <summary>
        /// Sets the vertical position for the notification.
        /// </summary>
        /// <returns>vertical position.</returns>
        private NotificationVerticalPosition SetVerticalPosition() => VerticalPosition;
        




        public override Task ErrorNotificationAsync(string message, int timeout = 5000)
        {
            var model = new NotificationModel();

            model.Text = message;
            model.CloseAfter = timeout;
            model.ThemeColor = ThemeConstants.Notification.ThemeColor.Error;

            NotificationReference.Show(model);

            return Task.CompletedTask;
        }

        public override Task InformationNotificationAsync(string message, int timeout = 5000)
        {
            var model = new NotificationModel();

            model.Text = message;
            model.CloseAfter = timeout;
            model.ThemeColor = ThemeConstants.Notification.ThemeColor.Info;

            NotificationReference.Show(model);

            return Task.CompletedTask;
        }

        public override Task SuccessNotificationAsync(string message, int timeout = 5000)
        {
            var model = new NotificationModel();

            model.Text = message;
            model.CloseAfter = timeout;
            model.ThemeColor = ThemeConstants.Notification.ThemeColor.Success;

            NotificationReference.Show(model);

            return Task.CompletedTask;
        }

        public override Task WarningNotificationAsync(string message, int timeout = 5000)
        {
            var model = new NotificationModel();

            model.Text = message;
            model.CloseAfter = timeout;
            model.ThemeColor = ThemeConstants.Notification.ThemeColor.Warning;

            NotificationReference.Show(model);

            return Task.CompletedTask;
        }

    }
}
