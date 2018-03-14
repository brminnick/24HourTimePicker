using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TimePickerDemo
{
    public class TimePicker24HViewModel : INotifyPropertyChanged
    {
        TimeSpan _time;
        string _timeLabelText;

        public TimePicker24HViewModel() => _time = new TimeSpan(5, 20, 0);

		public event PropertyChangedEventHandler PropertyChanged;

		public string TimeLabelText => _timeLabelText;

        public TimeSpan Time
        {
            get => _time;
            set
            {
                _time = value;
                OnPropertyChanged();
                _timeLabelText = value.ToString(@"hh\:mm");
                OnPropertyChanged(nameof(TimeLabelText));
            }
        }

        void OnPropertyChanged([CallerMemberName] string propertyName = "") => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
