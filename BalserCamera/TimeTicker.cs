using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalserCamera
{
    public class TimeTicker : IDisposable
    {
        double m_dStartTime = 0.0;    ///< 开始时间
        double m_dStopTime = 0.0;     ///< 停止时间 
        string m_Title;

        public TimeTicker(string title)
        {
            m_Title = title;
            Start();
        }

        /// <summary>
        /// 开始计数
        /// </summary>
        public void Start()
        {
            m_dStartTime = Stopwatch.GetTimestamp();
        }

        /// <summary>
        /// 停止计数
        /// </summary>
        /// <returns>时间差单位ms</returns>
        public double Stop()
        {
            m_dStopTime = Stopwatch.GetTimestamp();
            double theElapsedTime = ElapsedTime();

            m_dStartTime = m_dStopTime;
            return theElapsedTime;
        }

        /// <summary>
        /// 获取时间差
        /// </summary>
        /// <returns>时间差单位ms</returns>
        public double ElapsedTime()
        {
            m_dStopTime = Stopwatch.GetTimestamp();
            double dTimeElapsed = (m_dStopTime - m_dStartTime) * 1000.0;
            return dTimeElapsed / Stopwatch.Frequency;
        }


        public void Dispose()
        {
            double elapsedTime = Stop();
            string sMsg = m_Title + ": " + elapsedTime.ToString();
            OutputDebugString(sMsg);
        }

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        public static extern void OutputDebugString(string sMsg);

    }
}
