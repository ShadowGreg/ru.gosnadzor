namespace ru.gosnadzor.Model;

public class Answer:BaseAnswer
{
    public Answer()
    {
        
    }
    public Answer(string text, bool flag)
    {
        ThisAnswer = text;
        AnswerCorrect = flag;
    }

}