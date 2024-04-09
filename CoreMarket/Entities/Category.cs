using System.ComponentModel.DataAnnotations;
using CoreMarket.EntitiesContracts;

namespace CoreMarket.Models;

public class Category:BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public List<Brand> brands { get; set; } = new List<Brand>();
}
