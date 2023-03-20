namespace ru.gosnadzor.Model;

public abstract class BaseAnswer
{
    public string? ThisAnswer { get; set; }
    public bool AnswerCorrect { get; set; }
    
    public bool Equals(BaseAnswer answer)
    {
        return ThisAnswer == answer.ThisAnswer && AnswerCorrect == answer.AnswerCorrect;
    }
}