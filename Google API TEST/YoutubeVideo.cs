using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Google_API_TEST
{
    public class YoutubeVideo
    {
        public String id, title, description;
        public DateTime publishedDate;

        public YoutubeVideo(String id)
        {
            this.id = id;
            YoutubeAPITest.GetVideoInfo(this);
        }
    }
}
