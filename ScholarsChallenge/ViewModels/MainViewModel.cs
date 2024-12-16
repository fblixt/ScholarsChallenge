using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ScholarsChallenge.Services;
using System.Collections.ObjectModel;

namespace ScholarsChallenge.ViewModels
{
    public partial class MainViewModel(ResultService resultService) : BaseViewModel
    {
        private readonly ResultService _resultService = resultService;

        [ObservableProperty]
        ObservableCollection<ResultViewModel> results = [];

        [ObservableProperty]
        private ResultViewModel? currentResult;

        [ObservableProperty]
        private int currentIndex = 0;

        //[ObservableProperty]
        //private List<string> answerOptions = [];

        [ObservableProperty]
        private string? message;

        [ObservableProperty]
        private bool? showMessage = false;

        [ObservableProperty]
        private string? errorMessage;

        [ObservableProperty]
        private bool? showErrorMessage = false;

        [ObservableProperty]
        private bool showStartButton = true;

        [ObservableProperty]
        private bool showNextButton = false;

        [ObservableProperty]
        private bool showQuestions = false;

        [ObservableProperty]
        private bool showWelcome = true;

        [RelayCommand]
        public async Task Get()
        {
            Results.Clear();
            CurrentIndex = 0;

            var results = await _resultService.GetResults();

            if (results.Count == 0)
            {
                ShowWelcome = true;
                ShowStartButton = true;
                ShowQuestions = false;
                ShowErrorMessage = true;
                ErrorMessage = "Something went wrong, try again!";
                return;
            }

            foreach (var result in results)
            {
                Results.Add(new ResultViewModel(result));
            }

            if (Results.Count > 0)
            {
                CurrentResult = Results[CurrentIndex];
                ShowNextButton = true;
                ShowQuestions = true;
                ShowWelcome = false;
                ShowStartButton = false;
                ShowErrorMessage = false;
            }

            //await SetCurrentResult();
        }

        //[RelayCommand]
        //public async Task SetCurrentResult()
        //{
        //    if (CurrentIndex < Results.Count)
        //    {
        //        CurrentResult = Results[CurrentIndex];

        //        AnswerOptions = new ObservableCollection<string>(CurrentResult.IncorrectAnswers ?? [])
        //        {
        //            CurrentResult.CorrectAnswer ?? string.Empty
        //        };
        //        AnswerOptions = [.. AnswerOptions.OrderBy(x => Guid.NewGuid())];
        //    }
        //    await Task.CompletedTask;
        //}

        [RelayCommand]
        public void Next()
        {
            if (CurrentResult != null)
            {
                CurrentResult.SelectedAnswer = null;
                OnPropertyChanged(nameof(CurrentResult));
            }
            if (CurrentIndex < Results.Count - 1)
            {
                CurrentIndex++;
                CurrentResult = Results[CurrentIndex];
                ShowMessage = false;
                //await SetCurrentResult();
            }
            else
            {
                ShowNextButton = false;
                ShowStartButton = true;
                ShowQuestions = false;
                CurrentResult = null;
            }
        }

        [RelayCommand]
        private void SelectAnswer(string selectedAnswer)
        {
            if (CurrentResult != null)
            {
                CurrentResult.SelectedAnswer = selectedAnswer;
                ShowMessage = true;

                // Logik för att agera på valet, t.ex. omedelbar feedback eller statistik
                if (CurrentResult.IsCorrect)
                {
                    Message = "Correct!";
                }
                else
                {
                    Message = "Wrong answer!";
                }
                OnPropertyChanged(nameof(CurrentResult));
            }
        }

    }
}
