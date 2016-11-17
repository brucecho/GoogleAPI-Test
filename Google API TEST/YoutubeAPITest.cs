using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;

namespace Google_API_TEST
{
    public partial class YoutubeAPITest : MyFormPage
    {
        private static YouTubeService ytServices = Auth();
        public YoutubeAPITest()
        {
            InitializeComponent();
            this.pnl = panel1;
        }

        private static YouTubeService Auth()
        {
            UserCredential creds;
            try
            {
                using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
                {
                    creds = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        new[] { YouTubeService.Scope.YoutubeReadonly },
                        "user",
                        CancellationToken.None,
                        new FileDataStore("YoutubeAPI")
                        ).Result;
                }

                var service = new YouTubeService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = creds,
                    ApplicationName = "YoutubeAPI"
                });

                return service;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

            return null;
        }


        public static void GetVideoInfo(YoutubeVideo video)
        {
            var videoRequest = ytServices.Videos.List("snippet");
            videoRequest.Id = video.id;

            var response = videoRequest.Execute();
            if (response.Items.Count > 0)
            {
                video.title = response.Items[0].Snippet.Title;
                video.description = response.Items[0].Snippet.Description;
                video.publishedDate = response.Items[0].Snippet.PublishedAt.Value;
            }
            else
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String strVideoID = this.textBox1.Text.Trim();

            YoutubeVideo objYoutubVideo = new YoutubeVideo(strVideoID);

            this.textBox2.Text = objYoutubVideo.title;
            this.textBox3.Text = objYoutubVideo.description;
            this.textBox4.Text = objYoutubVideo.publishedDate.ToShortDateString();
        }
    }
}
