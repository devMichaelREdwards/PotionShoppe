using System.Text.Json.Serialization;

namespace Api.Models;

public partial class OrderStatus
{
    public int OrderStatusId { get; set; }

    public string? Title { get; set; }

    [JsonIgnore]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
