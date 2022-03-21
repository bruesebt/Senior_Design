using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsTheMove.Core.Common
{
    public static class StringExtensions
    {
        public static string ToCSV(this IEnumerable<string> values) => string.Join(",", values);
    }
}
