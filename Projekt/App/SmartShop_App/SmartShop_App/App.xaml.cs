namespace SmartShop_App;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        MainPage = new AppShell();
        //MainPage = new LoginPage();
        //MainPage = new TabbedPages();
        
        //MainPage = new NavigationPage(new LoginPage());
    }
}
