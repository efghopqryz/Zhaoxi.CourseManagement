using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Zhaoxi.CourseManagement.Converter
{
    public class GenderConverter : IValueConverter
    {
        //value：Model的值
        //parameter：RadioButton控件的IsChecked屬性中ConverterParameter的值
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null || parameter == null)
            {
                return false;
            }
            return value.ToString() == parameter.ToString();
        }

        //ConvertBack()是從View轉換回Model
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter;
        }
    }
}
