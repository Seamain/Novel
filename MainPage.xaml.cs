using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Novel2.Data;
using Novel2.Pages;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace Novel2
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void NvSample_OnItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                MainPageFrame.Navigate(typeof(SettingsPage));
            }
            else
            {
                var item = args.InvokedItem.ToString();
                switch (item)
                {
                    case "主页":
                        MainPageFrame.Navigate(typeof(Home));
                        break;
                    case "分类":
                        MainPageFrame.Navigate(typeof(Novels));
                        break;

                    case "关于我":
                        MainPageFrame.Navigate(typeof(About_Me));
                        break;
                    case "音乐播放器":
                        MainPageFrame.Navigate(typeof(Player));
                        break;
                }
            }
        }

        private void MainPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            MainPageFrame.Navigate(typeof(Home));
        }
    }
}
