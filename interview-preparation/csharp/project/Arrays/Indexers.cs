namespace project.Arrays
{
    public class IndexerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class IndexerDemo
    {
        public void Test()
        {
            var idx = new Indexers<IndexerModel>();
            idx[0] = new IndexerModel {Id = 1, Name = "Alex1"};
            idx[1] = new IndexerModel {Id = 2, Name = "Alex2"};
            idx[0].Name = "Alex1 - Altered";
        }
    }
    public class Indexers<T> 
    {
        private T[] array = new T[100];

        public T this[int i]
        {
            get => array[i];
            set => array[i] = value;
        }
    }
}