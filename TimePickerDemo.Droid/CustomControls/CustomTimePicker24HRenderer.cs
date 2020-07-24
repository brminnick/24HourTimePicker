using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using TimePickerDemo;
using TimePickerDemo.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomTimePicker24H), typeof(CustomTimePicker24HRenderer))]
namespace TimePickerDemo.Droid
{
    public class CustomTimePicker24HRenderer : ViewRenderer<TimePicker, Android.Widget.EditText>, TimePickerDialog.IOnTimeSetListener, IJavaObject, IDisposable
    {
        TimePickerDialog? _dialog;

        public CustomTimePicker24HRenderer(Context context) : base(context)
        {

        }

        IElementController ElementController => Element;

        public void OnTimeSet(Android.Widget.TimePicker? view, int hourOfDay, int minute)
        {
            var time = new TimeSpan(hourOfDay, minute, 0);
            Element.SetValue(TimePicker.TimeProperty, time);

            Control.Text = time.ToString(@"hh\:mm");

            ClearFocus();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e)
        {
            base.OnElementChanged(e);

            SetNativeControl(new Android.Widget.EditText(Context));

            if (Control != null)
            {
                Control.Click += HandleClick;
                Control.FocusChange += HandleFocusChange;

                if (Element != null && Element.Time != default)
                    Control.Text = Element.Time.ToString(@"hh\:mm");
                else
                    Control.Text = DateTime.Now.ToString("HH:mm");
            }
        }

        void HandleFocusChange(object sender, FocusChangeEventArgs e)
        {
            if (e.HasFocus)
            {
                ShowTimePicker();
                ElementController.SetValueFromRenderer(VisualElement.IsFocusedPropertyKey, true);
            }
            else
            {
                ElementController.SetValueFromRenderer(VisualElement.IsFocusedPropertyKey, false);
            }
        }

        void HandleClick(object sender, EventArgs e) => ShowTimePicker();

        void ShowTimePicker()
        {
            _dialog ??= new TimePickerDialog(Context, this, Element.Time.Hours, Element.Time.Minutes, true);

            _dialog.UpdateTime(Element.Time.Hours, Element.Time.Minutes);

            _dialog.Show();
        }
    }
}
