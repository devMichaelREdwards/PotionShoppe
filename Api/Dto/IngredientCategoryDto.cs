namespace Api.Models;

public partial class IngredientCategoryDto : IDto<IngredientCategory>
{
    public int? IngredientCategoryId { get; set; }

    public string? Title { get; set; }

    public bool Equals(IngredientCategory? other)
    {
        return other?.IngredientCategoryId == IngredientCategoryId && other?.Title == Title;
    }

    public void Update(IngredientCategory dest)
    {
        dest.Title = Title;
    }
}
