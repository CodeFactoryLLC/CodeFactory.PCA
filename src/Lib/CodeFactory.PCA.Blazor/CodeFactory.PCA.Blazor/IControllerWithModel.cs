namespace CodeFactory.PCA.Blazor
{

    /// <summary>
    /// Contract definition for the controller contracts, that also support a managed model.
    /// </summary>
    /// <typeparam name="M">Model data class managed by the controller.</typeparam>
    public interface IControllerWithModel<M>:IController where M : ModelBase
    {
        /// <summary>
        /// The model that is supported by the controller.
        /// </summary>
        M Model { get; set; }
    }
}
