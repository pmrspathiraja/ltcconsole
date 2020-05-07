using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTCReportGen.Model;
using System.Data;
using LTCReportGen.Reports;
using CrystalDecisions.CrystalReports.Engine;
using ToDataTable;
using System.Data.Common;
using LTCReportGen.Operation_Class;
using LTCReportGen.OperationClass;
namespace LTCReportGen
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
            ReportDocument cryRpt;
            try
            {
               
                string expirecheck = DateTime.Now.AddDays(30).ToShortDateString();
                string AccExpire = DateTime.Parse(expirecheck).ToString("yyyy-MM-dd");
                ltclk_eteacherEntities db = new ltclk_eteacherEntities();
                List<MoodlePaymentInfo> paymentRecords = db.MoodlePaymentInfoes.Include("MoodleSubjectInfo").Where(m=> m.ExpireDate.ToString().StartsWith(AccExpire) && m.Active==1).ToList();
              
                Console.WriteLine("Connected to LTC Payment Gateway...");
                DataTable dtReport = new DataTable();

                //set payment records to datatable
                dtReport = new DataTableOut().ConvertPaymentInfo(paymentRecords.ToList());

                ReportDocument myDataReport = new ReportDocument();
                myDataReport.Load(@"E:\WEB\LTCTEMPLATE NEW\CONSOLE APP\LTCReportGen\LTCReportGen\Reports\DueDates.rpt");
                myDataReport.SetDataSource(dtReport);

                string datetimenow = DateTime.Now.ToString();
                datetimenow = DateTime.Parse(datetimenow).ToString("dd mm yyyy HH mm ss");
                var filename = "LTC Moodle Account"+ datetimenow + ".pdf";

                var fullFilePathAndName = System.IO.Path.Combine("C:/PDFExport/", filename);
                myDataReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, fullFilePathAndName);
                Console.WriteLine("Report Exported : "+ filename + "");


                int sendMail = new MailSend().SendMail(fullFilePathAndName);
                if (sendMail > 0)
                {
                    Console.WriteLine("Mail Send Success");
                }
                else
                {
                    Console.WriteLine("Mail Send Error");
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {

                Console.WriteLine("LTC ONLINE PAYMENT SYSTEM ERROR");
            }
           
        }
        
    }
}
