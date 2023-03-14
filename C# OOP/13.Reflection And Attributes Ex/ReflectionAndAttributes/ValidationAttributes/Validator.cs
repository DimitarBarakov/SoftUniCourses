using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] validationProperties = type.GetProperties()
                .Where(p=>p.CustomAttributes.Any(a=>a.AttributeType.BaseType == typeof(MyValidationAttribute)))
                .ToArray();
            foreach (PropertyInfo property in validationProperties)
            {
                object propertyValue = property.GetValue(obj);

                foreach (var attr in property.CustomAttributes)
                {
                    Type attrType = attr.GetType();
                    var attrInst = property.GetCustomAttribute(attrType);

                    MethodInfo method = attrType.GetMethods().FirstOrDefault(m => m.Name == "IsValid");

                    bool res = (bool)method.Invoke(attrInst, new object[] {propertyValue});
                    if (!res)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
