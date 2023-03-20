using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UI.ViewModel.AnswersItems
{
    public abstract class ColorField: INotifyPropertyChanged
    {

        private string _color = AnswerColors.LightGray.ToString();
        public string Color
        {
            get => _color;
            set
            {
                _color = value.ToString();
                OnPropertyChanged(nameof(Color));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}