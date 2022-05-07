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
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;
using Windows.UI.Xaml.Media.Animation;
using Novel2.Data;
using Novel2.Models;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Novel2.Pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Novels : Page
    {
        public Novels()
        {
            this.InitializeComponent();

            LoadCompletion();
        }
        private async void LoadCompletion()
        {
            var filter = new List<string>
            {
                "id","title"
            };
            var article = await NovelProvider.GetArticles(filter);

            LoadingRing.IsActive = false;
            ArticleListView.ItemsSource = article;
        }

        private void ArticleListView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var article = (Models.Article) e.ClickedItem;

            // Frame.Navigate(typeof(Article), article.Id);

            NovelsFrame.Navigate(typeof(Article), article.Id);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }
    }
}
