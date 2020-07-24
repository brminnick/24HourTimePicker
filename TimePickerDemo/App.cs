using Xamarin.Forms;

namespace TimePickerDemo
{
    public class App : Application
    {
        public App()
        {
            Device.SetFlags(new[] { "Markup_Experimental" });
            MainPage = new NavigationPage(new TimePickerPage());
        }
    }
}
