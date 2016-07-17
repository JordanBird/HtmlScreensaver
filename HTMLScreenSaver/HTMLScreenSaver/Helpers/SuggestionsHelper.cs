using HTMLScreenSaver.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLScreenSaver.Helpers
{
    public class SuggestionsHelper
    {
        public Suggestion GetRandomSuggestion()
        {
            var suggestionTXT = GetSuggestionsContent();
            var suggestions = GetSuggestionsFromString(suggestionTXT);

            Random r = new Random();

            return suggestions.ElementAt(r.Next(0, suggestions.Count()));
        }

        private string GetSuggestionsContent()
        {
            return Properties.Resources.Suggestions;
        }

        private IEnumerable<Suggestion> GetSuggestionsFromString(string content)
        {
            var lines = content.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var output = new List<Suggestion>();

            foreach (var line in lines)
            {
                var name = line.Split(new string[] { "[NAME]", "[/NAME]" }, StringSplitOptions.None)[1];
                var description = line.Split(new string[] { "[DESCRIPTION]", "[/DESCRIPTION]" }, StringSplitOptions.None)[1];
                var url = line.Split(new string[] { "[URL]", "[/URL]" }, StringSplitOptions.None)[1];

                output.Add(new Suggestion()
                {
                    Name = name,
                    Description = description,
                    URL = url
                });
            }

            return output;
        }
    }
}
