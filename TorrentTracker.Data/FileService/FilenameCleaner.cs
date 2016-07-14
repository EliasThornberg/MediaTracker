using System.Text.RegularExpressions;

namespace TorrentTracker.Data.FileService
{
    public class FilenameCleaner
    {
        private static readonly string[] tokensToRemove = new string[]
        {
            "(([0-9]{3,4}p))[^M]",
            @"(?:PPV\.)?[HP]DTV|(?:HD)?CAM|B[rR]Rip|TS|(?:PPV)?WEB-?DL(?: DVDRip)?|H[dD]Rip|DVDRip|DVDRiP|DVDRIP|CamRip|W[EB]B[rR]ip|[Bb]lu[Rr]ay|DvDScr|hdtv",
            @"(?i)xvid|x264|h\.?264",
            @"MP3|DD5\.?1|Dual[\- ]Audio|LiNE|DTS|AAC(?:\.?2\.0)?|AC3(?:\.5\.1)?",
            "(- ?([^-]+(?:-={[^-]+-?$)?))$",
            "(?i)R[0-9]",
            "(?i)EXTENDED",
            "(?i)HC",
            "Hardcoded",
            "PROPER",
            "REPACK",
            "WS",
            @"^(\[ ?([^\]]+?) ?\])",
            @"(?i)rus\.eng",
            "(-)",
            @"\.",

        };

        public static string Clean(string filename)
        {
            foreach(var token in tokensToRemove)
            {
                filename = Regex.Replace(filename, token, token == @"\." ? " " : "");
            }

            return filename.Trim();
        }
    }
}
