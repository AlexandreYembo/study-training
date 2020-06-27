namespace project.designPatterns
{
    public interface IBuilder
    {
        IBuilder Reset();
        IBuilder BuildCategory(Category category);
        IBuilder BuildName(string productName);
    }
}