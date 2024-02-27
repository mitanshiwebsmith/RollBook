using RollBook.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RollBook.DAL
{
    public class Roll_DAL
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        public List<RollMaster> GetAllRoll(int QualityID,DateTime EntryDate)
        {
            List<RollMaster> RollList = new List<RollMaster>();
            int id = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "RollMaster_Filter";
                command.Parameters.AddWithValue("@QualityID", QualityID);
                command.Parameters.AddWithValue("@EntryDate", EntryDate);
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtRoll = new DataTable();

                connection.Open();
                id = command.ExecuteNonQuery();
                sqlDA.Fill(dtRoll);
                connection.Close();

                foreach (DataRow dr in dtRoll.Rows)
                {
                    RollList.Add(new RollMaster
                    {
                        RollID = Convert.ToInt32(dr["RollID"]),
                        RollNo = dr["RollNo"].ToString(),
                        Size = dr["Size"].ToString(),
                        DNR = dr["DNR"].ToString(),
                        CbMtr = dr["CbMtr"].ToString(),
                        OpMtr = dr["OpMtr"].ToString(),
                        QualityName = dr["QualityName"].ToString(),
                        NW = dr["NW"].ToString(),
                        TW = dr["TW"].ToString(),
                        QW = dr["QW"].ToString(),
                        LoomNo = dr["LoomNo"].ToString(),

                    });
                }
                return RollList;
            }
        }

        internal void Add(RollMaster RollModel)
        {
            throw new NotImplementedException();
        }

        //get data insert and update
        public bool RollInsertUpdate(RollMaster Roll)
        {
            int id = 0;
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
                command.Parameters.AddWithValue("@NW", Roll.NW);
                command.Parameters.AddWithValue("@QualityID", Roll.QualityID);
                command.Parameters.AddWithValue("@QW", Roll.QW);
                command.Parameters.AddWithValue("@TW", Roll.TW);
                command.Parameters.AddWithValue("@Size", Roll.SizeID);
                command.Parameters.AddWithValue("@RollID", Roll.RollID);

                connection.Open();
                id = command.ExecuteNonQuery();
                connection.Close();
            }
            if (id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<QualityMaster> GetAllQuality()
        {
            List<QualityMaster> QualityList = new List<QualityMaster>();

            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "QualityMaster_SelectAll";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtRoll = new DataTable();

                connection.Open();
                sqlDA.Fill(dtRoll);
                connection.Close();

                foreach (DataRow dr in dtRoll.Rows)
                {
                    QualityList.Add(new QualityMaster
                    {
                        QualityID = Convert.ToInt32(dr["QualityID"]),
                        QualityName = dr["QualityName"].ToString(),

                    });
                }
                return QualityList;
            }
        }

        public List<LoomMaster> GetAllLoom()
        {
            List<LoomMaster> LoomList = new List<LoomMaster>();

            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "LoomMaster_SelectAll";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtRoll = new DataTable();

                connection.Open();
                sqlDA.Fill(dtRoll);
                connection.Close();

                foreach (DataRow dr in dtRoll.Rows)
                {
                    LoomList.Add(new LoomMaster
                    {
                        LoomID = Convert.ToInt32(dr["LoomID"]),
                        LoomNo = dr["LoomNo"].ToString(),

                    });
                }
                return LoomList;
            }
        }

        public List<SizeMaster> GetAllSize()
        {
            List<SizeMaster> SizeList = new List<SizeMaster>();

            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SizeMaster_GetAll";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtRoll = new DataTable();

                connection.Open();
                sqlDA.Fill(dtRoll);
                connection.Close();

                foreach (DataRow dr in dtRoll.Rows)
                {
                    SizeList.Add(new SizeMaster
                    {
                        SizeID = Convert.ToInt32(dr["SizeID"]),
                        Size = dr["Size"].ToString(),
                        TW = dr["TW"].ToString(),
                    });
                }
                return SizeList;
            }
        }
    }
}