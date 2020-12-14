using Xamarin.Forms;
using Xamarin.CommunityToolkit.Markup;

namespace TimePickerDemo
{
    class TimePickerPage : ContentPage
    {
        public TimePickerPage()
        {
            BindingContext = new TimePicker24HViewModel();

            Title = "Time Picker";

            Content = new StackLayout
            {
                Children =
                {
                    new CustomTimePicker24H
                    {
                        TextColor = Color.Gray,
                        HeightRequest = 40,
                        Format = "HH:mm",
                    }.CenterExpand()
                     .Bind(TimePicker.TimeProperty, nameof(TimePicker24HViewModel.Time)),

                    new Label().CenterExpand().TextCenter()
                     .Bind(Label.TextProperty, nameof(TimePicker24HViewModel.TimeLabelText))
                }
            }.CenterExpand().Padding(30,0);
        }
    }
}
