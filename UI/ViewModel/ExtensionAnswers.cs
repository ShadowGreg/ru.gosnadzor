﻿namespace UI
{
    public class ExtensionAnswers
    {
        public string Answer { get; }
        public bool IsCheck { get; set; }

        public ExtensionAnswers(string answer)
        {
            Answer = answer;
        }
    }
}