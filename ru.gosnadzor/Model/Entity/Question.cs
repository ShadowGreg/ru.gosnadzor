namespace ru.gosnadzor.Model;

public class Question:BaseQuestion
{
    public Question(string text, Answers answers)
    {
        base.text = text;
        base.answersInQuestion = answers;
    }
}