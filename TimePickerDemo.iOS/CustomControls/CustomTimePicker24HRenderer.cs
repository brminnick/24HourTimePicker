using System;

using Foundation;

using TimePickerDemo;
using TimePickerDemo.iOS;

using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomTimePicker24H), typeof(CustomTimePicker24HRenderer))]
namespace TimePickerDemo.iOS
{
    public class CustomTimePicker24HRenderer : TimePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var timePicker = (UIDatePicker)Control.InputView;
                timePicker.Locale = new NSLocale("no_nb");

                if (Element != null && !Element.Time.Equals(default(TimeSpan)))
                    Control.Text = Element.Time.ToString(@"hh\:mm");
                else
                    Control.Text = DateTime.Now.ToString("HH:mm");
            }
        }
	}
}