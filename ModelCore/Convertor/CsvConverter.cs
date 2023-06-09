﻿using System.Collections.Generic;
using ModelCore.Model.Entity.Abstract;
using ru.gosnadzor.Controller.CsvController;
using ru.gosnadzor.Model;

namespace ru.gosnadzor.Convertor;

public class CsvConverter : IConvert
{
    private readonly ReadController _controller;
    private BaseQuestion _question;


    public CsvConverter(ReadController controller, BaseQuestion question)
    {
        this._controller = controller;
        this._question = question;
    }

    public List<BaseQuestion> getQuestions()
    {
        List<List<string?>> convertData = _controller.readFile();
        List<BaseQuestion> questions = new();
        while (convertData.Count != 0)
        {
            _question = new BaseQuestion();
            List<BaseAnswer> listAnswers = new();
            if (convertData[0][0] != "")
            {
                _question.Text = convertData[0][0];
                PutData(listAnswers, convertData);
            }

            while (convertData.Count != 0 && convertData[0][0] == "")
            {
                PutData(listAnswers, convertData);
            }

            _question.AnswersInQuestion = new Answers(listAnswers);
            questions.Add(_question);
        }

        void PutData(ICollection<BaseAnswer> baseAnswers, IList<List<string?>> list)
        {
            baseAnswers.Add(new Answer(list[0][1], GetFlag(list[0][2])));
            list.RemoveAt(0);
        }

        bool GetFlag(string? text)
        {
            return text == "r";
        }

        return questions;
    }
}