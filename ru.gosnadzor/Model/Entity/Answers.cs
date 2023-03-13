using System.Collections.Generic;
using System.Linq;

namespace ru.gosnadzor.Model;

public class Answers
{
    private readonly Dictionary<BaseAnswer, Flags> _choices;

    public Answers(List<BaseAnswer>? answers)
    {
        _choices = new Dictionary<BaseAnswer, Flags>();
        foreach (BaseAnswer answer in answers)
        {
            _choices.Add(answer, Flags.EMPTY);
        }
    }

    public List<string> GetAnswers()
    {
        Dictionary<BaseAnswer, Flags>.KeyCollection answers = KeyCollection;
        List<string> textAnswers = answers.Select(answer => answer.ThisAnswer).ToList();
        return textAnswers;
    }

    private Dictionary<BaseAnswer, Flags>.KeyCollection KeyCollection
    {
        get
        {
            Dictionary<BaseAnswer, Flags>.KeyCollection answers = _choices.Keys;
            return answers;
        }
    }

    public bool IsAnswerCorrect(string selectedAnswer)
    {
        Dictionary<BaseAnswer, Flags>.KeyCollection answers = KeyCollection;

        void setFlags()
        {
            foreach (BaseAnswer answer in answers)
            {
                _choices[answer] = Flags.WRONG;
            }
        }

        setFlags();
        
        foreach (BaseAnswer answer in answers.Where(answer => answer.AnswerCorrect && answer.ThisAnswer == selectedAnswer))
        {
            _choices[answer] = Flags.RIGHT;
            return true;
        }

        return false;
    }

    public bool IsCorrectlyBefore()
    {
        Dictionary<BaseAnswer, Flags>.KeyCollection answers = KeyCollection;
        return answers.Any(answer => answer.AnswerCorrect && _choices[answer] == Flags.RIGHT);
    }
}