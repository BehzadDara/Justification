using System.Text;

var words = new List<string>{
    "This", 
    "is", 
    "an", 
    "example", 
    "of", 
    "text", 
    "justification.",
    "thanks",
    "to",
    "Behzad",
    "for",
    "doing",
    "that."
};

var maxWidth = 20;

var result = Justify(words, maxWidth);
Console.WriteLine(result);

string Justify(List<string> words, int maxWidth)
{
    var sb = new StringBuilder();

    var tmpWords = new List<string>();
    var tmpLength = 0;
    foreach (var word in words)
    {
        if (tmpLength + word.Length < maxWidth)
        {
            tmpWords.Add(word);
            tmpLength += word.Length + 1;
        }
        else
        {
            var tmpLine = ComputeLine(tmpWords, maxWidth);
            sb.AppendLine(tmpLine);

           tmpWords = [word];
           tmpLength = word.Length + 1;
        }
    }

    sb.Append(string.Join(' ', tmpWords));

    return sb.ToString();
}

string ComputeLine(List<string> words, int maxWidth)
{
    var sb = new StringBuilder();

    var sumLength = words.Sum(x => x.Length);
    var numberOfSpaceNeeded = maxWidth - sumLength;

    var everyWordsShare = words.Count == 1 ? 0 : numberOfSpaceNeeded / (words.Count - 1);
    var someWordsShare = words.Count == 1 ? numberOfSpaceNeeded : numberOfSpaceNeeded % (words.Count - 1);

    foreach (var word in words)
    {
        sb.Append(word);
        sb.Append(new string(' ', everyWordsShare));

        if (someWordsShare > 0)
        {
            sb.Append(' ');
            someWordsShare--;
        }
    }

    return sb.ToString();
}