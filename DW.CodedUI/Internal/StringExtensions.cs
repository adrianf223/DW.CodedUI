namespace DW.CodedUI.Internal
{
    internal static class StringExtensions
    {
        public static bool Match(string sourceString, string searchPattern, CompareKind compareKind)
        {
            switch (compareKind)
            {
                case CompareKind.Contains:
                    return sourceString.Contains(searchPattern);
                case CompareKind.ContainsIgnoreCase:
                    return sourceString.ToLower().Contains(searchPattern.ToLower());
                case CompareKind.EndsWith:
                    return sourceString.EndsWith(searchPattern);
                case CompareKind.EndsWithIgnoreCase:
                    return sourceString.ToLower().EndsWith(searchPattern.ToLower());
                case CompareKind.Exact:
                    return sourceString.Equals(searchPattern);
                case CompareKind.ExactIgnoreCase:
                    return sourceString.ToLower().Equals(searchPattern.ToLower());
                case CompareKind.StartsWith:
                    return sourceString.StartsWith(searchPattern);
                case CompareKind.StartsWithIgnoreCase:
                    return sourceString.ToLower().StartsWith(searchPattern.ToLower());
            }
            return false;
        }
    }
}
