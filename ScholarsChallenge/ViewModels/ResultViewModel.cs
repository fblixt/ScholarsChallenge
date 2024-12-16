using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using ScholarsChallenge.Models;


namespace ScholarsChallenge.ViewModels
{
    public partial class ResultViewModel : BaseViewModel
    {
        public string Question { get; set; }
        public ObservableCollection<string> AnswerOptions { get; set; }

        [ObservableProperty]
        public string? selectedAnswer;

        public bool IsCorrect => SelectedAnswer == CorrectAnswer;

        private readonly string CorrectAnswer;

        public ResultViewModel(Result result)
        {
            if (result == null)
                throw new ArgumentNullException(nameof(result));

            Question = result.Question ?? string.Empty;
            AnswerOptions = new ObservableCollection<string>(result.IncorrectAnswers ?? [])
        {
            result.CorrectAnswer ?? string.Empty
        };
            AnswerOptions = [.. AnswerOptions.OrderBy(x => Guid.NewGuid())];
            CorrectAnswer = result.CorrectAnswer ?? string.Empty;
        }
    }

}
