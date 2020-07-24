using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TimePickerDemo
{
    public class TimePicker24HViewModel : INotifyPropertyChanged
    {
        TimeSpan _time;

        public TimePicker24HViewModel() => _time = new TimeSpan(5, 20, 0);

        public event PropertyChangedEventHandler? PropertyChanged;

        public string TimeLabelText => Time.ToString(@"hh\:mm");

        public TimeSpan Time
        {
            get => _time;
            set
            {
                _time = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TimeLabelText));
            }
        }

        void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
