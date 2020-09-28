using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BattleCity.Extensions
{
    public static class StreamReaderExtension
    {
        public static List<List<char>> ReadAllLinesOfCharacters(this StreamReader streamReader)
        {
            var linesOfCharacters = new List<List<char>>();
            string line;

            while((line = streamReader.ReadLine()) != null)
            {
                var lineOfCharacters = line.ToCharArray().ToList();
                linesOfCharacters.Add(lineOfCharacters);
            }

            return linesOfCharacters;
        }
    }
}
