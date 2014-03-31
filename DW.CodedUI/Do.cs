using System;

namespace DW.CodedUI
{
    public static class Do
    {
        public static CombinableDo Wait(uint milliseconds)
        {
            var combinableDo = new CombinableDo();
            return combinableDo.Wait(milliseconds);
        }

        public static CombinableDo WaitCPUIdle(uint mimimumPercent, uint maximumWaitTime = 60000)
        {
            var combinableDo = new CombinableDo();
            return combinableDo.WaitCPUIdle(mimimumPercent, maximumWaitTime);
        }

        public static CombinableDo Launch(string path, string arguments = null)
        {
            var combinableDo = new CombinableDo();
            return combinableDo.Launch(path, arguments);
        }

        public static CombinableDo Action(Action action)
        {
            var combinableDo = new CombinableDo();
            return combinableDo.Action(action);
        }
    }
}
