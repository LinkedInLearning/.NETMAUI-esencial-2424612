using System.Globalization;

namespace WisdomPetMedicine.Converters;
public class PriceToColorConverter : IValueConverter
{
    public object Convert(object value, 
        Type targetType, object parameter, CultureInfo culture)
    {
        var price = (decimal)value;
        if (price >= 0 && price <= 99)
        {
            return Colors.Green;
        }
        return Colors.Red;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}