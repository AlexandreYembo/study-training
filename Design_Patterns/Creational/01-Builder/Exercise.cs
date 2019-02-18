/*
You are asked to implement the Builder design pattern for rendering simple chunks of code.
Sample use of the builder you are asked to create:

    var cb = new CodeBuilder("Person").AddField("Name", "String").AddField("Age", "int")
    Console.Write(cb);

The expected output of the above code is:
    public class Person
    {
        public string Name;
        public int Age;
    }

 */

using System;
using System.Collections.Generic;
using System.Text;

using System;
using System.Collections.Generic;

namespace Test
{

    class Field
    {
      public string Type, Name;

      public override string ToString() => $"public {Type} {Name}";
    }

    class Class
    {
      public string Name;
      public List<Field> Fields = new List<Field>();

      public Class(){}

      public override string ToString()
      {
        var sb = new StringBuilder();
        sb.AppendLine($"public class {Name}").AppendLine("{");
        
        foreach (var f in Fields)
          sb.AppendLine($"  {f};");
        
        sb.AppendLine("}");
        
        return sb.ToString();
      }
    }

    public class CodeBuilder{
        private Class oClass = new Class();
        
        public CodeBuilder(string rootName){
            oClass.Name = rootName;
        }
        
        public CodeBuilder AddField(string name, string type){
            oClass.Fields.Add(new Field{Name = name, Type = type});
            return this;
        }

        public override string ToString() =>  this.oClass.ToString();
    }


    public class Implement
    {
        static void Run(string[] args)
        {
            var cb = new CodeBuilder("Person").AddField("Name", "String").AddField("Age", "int");
            System.Console.Write(cb);
        }
    }
}
