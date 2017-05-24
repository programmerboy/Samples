namespace MVC.Controllers
{
    public class ExcelController : Controller
    {
    
    [HttpGet]
        public virtual ActionResult Download(string fileGuid, string fileName)
        {
        //Usuage: On successfull request, do something like this
        //$("#workOrder").attr({ "href": downloadUrl, "download": fileData.FileName });
        //$("#workOrder")[0].click();
            try
            {
                if (TempData[fileGuid] != null)
                {
                    var _fileExtension = fileName.CustomCompare(".") ? fileName.Substring(fileName.LastIndexOf(".")) : null;
                    var _contentType = Miscellaneous.GetContentMIMEType(_fileExtension ?? ".xlsx");
                    byte[] data = TempData[fileGuid] as byte[];
                    return File(data, _contentType, fileName);
                }
                else
                {
                    return new EmptyResult();
                }
            }
            catch (Exception ex)
            {
                ExceptionUtility.LogException(ex, "Error Downloading File");
                return new EmptyResult();
            }
        }
        
         /// <summary>
        /// A Helper Method that takes a Workbook and writes it to a stream. Stream is then converted into Array and stored in TempData object to retrieved later.
        /// </summary>
        /// <param name="_wb">Workbook to be Downloaded</param>
        /// <param name="_fileName">Name of the File</param>
        /// <returns>An object holding FileGuid and File Name which will be passed back to retrieve later</returns>
        private JsonResult ExcelHelper(XLWorkbook _wb, string _fileName)
        {
            var _ms = new MemoryStream();
            _wb.SaveAs(_ms);
            _ms.Position = 0;

            // Generate a new unique identifier against which the file can be stored
            string handle = Guid.NewGuid().ToString();
            TempData[handle] = _ms.ToArray();

            // Note we are returning a filename as well as the handle
            return new JsonResult() { Data = new { FileGuid = handle, FileName = _fileName } };
        }
        
        public ActionResult GenerateWorkBook(int id)
        {
        try
            {
                var _formattedDate = DateTime.Now.ToString("MMMddyyyy-hhmmss");
                var _fileName = "Sample" + id + "_" + _formattedDate + ".xlsx";
                var _wb = new XLWorkbook(XLEventTracking.Disabled);
                _ws = _wb.Worksheets.Add(id.ToString());
                
                _ws.Cell(1, 1).Value = "Test";

                return ExcelHelper(_wb, _fileName);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
            }
        }
      }
 }  
        
