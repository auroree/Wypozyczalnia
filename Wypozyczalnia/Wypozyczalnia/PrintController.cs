using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;

namespace Wypozyczalnia
{
    public class PrintController : PrintDocument
    {
        #region  Property Variables
        /// <summary>
        /// Property variable for the Font the user wishes to use
        /// </summary>
        /// <remarks></remarks>
        private Font _font;

        /// <summary>
        /// Property variable for the text to be printed
        /// </summary>
        /// <remarks></remarks>
        private string _text;
        #endregion

        #region  Class Properties
        public string TextToPrint
        {
            get { return _text; }
            set { _text = value; }
        }

        public Font PrinterFont
        {
            get { return _font; }
            set { _font = value; } 
        }
        #endregion

        #region Static Variables
        static int curChar;
        #endregion

        #region Constructors
        public PrintController()
            : base()
        {
            _text = string.Empty;
        }

        public PrintController(string str)
            : base()
        {
            _text = str;
        }
        #endregion

        #region OnBeginPrint
        protected override void OnBeginPrint(PrintEventArgs e)
        {
            base.OnBeginPrint(e);

            if (_font == null)
            {
                _font = new Font("Times New Roman", 10);
            }
        }
        #endregion

        #region OnPrintPage
        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            base.OnPrintPage(e);

            int printHeight;
            int printWidth;
            int leftMargin;
            int rightMargin;
            Int32 lines;
            Int32 chars;

            {
                printHeight = base.DefaultPageSettings.PaperSize.Height - base.DefaultPageSettings.Margins.Top - base.DefaultPageSettings.Margins.Bottom;
                printWidth = base.DefaultPageSettings.PaperSize.Width - base.DefaultPageSettings.Margins.Left - base.DefaultPageSettings.Margins.Right;
                leftMargin = base.DefaultPageSettings.Margins.Left;  //X
                rightMargin = base.DefaultPageSettings.Margins.Top;  //Y
            }

            if (base.DefaultPageSettings.Landscape)
            {
                int tmp;
                tmp = printHeight;
                printHeight = printWidth;
                printWidth = tmp;
            }

            Int32 numLines = (int)printHeight / PrinterFont.Height;

            RectangleF printArea = new RectangleF(leftMargin, rightMargin, printWidth, printHeight);

            StringFormat format = new StringFormat(StringFormatFlags.LineLimit);

            e.Graphics.MeasureString(_text.Substring(RemoveZeros(ref curChar)), PrinterFont, new SizeF(printWidth, printHeight), format, out chars, out lines);

            e.Graphics.DrawString(_text.Substring(RemoveZeros(ref curChar)), PrinterFont, Brushes.Black, printArea, format);

            curChar += chars;

            if (curChar < _text.Length)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
                curChar = 0;
            }
        }
        #endregion

        #region RemoveZeros
        public int RemoveZeros(ref int value)
        {
            //Check the value passed into the function,
            //if the value is a 0 (zero) then return a 1,
            //otherwise return the value passed in
            //switch (value)
            //{
            //    case 0:
            //        return 1;
            //    default:
            //        return value;
            //}
            while (_text[value] == '\0')
            {
                value++;
            }
            return value;

        }
        #endregion
    }
}
