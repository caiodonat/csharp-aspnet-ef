using CAE.Domain.Entities;

namespace CAE.Domain.DTOs;

[ActivatorUtilitiesConstructor]
public class CreateUserDTO : User
{
	[Obsolete("To be set only in database", true)]
	int? Id { get; }
	
	// [Obsolete("Not require Relationships for this DTO", true)]
	// ICollection<Section>? Sections { get; }
}