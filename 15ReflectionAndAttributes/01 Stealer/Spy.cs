namespace Stealer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    public class Spy
    {
        public string StealFieldInfo(string investigateClass, params string[] researchFields)
        {
            StringBuilder sb = new StringBuilder();
            Type typeClass = Type.GetType(investigateClass);
            FieldInfo[] fieldInfo = typeClass.GetFields
                (BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

            Object classInstane = Activator.CreateInstance(typeClass, new object[] { });

            sb.AppendLine($"Class under investigation: {investigateClass}");
            foreach (FieldInfo field in fieldInfo.Where(f => researchFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstane)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
