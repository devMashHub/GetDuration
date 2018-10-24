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
using System.Windows;

using Microsoft.Win32;

namespace GetDuration
{

    public partial class MainWindow : Window
    {

        /// <summary>
        /// Constructor
        /// </summary>
        ///
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// OnSelectFileClicked event handler
        /// </summary>
        ///
        private void OnSelectFileClicked(object sender, RoutedEventArgs e)
        {
            string filename = this.GetFilename();
            if (!String.IsNullOrEmpty(filename))
            {
                CMediaFoundation mediaFoundation = new CMediaFoundation();
                double duration = mediaFoundation.GetDuration(filename);
                if (!double.IsNaN(duration))
                {
                    string message = string.Format("The media file is {0:0.000} seconds in duration", duration);
                    MessageBox.Show(message);
                }
                else
                {
                    MessageBox.Show("Failed!  Be sure to pick a known media format!");
                }
            }
        }

        /// <summary>
        /// Display the open file dialog and get a filename
        /// </summary>
        ///
        private string GetFilename()
        {
            string filename = String.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                DefaultExt = ".*",
                Filter = "All filetypes (*.*)|*.*"
            };
            bool? result = openFileDialog.ShowDialog();
            if (result.Value)
            {
                filename = openFileDialog.FileName;
            }
            return filename;
        }

    }

}
