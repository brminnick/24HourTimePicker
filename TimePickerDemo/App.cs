using Xamarin.Forms;

namespace TimePickerDemo
{
    public class App : Application
    {
        public App() => MainPage = new NavigationPage(new TimePickerPage());
    }
}
