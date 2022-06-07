namespace Ssp.Digital.Meter.Api.Models;

public class User
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier. AAD Object ID.
    /// </value>
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the email.
    /// </summary>
    /// <value>
    /// The email from JWT.
    /// </value>
    public string? Email { get; set; }

    /// <summary>
    /// Gets or sets the username.
    /// </summary>
    /// <value>
    /// The username from JWT.
    /// </value>
    public string? Username { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether [email verified].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [email verified]; otherwise, <c>false</c>.
    /// </value>
    public bool EmailVerified { get; set; }
}