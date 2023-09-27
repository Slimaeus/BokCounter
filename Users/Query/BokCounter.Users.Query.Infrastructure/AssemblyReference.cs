using System.Reflection;

namespace BokCounter.Users.Query.Infrastructure;

public static class AssemblyReference
{
    public static Assembly Assembly => Assembly.GetExecutingAssembly();
}
