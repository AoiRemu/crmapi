using System.ComponentModel;

namespace CRM.Common.Helpers
{
    public static class EnumHelper
    {
        public static string GetDescription(this Enum enumValue)
        {
            string value = enumValue.ToString();
            System.Reflection.FieldInfo fieldInfo = enumValue.GetType().GetField(value);
            object[] objs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if(objs.Length == 0)
            {
                return value;
            }
            DescriptionAttribute desc = (DescriptionAttribute)objs[0];
            return desc.Description;
        }

        public static string GetDescription<T>(string value) where T : Enum
        {
            var enumValue = Enum.Parse(typeof(T) ,value) as Enum;
            return enumValue.GetDescription();
        }
    }
}
