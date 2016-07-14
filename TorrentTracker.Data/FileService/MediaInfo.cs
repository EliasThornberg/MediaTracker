using System;
using System.Text.RegularExpressions;

namespace TorrentTracker.Data.FileService
{
    public class MediaInfo
    {
        public MediaInfo(string filename)
        {
            ParseFilename(filename);
        }

        public string Title { get; set; }

        public int Year { get; set; }

        public int Season { get; set; }

        public int Episode { get; set; }

        private void ParseFilename(string filename)
        {
            Regex yearRegex = new Regex(_yearPattern);
            var yearMatch = yearRegex.Match(filename);
            if(yearMatch.Success)
            {
                Year = Convert.ToInt32(yearMatch.Value);
                filename = filename.Replace(yearMatch.Value, "");
            }

            Regex seasonRegex = new Regex(_seasonPattern);
            var seasonMatch = seasonRegex.Match(filename);
            if(seasonMatch.Success)
            {
                Season = Convert.ToInt32(seasonMatch.Value);
                filename = filename.Replace(seasonMatch.Value, "");
            }

            Regex episodeRegex = new Regex(_episodePattern);
            var episodeMatch = episodeRegex.Match(filename);
            if(episodeMatch.Success)
            {
                Episode = Convert.ToInt32(episodeMatch.Value);
                filename = filename.Replace(episodeMatch.Value, "");
            }

            Title = filename.Trim();
        }

        private string _yearPattern = @"([\[\(]?((?:19[0-9]|20[01])[0-9])[\]\)]?)";
        private string _seasonPattern = "([Ss]?([0-9]{1,2}))[Eex]";
        private string _episodePattern = "([Eex]([0-9]{2})(?:[^0-9]|$))";
    }
}
