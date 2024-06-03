namespace CodeFactory.PCA.Blazor
{
    /// <summary>
    /// Extensions that support PCA for blazor
    /// </summary>
    public static class BlazorExtensions
    {

        /// <summary>
        /// Registers the services used by the PCA blazor framework.
        /// </summary>
        /// <param name="services">Service collection to register to.</param>
        /// <returns>Updated service collection.</returns>
        public static IServiceCollection AddPCAServices(this IServiceCollection services)
        {
            services.AddScoped<INotificationService>(sp => new NotificationService());
            services.AddScoped<IDialogService>(sp => new DialogService());
            return services;
        }
    }
}
