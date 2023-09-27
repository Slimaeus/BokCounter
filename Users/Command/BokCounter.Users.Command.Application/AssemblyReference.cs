using System.Reflection;

namespace BokCounter.Users.Command.Application;

public static class AssemblyReference
{
    public static Assembly Assembly => Assembly.GetExecutingAssembly();
}
