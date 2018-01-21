using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationInsightDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                AppInsightSDK.Logger.TrackInfo("Track Info");

                AppInsightSDK.Logger.TrackWarning("Track Warning");

                AppInsightSDK.Logger.TrackException(new ArgumentNullException("Parameter Name"));
            }
        }
    }
}
