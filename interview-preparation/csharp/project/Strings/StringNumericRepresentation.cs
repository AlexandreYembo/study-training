namespace project.Strings
{
    public class StringNumericRepresentation
    {
        public void Display()
        {
            int i = 0;
            string s = "108";
            bool result = int.TryParse(s, out i);
        }
    }
}