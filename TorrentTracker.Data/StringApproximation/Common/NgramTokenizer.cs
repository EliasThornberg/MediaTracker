using System;
using System.Collections.Generic;

namespace TorrentTracker.Data.StringApproximation.Common
{
    public class NgramTokenizer
    {
        public static IEnumerable<string> CreateNgram(string source, int ngramSize)
        {
            for (int i = 0; i < source.Length; i += ngramSize)
            {
                yield return source.Substring(i, Math.Min(ngramSize, source.Length - i));
            }
        }
    }
}
