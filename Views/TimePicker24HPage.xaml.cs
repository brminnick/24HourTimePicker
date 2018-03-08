using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TimePickerDemo.Views
{
    public partial class TimePicker24HPage : ContentPage
    {
        public TimePicker24HPage()
        {
            InitializeComponent();

            CustomPicker.Focused += (sender, e) => DisplayAlert("Focused Fired", "","Ok");
            CustomPicker.Unfocused += (sender, e) => DisplayAlert("Unfocused Fired", "", "Ok");
        }
    }
}
