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
        TimePickerDialog _dialog;

        public CustomTimePicker24HRenderer(Context context) : base(context)
        {

        }

        Context CurrentContext => Plugin.CurrentActivity.CrossCurrentActivity.Current.Activity;
        IElementController ElementController => Element as IElementController;

        public void OnTimeSet(Android.Widget.TimePicker view, int hourOfDay, int minute)
        {
            var time = new TimeSpan(hourOfDay, minute, 0);
            Element.SetValue(TimePicker.TimeProperty, time);

            Control.Text = time.ToString(@"hh\:mm");

            ClearFocus();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e)
        {
            base.OnElementChanged(e);

            SetNativeControl(new Android.Widget.EditText(CurrentContext));

            if (Control != null)
            {
                Control.Click += Control_Click;
                Control.KeyListener = null;
                Control.FocusChange += Control_FocusChange;

                if (Element != null && !Element.Time.Equals(default(TimeSpan)))
                    Control.Text = Element.Time.ToString(@"hh\:mm");
                else
                    Control.Text = DateTime.Now.ToString("HH:mm");
            }
        }

        void Control_FocusChange(object sender, FocusChangeEventArgs e)
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

        void Control_Click(object sender, EventArgs e) => ShowTimePicker();

        void ShowTimePicker()
        {
            if (_dialog == null)
                _dialog = new TimePickerDialog(CurrentContext, this, DateTime.Now.Hour, DateTime.Now.Minute, true);

            _dialog.Show();
        }
    }
}
