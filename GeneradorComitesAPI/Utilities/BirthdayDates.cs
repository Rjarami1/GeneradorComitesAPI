using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneradorComitesAPI.Utilities
{
    public static class BirthdayDates
    {
        public enum Months
        {
            January,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }

        public static readonly IDictionary<int, int> MonthMaxDays = new Dictionary<int, int>()
        {
            {0, 31},
            {1, 29},
            {2, 31},
            {3, 30},
            {4, 31},
            {5, 30},
            {6, 31},
            {7, 31},
            {8, 30},
            {9, 31},
            {10, 30},
            {11, 31}
        };

    }
}
