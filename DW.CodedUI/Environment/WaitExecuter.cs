using System;
using System.Globalization;
using System.Threading;
using System.Xml.Linq;

namespace DW.CodedUI.Environment
{
    public class WaitExecuter : Executer
    {
        public WaitExecuter(XElement element)
            : base(element)
        {
        }

        public override void Run()
        {
            Thread.Sleep(Exact);
        }

        private TimeSpan Exact { get { return ExtractTime(GetValue("exact")); } }

        private TimeSpan ExtractTime(string value)
        {
            var numbers = "";
            var text = "";
            foreach (var character in value)
            {
                if (char.IsNumber(character) || character == '.')
                {
                    numbers += character;
                    continue;
                }
                text += character;
            }
            numbers = numbers.Trim();
            text = text.Trim();

            var number = 0.0;
            if (!double.TryParse(numbers, NumberStyles.Number, CultureInfo.InvariantCulture, out number))
                return new TimeSpan();
            switch (text.ToLower())
            {
                case "seconds":
                case "s":
                    return TimeSpan.FromSeconds(number);
                case "milliseconds":
                case "ms":
                    return TimeSpan.FromMilliseconds(number);
                case "minutes":
                case "m":
                    return TimeSpan.FromMinutes(number);
            }
            return new TimeSpan();
        }
    }
}