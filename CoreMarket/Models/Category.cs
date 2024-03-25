﻿using System.ComponentModel.DataAnnotations;

namespace CoreMarket.Models;

public class Category:BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<Brand> brands { get; set; } = new List<Brand>();
}
