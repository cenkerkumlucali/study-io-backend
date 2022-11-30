using System.Text.RegularExpressions;

namespace Persistence.Operations;

public static class StringExtractUtil
{
    public static List<string> ExtractMentionsWithExceptList(string input, IList<string> exceptUsernames)
    {
         List<string> mentions = new();
         Regex regex = new Regex("@([a-zA-Z0-9_]{1,50})");
         MatchCollection matches = regex.Matches(input);
         foreach (Match match in matches)
         {
             foreach (Group group in match.Groups)
             {
                 if(!group.Value.Contains("@")) mentions.Add(group.Success ? group.Value : string.Empty);
             }
         }
         foreach (var exceptUsername in exceptUsernames)
         {
             mentions.Remove(exceptUsername);
         }
         return mentions;
    }
}