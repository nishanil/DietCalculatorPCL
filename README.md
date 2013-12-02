DietCalculatorPCL
======================

DietCalculator built for 4 mobile platforms(iOS, Android, Windows Phone, Windows Store Apps) using shareable codebase in Portable Class Libraries.

##About Diet Calculator


DietCalculator is a Silverlight MVC application written few years ago that calcuates daily diet requirements based on few inputs from the user. [Check this blog](http://www.silverlightshow.net/items/Exploring-the-Model-View-Controller-MVC-pattern.aspx )


##Port to Mobile 

Many .NET developers working on the Windows platform don’t realize that lots of existing .NET code can easily be ported to all the popular mobile platforms, including iOS and Android. Almost any .NET codebase, including Windows Forms, WPF, ASP.NET, and Silverlight, has sharable code that can be ported to Xamarin.iOS, Xamarin.Android, Windows Phone & Windows Store. 

This project demonstrates the re-use of platform agnostic C# code on all the major platforms.

Refer these blogs for detailed explanation:

- [Porting existing .NET apps to iOS](http://blog.xamarin.com/porting-existing-.net-apps-to-ios/)
- [Porting existing .NET apps to Android](http://blog.xamarin.com/porting-existing-.net-apps-to-android/)
- [Porting existing .NET apps to four mobile platforms](http://blog.xamarin.com/porting-existing-.net-apps-to-four-mobile-platforms-with-pcl/)

##Requirements for building the project

WINRT and WP project uses the following libraries from Nuget:

- [WINRT XAML Toolkit](http://www.nuget.org/packages/winrtxamltoolkit/)
- [Windows Phone Toolkit](http://www.nuget.org/packages/WPToolkit/)

Please update them before compiling:

- Right click on the Solution node in Solution Explorer and select **Enable NuGet Package Restore**.
- Clean and Re-build the solution

If you are stuck, let me know - [@nishanil](http://twitter.com/NishAnil)


