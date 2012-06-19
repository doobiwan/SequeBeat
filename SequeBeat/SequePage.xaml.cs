using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace SequeBeat
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class SequePage : SequeBeat.Common.LayoutAwarePage
    {
        DispatcherTimer t;

        public SequePage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void btnLaunch_Click(object sender, RoutedEventArgs e)
        {
            if (t != null)
            {
                t.Stop();
                t.Tick -= t_Tick;
                t = null;
                return;
            }
            //http://babaandthepigman.wordpress.com/2012/03/17/metro-background-audio-c-consumer-preview/
            //http://stackoverflow.com/questions/10960952/play-two-sounds-simultaneously-in-windows-8-metro-app-c-xaml

            t = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(417)
            };

            t.Tick += t_Tick;

            t.Start();
        }

        void t_Tick(object sender, object e)
        {
            PlayLaserSound();
        }

        public async void PlayLaserSound()
        {
            var package = Windows.ApplicationModel.Package.Current;
            var installedLocation = package.InstalledLocation;
            
            var storageFile = await installedLocation.GetFileAsync("Assets\\Samples\\Kick 5.wav");
            if (storageFile != null)
            {
                var stream = await storageFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
                MediaElement snd = new MediaElement();
                snd.SetSource(stream, storageFile.ContentType);
                snd.Play();
            }

            var storageFile2 = await installedLocation.GetFileAsync("Assets\\Samples\\Snare 5.wav");
            if (storageFile2 != null)
            {
                var stream = await storageFile2.OpenAsync(Windows.Storage.FileAccessMode.Read);
                MediaElement snd = new MediaElement();
                snd.SetSource(stream, storageFile2.ContentType);
                snd.Play();
            }
        }
    }
}
