using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp1
{
    [TypeConverter(typeof(EnumTypeConverter))]
    public enum Gender
    {
        [Description("Муж")]
        Male,
        [Description("Жен")]
        Female
    }

    public class GenderEnumConverterRu : IValueConverter
    {
        const string _female = "Женский";
        const string _male = "Мужской";
        const string _other = "Другой";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Gender[])
            {
                Gender[] arr = value as Gender[];
                object[] ret = new object[arr.Length];
                for (int i = 0; i < arr.Length; ++i)
                    ret[i] = Convert(arr[i], targetType, parameter, culture);
                return ret;
            }
            else if (value is Gender)
            {
                switch ((Gender)value)
                {
                    case Gender.Female: return _female;
                    case Gender.Male: return _male;
                    default: return _other;
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string[])
            {
                Gender[] arr = value as Gender[];
                object[] ret = new object[arr.Length];
                for (int i = 0; i < arr.Length; ++i)
                    ret[i] = Convert(arr[i], targetType, parameter, culture);
                return ret;
            }
            switch ((string)value)
            {
                case _female: return Gender.Female;
                case _male: return Gender.Male;
                default: return Gender.Male;
            }
        }
    }
}
