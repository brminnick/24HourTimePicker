using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using TimePickerDemo.iOS;
using Foundation;
using TimePickerDemo.CustomControls;

[assembly: ExportRenderer(typeof(CustomTimePicker24H), typeof(CustomTimePicker24HRenderer))]
namespace TimePickerDemo.iOS
{
    public class CustomTimePicker24HRenderer : TimePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e)
        {
            base.OnElementChanged(e);
            var timePicker = (UIDatePicker)Control.InputView;
            timePicker.Locale = new NSLocale("no_nb");

            if (Control != null)
            {
                Control.Text = DateTime.Now.ToString("HH:mm");
            }
        }
    }
}