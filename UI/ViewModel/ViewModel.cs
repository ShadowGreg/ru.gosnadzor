using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using ru.gosnadzor.Model;
using UI.ViewModel.AnswersItems;

namespace UI.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        private int _questionCount;
        private int _questions;
        private static string filename;
        private static DataController _dataController;

        public int QuestionCount
        {
            get => _questionCount;
            private set
            {
                _questionCount = value;
                OnPropertyChanged();
            }
        }

        public int Questions
        {
            get => _questions;
            set
            {
                _questions = value;
                OnPropertyChanged();
            }
        }

        private void SetCount()
        {
            Questions = _dataController.GetQuestionsCount();
        }

        public string QuestionText
        {
            get => _questionText;
            private set
            {
                _questionText = _dataController ==
                                null
                    ? Text.StartText
                    : _dataController.GetText();
                OnPropertyChanged();
            }
        }

        private ObservableCollection<ExtensionAnswers> _someList = new ObservableCollection<ExtensionAnswers>()
        {
            new ExtensionAnswers(Text.StartQuestion)
        };

        public ObservableCollection<ExtensionAnswers> SomeList
        {
            get => _someList;
            private set
            {
                _someList = value;
                OnPropertyChanged(nameof(SomeList));
            }
        }

        private static ObservableCollection<ExtensionAnswers> GetValue()
        {
            ObservableCollection<ExtensionAnswers> output = new ObservableCollection<ExtensionAnswers>();
            List<string> tempValue = _dataController.GetAnswers();
            for (int index = 0; index < tempValue.Count; index++)
            {
                string t = tempValue[index];
                ExtensionAnswers cb = new ExtensionAnswers(tempValue[index]);

                output.Add(cb);
            }

            return output;
        }

        private string _questionText;

        public readonly DependencyProperty TopicListProperty =
            DependencyProperty.Register(nameof(SomeList), typeof(ObservableCollection<CheckBox>), typeof(MainWindow),
                new UIPropertyMetadata(null));

        public ViewModel()
        {
            QuestionText = GetQuestionText();
        }

        public string GetQuestionText()
        {
            return "Привет это тестовый текст";
        }

        protected internal void PreviewClick(object sender, RoutedEventArgs e)
        {
            const string messageBoxText = "Do you want to save changes?";
            const string caption = "Word Processor";
            const MessageBoxButton button = MessageBoxButton.OK;
            const MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result;

            result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
        }

        private DelegateCommand _setAnswers;

        public DelegateCommand SetAnswers
        {
            get
            {
                return _setAnswers ?? (_setAnswers = new DelegateCommand(obj =>
                    {
                        // TODO делаем овтеты и сравнение с объектами ответов
                        // TODO получается нужен ещё контроллер состояния кнопок
                        Answers answersInQuestion =_dataController.OutQuestion.AnswersInQuestion;
                        ObservableCollection<ExtensionAnswers> FillingModelObjects = ((ViewModel)_setAnswers.Execute().Target).SomeList;
                        for (int i = 0; i < FillingModelObjects.Count; i++)
                        {
                            if (answersInQuestion.IsAnswerCorrect(FillingModelObjects[i].Answer))
                            {
                                FillingModelObjects[i].Color = AnswerColors.Green.ToString();
                            }
                            else
                            {
                                FillingModelObjects[i].Color = AnswerColors.Red.ToString();
                            }
                        }
                        object temp = obj;
                        int questions = _questions;
                    }
                    ));
            }
        }

        private DelegateCommand _nextQuestion;

        public DelegateCommand NextQuestion
        {
            get
            {
                return _nextQuestion ?? (
                    _nextQuestion = new DelegateCommand(obj =>
                    {
                        
                        // TODO делаем возможность переключения вперёд и где то обработчик должен быть про кнопку назад
                        _dataController = _dataController.GetQuestion();
                        QuestionText = _dataController.GetText();
                        SomeList = GetValue();
                        QuestionCount += 1;
                    })
                );
            }
        }


        private DelegateCommand _loadTickets;

        public DelegateCommand LoadTickets
        {
            get
            {
                return _loadTickets ?? (
                    _loadTickets = new DelegateCommand(obj =>
                    {
                        Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog
                        {
                            FileName = "Document",
                            DefaultExt = ".csv",
                            Filter = "Csv documents (.csv)|*.csv"
                        };

                        bool? result = dlg.ShowDialog();

                        if (result == true)
                        {
                            filename = dlg.FileName;
                        }

                        _dataController = new DataController(filename);
                        SetCount();
                        _dataController = _dataController.GetQuestion();
                        QuestionText = _dataController.GetText();
                        SomeList = GetValue();
                        QuestionCount = 0;
                        QuestionCount += 1;
                    })
                );
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}