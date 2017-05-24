using System;
using ClosedXML.Excel;

namespace TRIPS.APP.Helpers
{
    public class ClosedXMLHelper
    {
        private XLWorkbook _wb;
        private IXLWorksheet _ws;

        private int LAST_COLUMN = 14;

        public ClosedXMLHelper(XLWorkbook wb)
        {
            this._wb = wb;
        }

        public ClosedXMLHelper(XLWorkbook wb, IXLWorksheet ws)
        {
            this._wb = wb;
            this._ws = ws;
        }

        public string DateFromatValue { get { return "mm/dd/yyyy"; } }

        private IXLFont _font;
        public IXLFont Font
        {
            get
            {
                if (_font == null)
                {
                    _font = _wb.Style.Font;
                    _font.FontSize = 9;
                    _font.FontName = "Calibiri";
                    _font.Bold = true;
                }
                return _font;
            }
        }

        public void ApplyBorder(int startRow, int endRow)
        {
            for (int rowNum = startRow; rowNum < endRow; rowNum++)
            {
                IXLRow r = _ws.Row(rowNum);
                if (r == null)
                { continue; }

                for (int cn = 2; cn < LAST_COLUMN; cn++)
                {
                    IXLCell c = r.Cell(cn);
                    c.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    c.Style.Border.BottomBorderColor = XLColor.Black;
                    c.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                    c.Style.Border.LeftBorderColor = XLColor.Black;
                    c.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    c.Style.Border.RightBorderColor = XLColor.Black;
                    c.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                    c.Style.Border.TopBorderColor = XLColor.Black;

                    //Background Color
                    c.Style.Fill.BackgroundColor = XLColor.Transparent;
                }
            }
        }

        public void ApplyHighlight(int startRow, int endRow)
        {
            for (int rowNum = startRow; rowNum < endRow; rowNum++)
            {
                IXLRow r = _ws.Row(rowNum);
                if (r == null)
                { continue; }

                for (int cn = 2; cn < LAST_COLUMN; cn++)
                {
                    IXLCell _tempCell = r.Cell(cn);
                    _tempCell.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    _tempCell.Style.Border.BottomBorderColor = XLColor.Black;
                    _tempCell.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                    _tempCell.Style.Border.LeftBorderColor = XLColor.Black;
                    _tempCell.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    _tempCell.Style.Border.RightBorderColor = XLColor.Black;
                    _tempCell.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                    _tempCell.Style.Border.TopBorderColor = XLColor.Black;

                    //Background Color
                    _tempCell.Style.Fill.BackgroundColor = XLColor.Yellow;
                }
            }
        }

        public void SetCell(int rowIndex = 0, int cellIndex = 0, string value = null, bool isBold = false, bool hasBorder = false, bool isDate = false)
        {
            if (hasBorder)
            {
                _ws.Cell(rowIndex, cellIndex).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                _ws.Cell(rowIndex, cellIndex).Style.Border.BottomBorderColor = XLColor.Black;
                _ws.Cell(rowIndex, cellIndex).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                _ws.Cell(rowIndex, cellIndex).Style.Border.LeftBorderColor = XLColor.Black;
                _ws.Cell(rowIndex, cellIndex).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                _ws.Cell(rowIndex, cellIndex).Style.Border.RightBorderColor = XLColor.Black;
                _ws.Cell(rowIndex, cellIndex).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                _ws.Cell(rowIndex, cellIndex).Style.Border.TopBorderColor = XLColor.Black;
            }

            if (isBold)
            {
                _ws.Cell(rowIndex, cellIndex).Style.Font.SetBold(true);
            }

            //Background Color
            //_ws.Cell(rowIndex, cellIndex).Style.Fill.BackgroundColor = XLColor.;

            _ws.Cell(rowIndex, cellIndex).Value = value;
        }

    }
}