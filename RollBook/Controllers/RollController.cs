using NPOI.HSSF.UserModel;
using RollBook.DAL;
using RollBook.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RollBook.Controllers
{
    public class RollController : Controller
    {
        
        Roll_DAL _RollDAL = new Roll_DAL();
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        // GET: Student
        public ActionResult Index()
        {
            List<QualityMaster> lstRoll = _RollDAL.GetAllQuality();
            ViewBag.lstRoll = lstRoll;

            List<LoomMaster> lstLoom = _RollDAL.GetAllLoom();
            ViewBag.lstLoom = lstLoom;

            List<SizeMaster> lstSize = _RollDAL.GetAllSize();
            ViewBag.lstSize = lstSize;

            return View();
        }
 
        [HttpPost]
        public JsonResult GetData(int QualityID,DateTime EntryDate)
        {
            try
            {
                //List<RollMaster> lstRoll = _RollDAL.GetAllRoll();
                List<RollMaster> lstFilterRoll = _RollDAL.GetAllRoll(QualityID, EntryDate);
                HttpContext.Cache["RoollBookReport"] = Newtonsoft.Json.JsonConvert.SerializeObject(lstFilterRoll);
                
                return Json(Newtonsoft.Json.JsonConvert.SerializeObject(lstFilterRoll), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error :" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Save(RollMaster Roll)
        {
            //Boolean mres = _RollDAL.RollInsertUpdate(Roll);

            try
            {
                
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "RollMaster_Insert_Update";
                    command.Parameters.AddWithValue("@RollNo", Roll.RollNo);
                    command.Parameters.AddWithValue("@OpMtr", Roll.OpMtr);
                    command.Parameters.AddWithValue("@CbMtr", Roll.CbMtr);
                    command.Parameters.AddWithValue("@DNR", Roll.DNR);
                    command.Parameters.AddWithValue("@LoomID", Roll.LoomID);
                    command.Parameters.AddWithValue("@NW", Convert.ToDouble(Roll.QW) - Convert.ToDouble(Roll.TW));
                    command.Parameters.AddWithValue("@QualityID", Roll.QualityID);
                    command.Parameters.AddWithValue("@QW", Roll.QW);
                    //command.Parameters.AddWithValue("@TW", Roll.TW);
                    command.Parameters.AddWithValue("@SizeID", Roll.SizeID);
                    command.Parameters.AddWithValue("@RollID", Roll.RollID);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                return Json("Successful...!!!", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error :" + ex.Message, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult Get(int RollID)
        {
            List<RollMaster> RollList = new List<RollMaster>();
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "RollMaster_SelectByPK";
                    command.Parameters.AddWithValue("@RollID", RollID);
                    SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                    DataTable dtRoll = new DataTable();

                    connection.Open();
                    sqlDA.Fill(dtRoll);
                    connection.Close();

                    foreach (DataRow dr in dtRoll.Rows)
                    {
                        RollList.Add(new RollMaster
                        {
                            RollID = Convert.ToInt32(dr["RollID"]),
                            QualityID = Convert.ToInt32(dr["QualityID"]),
                            LoomID = Convert.ToInt32(dr["LoomID"]),
                            OpMtr = dr["OpMtr"].ToString(),
                            RollNo = dr["RollNo"].ToString(),
                            CbMtr = dr["CbMtr"].ToString(),
                            DNR = dr["DNR"].ToString(),
                            NW = dr["NW"].ToString(),
                            QW = dr["QW"].ToString(),
                            TW = dr["TW"].ToString(),
                            SizeID = Convert.ToInt32(dr["SizeID"])
                        });

                    }
                }

                return Json(Newtonsoft.Json.JsonConvert.SerializeObject(RollList), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error :" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Delete(string RollID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "DeactiveRecords_Insert";
                    
                    command.Parameters.AddWithValue("@RollID", RollID);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                return Json("Successful Deleted...!!!", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error :" + ex.Message, JsonRequestBehavior.AllowGet);
            }

        }

        public FileResult ExportToExcel()
        {
            try
            {
                object data = HttpContext.Cache["RoollBookReport"];

                List<RollMaster> lst = new List<RollMaster>();

                if (data != null)
                {
                    lst = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RollMaster>>(data.ToString());
                }
                var excelFile = ExportEmployeeReport(lst);

                string FileName = "RollReport.xls";

                return File(excelFile, "application/vnd.ms-excel", FileName);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public byte[] ExportEmployeeReport(List<RollMaster> lst)
        {
            if (lst.Count > 0)
            {
                string SheetName = "Employee Report";

                // Declare HSSFWorkbook object for create sheet
                var workbook = new HSSFWorkbook();
                var sheet = workbook.CreateSheet(SheetName);

                // Set column name this column name use for fetch data from list
                List<string> headers = new List<string>
                {
                    "SrNo.",
                    "Quality",
                    "Loom No",
                    "Roll No",
                    "Size",
                    "D.N.R",
                    "O.P.Mtr",
                    "C.B.Mtr",
                    "Total Mtr",
                    "Q.W",
                    "T.W",
                    "N.W",
                    "AVR",
                };

                HSSFFont BodyFont = (HSSFFont)workbook.CreateFont();
                BodyFont.FontHeightInPoints = 11;
                BodyFont.FontName = "Calibri";

                HSSFCellStyle BodyStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                BodyStyle.SetFont(BodyFont);

                var headerRow = sheet.CreateRow(0);

                //Below loop is create header
                for (int i = 0; i < headers.Count; i++)
                {
                    var cell = headerRow.CreateCell(i);
                    cell.SetCellValue(headers[i]);
                    cell.CellStyle = BodyStyle;
                }

                //Below loop is fill content
                for (int i = 0; i < lst.Count; i++)
                {
                    var rowIndex = i + 1;
                    var row = sheet.CreateRow(rowIndex);

                    var SrNo = row.CreateCell(0);
                    var Quality = row.CreateCell(1);
                    var LoomNo = row.CreateCell(2);
                    var RollNo = row.CreateCell(3);
                    var Size = row.CreateCell(4);
                    var DNR = row.CreateCell(5);
                    var OpMtr = row.CreateCell(6);
                    var CbMtr = row.CreateCell(7);
                    var TotalMtr = row.CreateCell(8);
                    var QW = row.CreateCell(9);
                    var TW = row.CreateCell(10);
                    var NW = row.CreateCell(11);
                    var AVR = row.CreateCell(12);
                    
                    SrNo.SetCellValue(i + 1);
                    Quality.SetCellValue(lst[i].QualityName);
                    LoomNo.SetCellValue(lst[i].LoomNo);
                    RollNo.SetCellValue(lst[i].RollNo);
                    Size.SetCellValue(lst[i].Size);
                    DNR.SetCellValue(lst[i].DNR);
                    OpMtr.SetCellValue(lst[i].OpMtr);
                    CbMtr.SetCellValue(lst[i].CbMtr);
                    TotalMtr.SetCellValue(Convert.ToInt32(lst[i].OpMtr) - Convert.ToInt32(lst[i].CbMtr)); 
                    QW.SetCellValue(lst[i].QW);
                    TW.SetCellValue(lst[i].TW);
                    NW.SetCellValue(lst[i].NW);
                    AVR.SetCellValue(Convert.ToDouble(lst[i].NW) / (Convert.ToDouble(lst[i].OpMtr) - Convert.ToDouble(lst[i].CbMtr)) * 1000);//NEED TO SAVE

                    SrNo.CellStyle = Quality.CellStyle = LoomNo.CellStyle = RollNo.CellStyle = Size.CellStyle = DNR.CellStyle = OpMtr.CellStyle = CbMtr.CellStyle = TotalMtr.CellStyle = QW.CellStyle = TW.CellStyle = NW.CellStyle = AVR.CellStyle = BodyStyle;

                    sheet.AutoSizeColumn(i);
                }

                // Declare one MemoryStream variable for write file in stream
                var stream = new MemoryStream();
                workbook.Write(stream);

                return stream.ToArray();
            }

            return null;
        }
    }
}