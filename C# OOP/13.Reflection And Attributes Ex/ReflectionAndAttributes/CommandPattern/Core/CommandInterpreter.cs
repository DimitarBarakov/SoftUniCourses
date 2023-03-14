using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string command)
        {
            string[] splittedCommand = command.Split(" ");
            string[] commandArgs = splittedCommand.Skip(1).ToArray();
            string commandName = splittedCommand[0];

            Assembly assembly = Assembly.GetExecutingAssembly();
            Type cmdType = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name == $"{commandName}Command");
            MethodInfo method = cmdType.GetMethod("Execute");
            var cmdtypeInst = Activator.CreateInstance(cmdType);

            string res = method.Invoke(cmdtypeInst, new object[] { commandArgs }).ToString();

            return res;
        }
    }
}
