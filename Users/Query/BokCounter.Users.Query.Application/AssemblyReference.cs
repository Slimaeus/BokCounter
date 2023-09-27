using System.Reflection;

namespace BokCounter.Users.Query.Application;

public static class AssemblyReference
{
    public static Assembly Assembly => Assembly.GetExecutingAssembly();
}
