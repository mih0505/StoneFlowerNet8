using Domain.OrderModels;
using Microsoft.AspNetCore.Identity;

namespace Domain.Common;

public class User : IdentityUser<Guid>
{
    /// <summary>
    /// Имя сотрудника
    /// </summary>
    public PersonName WorkerName { get; set; }        
    public bool IsDeleted { get; set; }
    public DateTime Version { get; set; }
    

    public IEnumerable<Order> Orders { get; set; } = new List<Order>();
    public IEnumerable<Payment> Payments { get; set; } = new List<Payment>();        
}

