﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using STFU.Executable.AutoUploader.WPF.Helpers;
using STFU.Executable.AutoUploader.WPF.ViewModels;
using STFU.Lib.Youtube.Persistor.Model;

namespace STFU.Executable.AutoUploader.WPF.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = DataContext as MainViewModel;
            ViewModel.Load();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainViewModel.AutoUploaderSettings.ShowReleaseNotes)
                ViewModel.ShowReleaseNotes();
        }

        private void CloseItem_Click(object sender, RoutedEventArgs e) => Close();

        private void ConnectYouTubeItem_Click(object sender, RoutedEventArgs e) => ViewModel.ConnectToYouTube();

        private void DisonnectYouTubeItem_Click(object sender, RoutedEventArgs e) => ViewModel.RevokeAccess();

        private void TemplatesItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PathsItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UncompletedUploadItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TutorialVideoItem_Click(object sender, RoutedEventArgs e) => ViewModel.OpenTutorialVideo();

        private void DiscordServerItem_Click(object sender, RoutedEventArgs e) => ViewModel.OpenDiscordServer();

        private void LPFThreadItem_Click(object sender, RoutedEventArgs e) => ViewModel.OpenLPFThread();

        private void YTFThreadItem_Click(object sender, RoutedEventArgs e) => ViewModel.OpenYTFThread();

        private void StrohiTwitterItem_Click(object sender, RoutedEventArgs e) => ViewModel.OpenStrohiTwitter();

        private void DownloadPageItem_Click(object sender, RoutedEventArgs e) => ViewModel.OpenDownloadPage();

        private void ChannelLink_Click(object sender, RoutedEventArgs e) => ViewModel.YouTubeAccountVM.OpenChannelInBrowser();

        private void ChooseProcess_Click(object sender, RoutedEventArgs e) => ViewModel.ChoseProcessToWaitFor();

        private void Start_Click(object sender, RoutedEventArgs e) => ViewModel.Start();

        private void NewFeaturesItem_Click(object sender, RoutedEventArgs e) => ViewModel.ShowReleaseNotes();

        private void WaitForProcess_Checked(object sender, RoutedEventArgs e) => ViewModel.ChoseProcessToWaitFor();
    }
}
