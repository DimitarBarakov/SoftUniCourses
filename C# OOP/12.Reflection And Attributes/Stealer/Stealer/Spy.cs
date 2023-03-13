using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string classToEnvestigate, params string[] fieldsToEnvestigate)
        {
            StringBuilder result = new StringBuilder();
            Type type = Type.GetType(classToEnvestigate);
            var hackerInst = Activator.CreateInstance(type);
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            result.AppendLine($"Class under investigation: {type.Name}");
            foreach (FieldInfo field in fields)
            {
                if (fieldsToEnvestigate.Contains(field.Name))
                {
                    result.AppendLine($"{field.Name} = {field.GetValue(hackerInst)}");
                }
            }

            return result.ToString().TrimEnd();
        }
        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder result = new StringBuilder();
            Type type = Type.GetType(className);
            var hackerInst = Activator.CreateInstance(type);
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
            foreach (var field in fields)
            {
                result.AppendLine($"{field.Name} must be private!");
            }
            MethodInfo[] publicMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var method in publicMethods.Where(m=>m.Name.StartsWith("get")))
            {
                result.AppendLine($"{method.Name} have to be public!");
            }
            MethodInfo[] nonPublicMethods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            foreach (var method in nonPublicMethods.Where(m=>m.Name.StartsWith("set")))
            {
                result.AppendLine($"{method.Name} have to be private!");
            }

            return result.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder result = new StringBuilder();

            Type hacker = Type.GetType(className);
            MethodInfo[] methods = hacker.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            result.AppendLine($"All Private Methods of Class: {className}");
            result.AppendLine($"Base Class: {hacker.BaseType.Name}");

            foreach (var method in methods)
            {
                result.AppendLine(method.Name);
            }

            return result.ToString().Trim();
        }

        public string CollectSettersAndGetters(string className)
        {
            StringBuilder result = new StringBuilder();

            Type hacker = Type.GetType(className);
            MethodInfo[] methods = hacker.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                .Where(m => m.Name.StartsWith("get") || m.Name.StartsWith("set"))
                .OrderBy(m=>m.Name)
                .ToArray();



            foreach (var method in methods)
            {
                if (method.Name.StartsWith("get"))
                {
                    result.AppendLine($"{method.Name} will return {method.ReturnType}");
                }
                else
                {
                    result.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
                }
            }
            return result.ToString().Trim();
        }
    }
}
