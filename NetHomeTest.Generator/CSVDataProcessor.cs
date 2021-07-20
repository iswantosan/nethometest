using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetHomeTest.Generator
{
    public class CSVDataProcessor : IDataProcessor
    {
        private string location;

        public CSVDataProcessor(string location)
        {
            this.location = location;
        }

        private static Random random = new Random();

        private static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public bool Generate(int numData)
        {
            if (numData <= 0) throw new ArgumentException("Number of data must greater than zero");

            using (var w = new StreamWriter(this.location))
            {
                for (int i = 0; i < numData; i++)
                {
                    var line = string.Format("{0},{1}", Guid.NewGuid().ToString(), RandomString(32));
                    w.WriteLine(line);
                    w.Flush();
                }
            }

            return true;
        }

        private int? FindMatch(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle)) return null;

            int total = 0;

            // perform case insensitive search
            haystack = haystack.ToLower();
            needle = needle.ToLower();

            for (int i = 0; i < haystack.Length - needle.Length + 1; ++i)
            {
                bool match = true;
                for (int j = 0; j < needle.Length; ++j)
                {
                    if (haystack[i + j] != needle[j])
                    {
                        match = false;
                        break;
                    }
                }
                if (match) total++;
            }

            return total;

        }

        public List<StringData> Populate(string search)
        {
            return File.ReadAllLines(this.location)
                                          .Select(v => new StringData()
                                          {
                                              StringID = v.Split(',')[0],
                                              StringContent = v.Split(',')[1],
                                              MatchTimes = FindMatch(v.Split(',')[1], search)
                                          }).OrderByDescending(s => s.MatchTimes)
                                          .ToList();
        }
    }
}
