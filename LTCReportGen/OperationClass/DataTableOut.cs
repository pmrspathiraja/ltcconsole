using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using LTCReportGen.Model;
namespace LTCReportGen.Operation_Class
{
    public class DataTableOut
    {
        public DataTable ConvertPaymentInfo(List<MoodlePaymentInfo> paymentInfo)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SubName");
            dt.Columns.Add("Subjects");
            dt.Columns.Add("Contact");
            dt.Columns.Add("Email");
            dt.Columns.Add("NIC");
            dt.Columns.Add("CreatedDate");
            dt.Columns.Add("ExpireDate");
            dt.Columns.Add("FullName");
            foreach (MoodlePaymentInfo paymentRec in paymentInfo)
            {
                string credate = paymentRec.CreatedDate.ToString();
                credate = DateTime.Parse(credate).ToString("dd-MMM-yyyy");

                string expdate = paymentRec.ExpireDate.ToString();
                expdate = DateTime.Parse(expdate).ToString("dd-MMM-yyyy");

                dt.Rows.Add(paymentRec.MoodleSubjectInfo.SubjectName, paymentRec.Subjects, paymentRec.Contact, paymentRec.Email, paymentRec.NIC, credate, expdate, paymentRec.FullName);
            }
            return dt;
        }
    }
}
