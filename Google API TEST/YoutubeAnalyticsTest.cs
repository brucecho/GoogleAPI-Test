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
using Google.Apis.YouTubeAnalytics.v1;

namespace Google_API_TEST
{
    public partial class YoutubeAnalyticsTest : MyFormPage
    {
        private static YouTubeAnalyticsService ytaServices = Auth();
        public YoutubeAnalyticsTest()
        {
            InitializeComponent();
            this.pnl = panel1;
        }

        private static YouTubeAnalyticsService Auth()
        {
            UserCredential creds;
            try
            {
                using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
                {
                    creds = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        new[] { YouTubeAnalyticsService.Scope.YtAnalyticsReadonly, YouTubeAnalyticsService.Scope.YtAnalyticsMonetaryReadonly, YouTubeAnalyticsService.Scope.YoutubeReadonly, YouTubeAnalyticsService.Scope.Youtubepartner },
                        "user",
                        CancellationToken.None,
                        new FileDataStore("YoutubeAnalyticsAPI")
                        ).Result;
                }

                var service = new YouTubeAnalyticsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = creds,
                    ApplicationName = "YoutubeAnalyticsAPI"
                });

                return service;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

            return null;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            String strStartDate = "2016-01-01";
            String strEndDate = "2016-12-31";
            String strids = "channel==UCmi-Ebs3i_J68Ce9PQdMe1w";
            String strMetrics = "views";

            var analyticsRequest = ytaServices.Reports.Query(strids, strStartDate, strEndDate, strMetrics);

            var analyticsResponse = analyticsRequest.Execute();
            if(analyticsResponse != null)
            {
                this.textBox1.Text = analyticsResponse.ToString();
            }
        }
    }
}
