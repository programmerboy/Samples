using NPOI.SS.UserModel;

namespace WebAPI.Helpers
{
    public class ExcelNpoiHelper
    {
        private IWorkbook _wb;
        private ISheet _ws;

        public ExcelNpoiHelper(IWorkbook wb, ISheet ws)
        {
            this._wb = wb;
            this._ws = ws;
        }

        public string DateFromatValue { get { return "mm/dd/yyyy"; } }

        private IFont _bold;
        public IFont Bold
        {
            get
            {
                if (_bold == null)
                {
                    _bold = _wb.CreateFont();
                    _bold.FontHeightInPoints = 9;
                    _bold.FontName = "Calibiri";
                    _bold.Boldweight = (short)FontBoldWeight.Bold;
                    _bold.IsBold = true;
                }
                return _bold; ;
            }
        }

        private ICellStyle _dateFormat;
        public ICellStyle DateFormat
        {
            get
            {
                if (_dateFormat == null)
                {
                    _dateFormat = _wb.CreateCellStyle();
                    IDataFormat dateFormat = _wb.CreateDataFormat();
                    _dateFormat.DataFormat = dateFormat.GetFormat(DateFromatValue);
                }
                return _dateFormat;
            }
        }

        private ICellStyle _border;
        public ICellStyle Border
        {
            get
            {
                if (_border == null)
                {
                    _border = _wb.CreateCellStyle();
                    _border.BorderBottom = BorderStyle.Thin;
                    _border.BottomBorderColor = IndexedColors.Black.Index;
                    _border.BorderLeft = BorderStyle.Thin;
                    _border.LeftBorderColor = IndexedColors.Black.Index;
                    _border.BorderRight = BorderStyle.Thin;
                    _border.RightBorderColor = IndexedColors.Black.Index;
                    _border.BorderTop = BorderStyle.Thin;
                    _border.TopBorderColor = IndexedColors.Black.Index;
                }
                return _border;
            }
        }

        public void ApplyBorder(int startRow, int endRow)
        {
            for (int rowNum = startRow; rowNum < endRow; rowNum++)
            {
                IRow r = _ws.GetRow(rowNum);
                if (r == null)
                { continue; }

                for (int cn = 2; cn < r.LastCellNum; cn++)
                {
                    ICell c = r.GetCell(cn, MissingCellPolicy.CREATE_NULL_AS_BLANK);
                    c.CellStyle = Border;
                }
            }
        }

        public ICell InitializeCell(int rowIndex = 0, int celIndex = 0)
        {
            var _genericRow = _ws.GetRow(rowIndex) ?? _ws.CreateRow(rowIndex);
            var _genericCell = _genericRow.GetCell(celIndex) ?? _genericRow.CreateCell(celIndex);
            return _genericCell;
        }

        public void SetCell(int rowIndex = 0, int cellIndex = 0, string value = null, bool isBold = false, bool hasBorder = false, bool isDate = false)
        {
            InitializeCell(cellIndex, rowIndex);

            ICellStyle style = _wb.CreateCellStyle();

            if (isBold) { style.SetFont(Bold); }

            if (hasBorder)
            {
                style.BorderBottom = BorderStyle.Thin;
                style.BottomBorderColor = IndexedColors.Black.Index;
                style.BorderLeft = BorderStyle.Thin;
                style.LeftBorderColor = IndexedColors.Black.Index;
                style.BorderRight = BorderStyle.Thin;
                style.RightBorderColor = IndexedColors.Black.Index;
                style.BorderTop = BorderStyle.Thin;
                style.TopBorderColor = IndexedColors.Black.Index;
            }

            var mCell = InitializeCell(rowIndex, cellIndex);
            mCell.CellStyle = style;

            if (value != null) { mCell.SetCellValue(value); }
        }

        public HorizontalAlignment Center { get { return HorizontalAlignment.Center; } }
        public HorizontalAlignment CenterSelection { get { return HorizontalAlignment.CenterSelection; } }
        public HorizontalAlignment Distributed { get { return HorizontalAlignment.Distributed; } }
        public HorizontalAlignment Fill { get { return HorizontalAlignment.Fill; } }
        public HorizontalAlignment General { get { return HorizontalAlignment.General; } }
        public HorizontalAlignment Justify { get { return HorizontalAlignment.Justify; } }
        public HorizontalAlignment Left { get { return HorizontalAlignment.Left; } }
        public HorizontalAlignment Right { get { return HorizontalAlignment.Right; } }

        public VerticalAlignment Bottom { get { return VerticalAlignment.Bottom; } }
        public VerticalAlignment VCenter { get { return VerticalAlignment.Center; } }
        public VerticalAlignment VDistributed { get { return VerticalAlignment.Distributed; } }
        public VerticalAlignment VJustify { get { return VerticalAlignment.Justify; } }
        public VerticalAlignment None { get { return VerticalAlignment.None; } }
        public VerticalAlignment Top { get { return VerticalAlignment.Top; } }
    }
}