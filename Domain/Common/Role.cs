using Microsoft.AspNetCore.Identity;

namespace Domain.Common;

public class Role : IdentityRole<Guid>
{
    public string Description { get; set; }
}
