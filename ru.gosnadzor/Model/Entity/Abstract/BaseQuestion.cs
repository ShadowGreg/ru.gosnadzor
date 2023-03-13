namespace ru.gosnadzor.Model;

public class BaseQuestion
{
    public  string text { get; set; }
    public Answers answersInQuestion { get; set; }
    
    public override bool Equals(object question)
    {
        return text == ((BaseQuestion)question).text;
    }
}
