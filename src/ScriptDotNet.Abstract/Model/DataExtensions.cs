// -----------------------------------------------------------------------
// <copyright file="DataExtensions.cs" company="ScriptDotNet">
// Copyright (c) ScriptDotNet. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptDotNet
{
    public static class DataExtensions
    {
        /// <summary>
        /// Converts a TDateTime from Delphi to a <see cref="System.DateTime"/> in .NET
        /// For more info see: http://docs.embarcadero.com/products/rad_studio/delphiAndcpp2009/HelpUpdate2/EN/html/delphivclwin32/System_TDateTime.html.
        /// </summary>
        /// <param name="tDateTime">Source double.</param>
        /// <returns>DateTime.</returns>
        public static DateTime ToDateTime(this double tDateTime)
        {
            DateTime startDate = new DateTime(1899, 12, 30);
            var days = (int)tDateTime;
            var hours = 24 * (tDateTime - days);
            return startDate.AddDays(days).AddHours(hours);
        }

        /// <summary>
        /// Converts a <see cref="System.DateTime"/> from .NET to a TDateTimein Delphi.
        /// For more info see: http://docs.embarcadero.com/products/rad_studio/delphiAndcpp2009/HelpUpdate2/EN/html/delphivclwin32/System_TDateTime.html.
        /// </summary>
        /// <param name="dateTime">Source date-time.</param>
        /// <returns>Double represent of DateTime.</returns>
        public static double ToDouble(this DateTime dateTime)
        {
            DateTime startDate = new DateTime(1899, 12, 30);
            var deltaDate = dateTime - startDate;

            var days = deltaDate.Days;
            deltaDate -= new TimeSpan(days, 0, 0, 0);

            var hours = deltaDate.TotalSeconds / 3600.0 / 24;

            return days + hours;
        }

        /// <summary>
        /// A generator to divide a sequence into chunks of n units.
        /// </summary>
        /// <param name="source">Source enumerable.</param>
        /// <param name="chunkSize">Chunk size.</param>
        /// <returns>Enumerable of chunks.</returns>
        public static IEnumerable<IEnumerable<T>> SplitN<T>(this IEnumerable<T> source, int chunkSize)
        {
            while (source.Count() > 0)
            {
                yield return source.Take(chunkSize);
                source = source.Skip(chunkSize);
            }
        }
    }
}
