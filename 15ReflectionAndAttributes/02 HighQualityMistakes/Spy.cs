namespace Stealer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    public class Spy
    {
        public string AnalyzeAccessModifiers(string investigation)
        {
            StringBuilder sb=new StringBuilder();

            Type classType= Type.GetType(investigation);

            FieldInfo[] fieldInfos=classType.GetFields(BindingFlags.Public | BindingFlags.Instance|BindingFlags.Static);
            MethodInfo[] publicMethods=classType.GetMethods(BindingFlags.Instance| BindingFlags.Public);
            MethodInfo[] noPubicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                sb.AppendLine($"{fieldInfo.Name } must be private!");
            }
            foreach (MethodInfo method in noPubicMethods.Where(m=>m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
            foreach (var method in publicMethods.Where(m=>m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
