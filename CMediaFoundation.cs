/*
 *  Copyright © 2015 devMash.com
 * 
 *  Permission is hereby granted, free of charge, to any person obtaining a copy of this
 *  software and associated documentation files (the “Software”), to deal in the Software
 *  without restriction, including without limitation the rights to use, copy, modify, merge,
 *  publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
 *  to whom the Software is furnished to do so, subject to the following conditions:
 *  
 *  The above copyright notice and this permission notice shall be included in all copies or
 *  substantial portions of the Software.
 *  
 * THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
 * INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
 * PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
 * FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
 * OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
 * DEALINGS IN THE SOFTWARE.
 * 
 */

/****************************************************************************************
 *  If you found this example project useful, please feel free to link to the original  *
 *  article on http://www.devmash.com.                                                  *
 ****************************************************************************************/

using System;

namespace GetDuration
{

    public class CMediaFoundation
    {

        /// <summary>
        /// Get the duration of a multimedia file (in seconds)
        /// </summary>
        public double GetDuration(string filename)
        {

            double duration = double.NaN;

            const int S_OK = 0;
            const uint MEDIA_SOURCE = 0xFFFFFFFF;

            int hr;

            //Startup media foundation 
            hr = MFInterop.MFStartup(MFStartupFlags.Full);
            if (hr == S_OK)
            {

                //Create source reader
                IMFSourceReader sourceReader;
                if (S_OK == MFInterop.MFCreateSourceReaderFromURL(filename, null, out sourceReader))
                {

                    Guid MF_PD_DURATION = new Guid("6C990D33-BB8E-477A-8598-0D5D96FCD88A");

                    //The duration timebase is in 100-nanosecond units
                    double timebase = 10 * 1000 * 1000;

                    //Get the multimedia duration 
                    PropVariant propVariant;
                    sourceReader.GetPresentationAttribute(MEDIA_SOURCE, MF_PD_DURATION, out propVariant);
                    if (propVariant.Type == System.Runtime.InteropServices.VarEnum.VT_UI8)
                    {
                        duration = ((ulong)propVariant.Value) / timebase;
                    }
                    propVariant.Clear();

                }

                //Shutdown media foundation
                MFInterop.MFShutdown();

            }

            return duration;

        }

    }

}
