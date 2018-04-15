#region License
/*
The MIT License (MIT)

Copyright (c) 2012-2018 David Wendland

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE
*/
#endregion License

namespace DW.CodedUI.Internal
{
    internal static class StringExtensions
    {
        public static bool Match(string sourceString, string searchPattern, CompareKind compareKind)
        {
            if (sourceString == null || searchPattern == null)
                return false;

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
