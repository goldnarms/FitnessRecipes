using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using FitnessRecipes.ViewModels;

namespace FitnessRecipes.Helpers
{
    public class RssReader
    {
        public static IEnumerable<RssFeed> GetRssFeed()
        {
            XDocument feedXml = XDocument.Load("http://feeds.blogg.no/570236/post.rss");
            var feeds = from feed in feedXml.Descendants("item")
                        select new RssFeed
                        {
                            Title = feed.Element("title").Value,
                            Link = feed.Element("link").Value,
                            Description = Regex.Match(feed.Element("description").Value, @"^.{1,180}\b(?<!\s)").Value
                        };
            return feeds;
        }
    }
}
