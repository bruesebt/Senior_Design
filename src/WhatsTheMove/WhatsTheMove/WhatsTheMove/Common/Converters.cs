using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using WhatsTheMove.Data.Models;
using System.Linq;
using System.IO;

namespace WhatsTheMove.UI.Common
{
    public class ComparisonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value?.Equals(parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value?.Equals(true) == true ? parameter : Binding.DoNothing;
        }
    }

    public class ByteArrayImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ImageSource imageSrc = null;
            if (value is Activity)
            {
                Activity activity = (Activity)value;
                imageSrc = ImageSource.FromUri(new Uri(activity.Icon));

                if (activity.Photos != null && activity.Photos.Any())
                {
                    byte[] array = activity.Photos.First().PhotoArray;
                    var stream = new MemoryStream(array);
                    imageSrc = ImageSource.FromStream(() => stream);
                }
            }            

            return imageSrc;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value?.Equals(true) == true ? parameter : Binding.DoNothing;
        }
    }
}
