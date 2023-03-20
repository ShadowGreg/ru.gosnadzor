namespace UI.ViewModel.AnswersItems
{
    public class ExtensionAnswers:ColorField
    {
        public string Answer { get; }
        public bool IsCheck { get; set; }

        public ExtensionAnswers(string answer)
        {
            Answer = answer;
        }
    }
}