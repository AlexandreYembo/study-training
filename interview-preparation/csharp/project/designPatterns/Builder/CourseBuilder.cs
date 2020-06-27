using System.Collections.Generic;

namespace project.designPatterns.Builder
{
   public class CourseBuilder : IBuilder
    {
        public CourseBuilder(Instructor instructor){
            Reset();
            course.Instructors.Add(instructor);
        }
        private Course course {get; set; }
        public IBuilder Reset()
        {
            course = new Course();
            return this;
        }
        public IBuilder BuildCategory(Category category)
        {
            course.Category = category;
            return this;
        }

        public IBuilder BuildName(string productName)
        {
            course.Name = productName;
            return this;
        }
    }
}