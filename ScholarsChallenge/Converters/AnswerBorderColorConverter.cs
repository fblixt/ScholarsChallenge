using System.Globalization;

namespace ScholarsChallenge.Converters
{
    public class AnswerBorderColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            //if (value == null) return Colors.Transparent;

            //string selectedAnswer = value as string;
            //string correctAnswer = parameter as string;

            //if (selectedAnswer == correctAnswer)
            //    return Colors.Green;
            //else
            //    return Colors.Transparent;

            if (value is not string selectedAnswer) return Colors.Transparent;
            if (parameter is not string correctAnswer) return Colors.Yellow;
            if (selectedAnswer == correctAnswer) return Colors.Green;
            return Colors.Red;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
