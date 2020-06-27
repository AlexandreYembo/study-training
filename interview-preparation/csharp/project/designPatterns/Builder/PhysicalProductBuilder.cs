namespace project.designPatterns.Builder
{
    public class PhysicalProductBuilder : IBuilder
    {
        public IBuilder BuildCategory(Category category)
        {
            throw new System.NotImplementedException();
        }

        public IBuilder BuildName(string productName)
        {
            throw new System.NotImplementedException();
        }

        public IBuilder Reset()
        {
            throw new System.NotImplementedException();
        }
    }
}