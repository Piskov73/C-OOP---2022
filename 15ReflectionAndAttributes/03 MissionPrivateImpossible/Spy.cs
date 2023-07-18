namespace Stealer
{
    using System;
    using System.Reflection;
    using System.Text;
    public class Spy
    {
        public Spy()
        {

        }
        public string RevealPrivateMethods(string investigationClass)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(investigationClass);
            MethodInfo[] methodInfos = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            sb.AppendLine($"All Private Methods of Class: {investigationClass}")
                .AppendLine($"Base Class: {classType.BaseType.Name}");
            foreach ( MethodInfo methodInfo in methodInfos )
            {
                sb.AppendLine(methodInfo.Name );
            }

            return sb.ToString().TrimEnd();
        }

    }
}
