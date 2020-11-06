using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DebugToolsLib
{
    public class ConvertUnit
    {
        public static string TimeSpanToString(TimeSpan ts, bool isAuto = true, bool isDay = true, bool isHour = true,
            bool isMin = true, bool isSec = true, bool isMs = true)
        {
            StringBuilder str = new StringBuilder();
            if ((isDay && !isAuto) || (isAuto && ts.Days != 0))
                str.Append(string.Format("{0:D2}д", ts.Days));
            if ((isHour && !isAuto) || (isAuto && ts.Hours != 0))
                str.Append(string.Format("{0:D2}ч", ts.Hours));
            if ((isMin && !isAuto) || (isAuto && ts.Minutes != 0))
                str.Append(string.Format("{0:D2}м", ts.Minutes));
            if ((isSec && !isAuto) || (isAuto && ts.Seconds != 0))
                str.Append(string.Format("{0:D2}с", ts.Seconds));
            if ((isMs && !isAuto) || (isAuto))
                str.Append(string.Format("{0:D3}мс", ts.Milliseconds));

            return str.ToString();
        }

        public static bool IsReduceTimeValue = true;
        public static bool IsReduceSizeValue = true;
        public enum InfoTimeSuffixes { microseconds, ms, sec, min, hour, day, week, month, year}

        static readonly string[] TimeInfoSuffixes =
                   {"мкрс", "мс", "сек", "мин", "час", "дн", "нед", "мес", "год"};
        public enum InfoSizeSuffixes { bytes, KB, MB, GB, TB, PB, EB, ZB, YB}
        static readonly string[] SizeInfoSuffixes =
                   { "байт", "Кб", "Мб", "Гб", "Tб", "Пб", "EB", "Цб", "YB" };

        public static string InfoSizeSuffixToString(double sizeInfo, InfoSizeSuffixes suffixSize)
        {
            if (sizeInfo < 0) { return "-" + InfoSizeSuffixToString(-sizeInfo, suffixSize); }
            if (Math.Abs(sizeInfo) < 0) { return "0.0 байт"; }

            decimal adjustedSize = InfoSizeSuffix(sizeInfo, ref suffixSize);

            return string.Format("{0:n1} {1}", adjustedSize, SizeInfoSuffixes[(int) suffixSize]);
        }

        public static decimal InfoSizeSuffix(double sizeInfo, ref InfoSizeSuffixes suffix)
        {
            if (!IsReduceSizeValue)
                return (decimal) sizeInfo;
            var mag = (int)Math.Log(sizeInfo, 1024);
            var adjustedSize = (decimal)sizeInfo / (1L << (mag * 10));
            suffix = (InfoSizeSuffixes) mag + (int) suffix;
            return adjustedSize;
        }

        public static double InfoSpeedSuffix(double sizeInfo, double timeInfo, ref InfoSizeSuffixes suffixSize,
            ref InfoTimeSuffixes suffixMinimalTime)
        {
            InfoTimeSuffix(ref timeInfo, ref suffixMinimalTime);
            double speed = (double) InfoSizeSuffix(sizeInfo/timeInfo, ref suffixSize);

            return speed; //(double) adjustedSize/timeInfo;
        }

        public static string InfoSpeedSuffixToString(double sizeInfo, double timeInfo, InfoSizeSuffixes suffixSize,
            InfoTimeSuffixes suffixMinimalTime)
        {
            if (sizeInfo < 0) { return "-" + InfoSpeedSuffixToString(-sizeInfo, timeInfo, suffixSize, suffixMinimalTime); }
            if (Math.Abs(sizeInfo) <= 0)
            {
                suffixSize = InfoSizeSuffixes.bytes;
                suffixMinimalTime = InfoTimeSuffixes.microseconds;
                return string.Format("0.0 {0}/{1}", SizeInfoSuffixes[(int) suffixSize],
                    TimeInfoSuffixes[(int) suffixMinimalTime]);
            }

            var speed = InfoSpeedSuffix(sizeInfo, timeInfo, ref suffixSize, ref suffixMinimalTime);
            var str = string.Format("{0:F2} {1}/{2}", speed, SizeInfoSuffixes[(int) suffixSize],
                TimeInfoSuffixes[(int) suffixMinimalTime]);
            return str;
        }

        static void InfoTimeSuffix(ref double timeInfo, ref InfoTimeSuffixes suffixTime)
        {
            if (!IsReduceTimeValue)
                return;
            if (suffixTime == InfoTimeSuffixes.microseconds && timeInfo >= 1000)
            {
                timeInfo *= 0.001;
                suffixTime += 1;
            }
            if (suffixTime == InfoTimeSuffixes.ms && timeInfo >= 1000)
            {
                timeInfo *= 0.001;
                suffixTime += 1;
            }
            if (suffixTime == InfoTimeSuffixes.sec && timeInfo >= 60)
            {
                timeInfo /= 60;
                suffixTime += 1;
            }
            if (suffixTime == InfoTimeSuffixes.min && timeInfo >= 60)
            {
                timeInfo /= 60;
                suffixTime += 1;
            }
            if (suffixTime == InfoTimeSuffixes.hour && timeInfo >= 24)
            {
                timeInfo /= 24;
                suffixTime += 1;
            }
            if (suffixTime == InfoTimeSuffixes.day && timeInfo >= 7)
            {
                timeInfo /= 7;
                suffixTime += 1;
            }
            if (suffixTime == InfoTimeSuffixes.week && timeInfo >= 52)
            {
                timeInfo /= 52;
                suffixTime += 1;
            }
            if (suffixTime == InfoTimeSuffixes.month && timeInfo >= 30)
            {
                timeInfo /= 30;
                suffixTime += 1;
            }
            if (suffixTime == InfoTimeSuffixes.year && timeInfo >= 12)
            {
                timeInfo /= 12;
                suffixTime += 1;
            }
        }
    }

}
