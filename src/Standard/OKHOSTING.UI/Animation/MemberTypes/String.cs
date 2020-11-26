﻿using System;

namespace OKHOSTING.UI.Animations.MemberTypes
{
    /// <summary>
    /// Manages transitions for strings. This doesn't make as much sense as transitions
    /// on other types, but I like the way it looks!
    /// </summary>
    /// <remarks>
    /// Based on a great project by Uwe Keim https://github.com/UweKeim/dot-net-transitions
    /// </remarks>
    internal class String : IMemberType
    {
        /// <summary>
        /// Returns the type we're managing.
        /// </summary>
        public Type GetManagedType()
        {
            return typeof(string);
        }

        /// <summary>
        /// Returns a Copy of the string passed in.
        /// </summary>
        public object Copy(object o)
        {
            string s = (string) o;
            return new string(s.ToCharArray());
        }

        /// <summary>
        /// Returns an "interpolated" string.
        /// </summary>
        public object GetIntermediateValue(object start, object end, double percentage)
        {
            string strStart = (string) start;
            string strEnd = (string) end;

            // We find the length of the interpolated string...
            int startLength = strStart.Length;
            int endLength = strEnd.Length;
            int iLength = Utility.Interpolate(startLength, endLength, percentage);
            char[] result = new char[iLength];

            // Now we assign the letters of the results by interpolating the
            // letters from the start and end strings...
            for (int i = 0; i < iLength; ++i)
            {
                // We get the start and end chars at this position...
                char cStart = 'a';
                if(i < startLength)
                {
                    cStart = strStart[i];
                }
                char cEnd = 'a';
                if(i < endLength)
                {
                    cEnd = strEnd[i];
                }

                // We interpolate them...
				char cInterpolated;
				if (cEnd == ' ')
				{
					// If the end character is a space we just show a space 
					// regardless of interpolation. It looks better this way...
					cInterpolated = ' ';
				}
				else
				{
					// The end character is not a space, so we interpolate...
					int _start = Convert.ToInt32(cStart);
					int _end = Convert.ToInt32(cEnd);
					int iInterpolated = Utility.Interpolate(_start, _end, percentage);
					cInterpolated = Convert.ToChar(iInterpolated);
				}

                result[i] = cInterpolated;
            }

            return new string(result);
        }
    }
}