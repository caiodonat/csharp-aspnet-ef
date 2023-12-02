using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// using System.Text.Json.Serialization;

namespace CAE.Domain.Entities;

[Table("users")]
public class User
{
	[Key]
	[Column("id", Order = 0)]
	[Description("auto increment, unique")]
	public int? Id { get; set; }

	[Column("first_name")]
	public required string FirstName { get; set; }

	[Column("last_name")]
	public string? LastName { get; set; }

	[Column("email")]
	[Description("unique")]
	public required string Email { get; set; }

	[Column("password")]
	public required string Password { get; set; }

	// [Column("sections")]
	// [JsonIgnore]
	// public ICollection<Section> Sections { get; set; } = new List<Section>();
}