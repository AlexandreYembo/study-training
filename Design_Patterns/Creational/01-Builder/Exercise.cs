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

namespace Design_Patterns.Creational.Builder.Exercise{
    public class Code{
        public string Name, Type;
    }
    
    public class CodeElement{
        private const int indentSize = 2;
        public Code code => new Code();
        public List<CodeElement> Elements = new List<CodeElement>();
      
        public CodeElement(){         
        }

        public CodeElement(string name, string type){
            code.Name = name;
            code.Type = type;
        }

        private string Generate(int indent){
            var sb = new StringBuilder();
            var i = new String(' ', indentSize * indent);
            sb.Append($"{i} {code.Type} {code.Name}\n");
            sb.Append("{\n");
            
            // if(!string.IsNullOrWhiteSpace(code.Type)){
            //     sb.Append(new string(' ', indentSize * (indent +1)));
            //     sb.Append(code.Type);
            //     sb.Append("\n");

            // }

            foreach(var e in Elements)
                sb.Append(e.Generate(indent +1));

            sb.Append("}\n");
        }
    }

    public class CodeBuilder{
        CodeElement classElement = new CodeElement();
        private readonly string rootName;
        protected Code code = new Code();

        public CodeBuilder(string rootName){
            this.rootName = rootName;
            classElement.code.Name = rootName;
            classElement.code.Type = "class";
        }

         public CodeBuilder AddField(string name, string type){
            var fieldElement = new CodeElement(name, type);
            classElement.Elements.Add(fieldElement);
            return this;
        }

        public override string ToString() => classElement.ToString();
    }
   
    internal class Implement{
         public static void Main(string[] args){
             var cb = new CodeBuilder()
         }
    }
}