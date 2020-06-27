using System.Collections.Generic;

namespace project.designPatterns
{
    public class Product
    {
        public int Id { get; set; }
        public string Name {get; set; }
        public Category Category { get; set; }
        public IEnumerable<Sku> Skus {get; set; }
    }

    public class Course {
        public int Id {get; set;}
        public string Name {get;set;}
        public Category Category {get;set;}
        public IList<Instructor> Instructors {get;set;}
    }

    public class Category {
        public int Id {get;set;}
        public string Name {get;set;}
    }

    public enum ETypeProduct{
        Physical = 0,
        Virtual = 1,
        Vourcher = 2,
        Course = 3
    }

    public class Sku{
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class Instructor : Person {
        public string GraduationDetail { get; set; }
    }

    public abstract class Person {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
}