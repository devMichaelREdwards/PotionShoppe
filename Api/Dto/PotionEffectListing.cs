using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Api.Models;

public partial class PotionEffectListing
{
    public string? Title { get; set; }
    public string? Color { get; set; }
}
