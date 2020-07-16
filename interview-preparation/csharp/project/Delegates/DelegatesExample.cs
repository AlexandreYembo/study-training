using System;

namespace project.Delegates
{
    public class Photo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class DefaultDelegates
    {
        public delegate void PhotoFilterHandler(Photo photo);

        public void Process(string path, PhotoFilterHandler filterHandler){
            var photo = new Photo();
            photo.Name = "Photo Alex";

            filterHandler(photo);
        }
    }

     public class CustomDelegates
     {
        public void ProcessFilter(Photo photo){
            photo.Name = "First Delegate";
            Console.WriteLine(photo.Name);
        }
    }


    /// <summary>
    /// Class that implements delegate methods.
    /// </summary>
    public class DelegatesImplements 
    {
       public void Process(){
           var defaultDelegates = new DefaultDelegates();
           var customDelegates = new CustomDelegates();

            DefaultDelegates.PhotoFilterHandler filterHandler = customDelegates.ProcessFilter; //call the first delegate method
            filterHandler += ProcessFilter2;    //call the second delegate method

            defaultDelegates.Process("C:/", filterHandler);
       }

        private void ProcessFilter2(Photo photo)
        {
            photo.Name = "Second Delegate";
            Console.WriteLine(photo.Name);
        }
    }
}