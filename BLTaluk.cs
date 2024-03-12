using System.Data;
using TalukMaster.Datalayer;
using TalukMaster.Model;

namespace TalukMaster.BLayer
{
    public class BLTaluk
    {
        string sqlQuery = string.Empty;
        dbclass db = new dbclass();
        TalukModel TMM = new TalukModel();
        List<TalukModel> LO = new List<TalukModel>();


        public List<TalukModel> GetAllTalukMaster()
        {
            TalukModel b = new TalukModel();
            sqlQuery = "Select  * from TalukMaster";

            DataTable td = db.GetDataTable(sqlQuery);
            for(int i=0;i<td.Rows.Count;i++)
            {
                TalukModel sc = new TalukModel(); 
                    sc.TID = (int)td.Rows[i]["TID"] ;
                    sc.TName =(string) td.Rows[i]["TName"];
                    sc.DID = (int)td.Rows[i]["DID"];
                    LO.Add(sc);
            

            }
            return LO;
        }


        public List<TalukModel> GetTalukMasterID(int DID)
        {
            TalukModel b = new TalukModel();
            sqlQuery = "Select  * from TalukMaster where DID="+DID+"";

            DataTable td = db.GetDataTable(sqlQuery);
            for (int i = 0; i < td.Rows.Count; i++)
            {
                TalukModel sc = new TalukModel();
                sc.TID = (int)td.Rows[i]["TID"];
                sc.TName = (string)td.Rows[i]["TName"];
                sc.DID = (int)td.Rows[i]["DID"];
                LO.Add(sc);

            }
            return LO;
        }

        public bool SavaTalukDetails(int TID,string TName,int DID)
        {
            sqlQuery = "Insert into TalukMaster values("+TID+",'" + TName + "'," + DID + ")";
            int count = db.ExecuteOnlyQuery(sqlQuery);
            return count > 0?true: false;
        }


        public bool UpdateTDetails(int TID, string TName, int DID)
        {
            sqlQuery = "Update TalukMaster set TName = '" + TName + "',DID=" + DID + " where TID=" + TID + "";
            int count = db.ExecuteOnlyQuery(sqlQuery);
            return count > 0 ? true : false;
        }

        public bool DeleteTDetails(int TID)
        {
            sqlQuery = "Delete from TalukMaster where TID=" + TID + "";
            int count = db.ExecuteOnlyQuery(sqlQuery);
            return count > 0 ? true : false;
        }


    }


}
