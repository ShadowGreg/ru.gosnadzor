using System;
using System.Collections.Generic;
using ru.gosnadzor.Controller.CsvController;
using ru.gosnadzor.Convertor;
using ru.gosnadzor.Model;

namespace UI
{
    public class DataController
    {
        // TODO Вопрос надо сделать лист в который пердаются по порядку просмотренные вопросы
        // TODO Вопрос как
        // TODO Вопрос как
        private readonly CsvConverter _csvConverter;
        private readonly List<BaseQuestion> _questions;
        private BaseQuestion _outQuestion;
        private List<BaseQuestion> _repliedQuestions;
        private int rnd;


        public DataController(string path)
        {
            _csvConverter = new CsvConverter(new CsvReadController(path),new BaseQuestion());
            _questions = _csvConverter.getQuestions();
            _repliedQuestions = new List<BaseQuestion>();
        }

        public int GetQuestionsCount()
        {
            return _csvConverter.getQuestions().Count;
        }

        public DataController GetQuestion()
        {
            rnd = new Random().Next(_questions.Count);
            _outQuestion = _questions[rnd];
            _repliedQuestions.Add(_questions[rnd]);
            _questions.RemoveAt(rnd);
            return this;
        }

        public string GetText()
        {
            GetQuestion();
            return _outQuestion.text;
        }
        public List<string> GetAnswers()
        {
            return _outQuestion.answersInQuestion.GetAnswers();;
        }
    }
}