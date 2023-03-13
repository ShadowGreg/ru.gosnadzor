using System.Collections.Generic;
using ru.gosnadzor.Model;

namespace ru.gosnadzor.Convertor;

public interface IConvert
{
    public List<BaseQuestion> getQuestions();
}