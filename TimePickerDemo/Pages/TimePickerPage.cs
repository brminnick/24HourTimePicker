using Xamarin.Forms;

namespace TimePickerDemo
{
    public class TimePickerPage : ContentPage
    {
        public TimePickerPage()
        {
            BindingContext = new TimePicker24HViewModel();

            var timePicker = new CustomTimePicker24H
            {
                TextColor = Color.Gray,
                HeightRequest = 40,
                Format = "HH:mm",
                VerticalOptions = LayoutOptions.StartAndExpand,
            };
            timePicker.SetBinding(TimePicker.TimeProperty, nameof(TimePicker24HViewModel.Time));

            var timeLabel = new Label();
            timeLabel.SetBinding(Label.TextProperty, nameof(TimePicker24HViewModel.TimeLabelText));

            Title = "Time Picker";

            Content = new StackLayout
            {
                Padding = new Thickness(30, 80, 30, 0),
                Spacing = 40,
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children = {
                    timePicker,
                    timeLabel
                }
            };
        }
    }
}
