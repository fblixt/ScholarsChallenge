namespace ScholarsChallenge.ViewModels
{
    public class CheckViewModel : BaseViewModel
    {
        public int CorrectAnswers { get; set; }
        public int TotalResults { get; set; }

        public CheckViewModel(List<ResultViewModel> results)
        {
            TotalResults = results.Count;
            CorrectAnswers = results.Count(r => r.IsCorrect);
        }
    }
}
