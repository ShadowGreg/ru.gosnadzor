using ru.gosnadzor.Model;

namespace ModelCore.Model.Entity.Abstract;

public class BaseQuestion
{
    public  string? Text { get; set; }
    public Answers? AnswersInQuestion { get; set; }
    
    public override bool Equals(object question)
    {
        return Text == ((BaseQuestion)question).Text;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
