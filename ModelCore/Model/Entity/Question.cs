using ModelCore.Model.Entity.Abstract;

namespace ru.gosnadzor.Model;

public class Question:BaseQuestion
{
    public Question(string? text, Answers? answers)
    {
        base.Text = text;
        base.AnswersInQuestion = answers;
    }
}