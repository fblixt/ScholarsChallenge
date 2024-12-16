using System.Globalization;

namespace ScholarsChallenge.Converters
{
    public class AnswerColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            //var selectedAnswer = value as string;
            //var correctAnswer = parameter as string;

            //if (selectedAnswer == correctAnswer)
            //    return Colors.Green;
            //else if (!string.IsNullOrEmpty(selectedAnswer))
            //    return Colors.Red;
            //else
            //    return Colors.Transparent; 

            if (value is not string selectedAnswer || parameter is not string currentAnswer)
                return Colors.Blue; // Neutral färg om något är fel

            return selectedAnswer == currentAnswer
                ? Colors.Green // Om rätt svar
                : Colors.Red;  // Om fel svar
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
