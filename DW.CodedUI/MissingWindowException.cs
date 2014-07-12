using System;

namespace DW.CodedUI
{
    /// <summary>
    /// Represents errors that occur during searching for elements starting from a window.
    /// </summary>
    public class MissingWindowException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DW.CodedUI.MissingWindowException" /> class.
        /// </summary>
        /// <param name="lastWindow">True if the last window was tried to be used but is not there; false if its the main window.</param>
        public MissingWindowException(bool lastWindow)
            : base(BuildMessage(lastWindow))
        {
        }

        private static string BuildMessage(bool lastWindow)
        {
            if (lastWindow)
                return "There is no last window available; Either no WindowFinder.Search was run successfully or no BasicWindow got created with an existing item.";
            return "The MainWindow could not be determined. Either there is no last window or the process under test does not have a main window handle. The last window is set if a WindowFinder.Search was run successfully or a BasicWindow got created with an existing item.";
        }
    }
}
