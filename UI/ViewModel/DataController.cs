using System.Collections.Generic;
using ru.gosnadzor.Controller.CsvController;
using ru.gosnadzor.Convertor;
using ru.gosnadzor.Model;

namespace UI
{
    public class DataController
    {
        private readonly CsvConverter _csvConverter;
        private List<BaseQuestion> _questions;

        public DataController(string path)
        {
            _csvConverter = new CsvConverter(new CsvReadController(path),new BaseQuestion());
            _questions = _csvConverter.getQuestions();
        }

        public int GetQuestionsCount()
        {
            return _csvConverter.getQuestions().Count;
        }

        public string GetText()
        {
            return _questions[0].text;
        }
        public List<string> GetAnswers()
        {
            return _questions[0].answersInQuestion.GetAnswers();;
        }
    }
}