namespace Restaurant.Society.Application.Admin.Actions
{
    public class ActionResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is successful.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is successful; otherwise, <c>false</c>.
        /// </value>
        public bool? IsSuccessful { get; set; }

        /// <summary>Gets or sets the message of the integration result.</summary>
        /// <value>The message.</value>
        public string? Message { get; set; }

        /// <summary>
        /// Gets or sets the UserIds to notify
        /// </summary>
        public List<Guid>? UserIdsToNotify { get; set; } = new List<Guid>();

        /// <summary>Gets or sets the operation.</summary>
        /// <value>The operation.</value>
        public string? Operation { get; set; }

        /// <summary>Gets or sets the resources.</summary>
        /// <value>The resources.</value>
        public string? Resources { get; set; }
    }

    /// <summary>
    /// Base generic response for the IntegrationAPI
    /// </summary>
    /// <typeparam name="T">Response model</typeparam>
    public class ActionResponse<T> : ActionResponse where T : class
    {
        /// <summary>
        /// Generic response 
        /// </summary>
        public T? Model { get; set; }
    }
}
