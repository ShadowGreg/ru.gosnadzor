using System.Collections.Generic;
using ModelCore.Model.Entity.Abstract;
using ru.gosnadzor.Model;

namespace ru.gosnadzor.Convertor;

public interface IConvert
{
    public List<BaseQuestion> getQuestions();
}