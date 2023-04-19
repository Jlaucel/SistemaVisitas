using SistemaVisitas.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaVisitas.Controllers
{

    public class HomeController : Controller
    {
        SistemaVisitasEntitites db = new SistemaVisitasEntitites();
        SqlConnection sql = new SqlConnection();

        [Authorize]
        public ActionResult Index()
        {

            int day = DateTime.Now.Hour;

            var items = db.REGISTROVISITAS.ToList();

            var lastVisit = db.REGISTROVISITAS.OrderByDescending(a => a.FECHA).FirstOrDefault();

            
            List<DateTime> x = new List<DateTime>();

            List<DateTime> listtoremove = new List<DateTime>();

            x.Add(new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 01, 00, 00));
            x.Add(new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 06, 00, 00));
            x.Add(new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 07, 00, 00));
            x.Add(new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 10, 00, 00));
            x.Add(new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 13, 00, 00));
            x.Add(new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 15, 00, 00));
            x.Add(new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 18, 00, 00));
            x.Add(new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 21, 00, 00));
            x.Add(new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 00, 00));

            foreach (var a in x) {

                if (a < lastVisit.FECHA) {
                    listtoremove.Add(a);
                }
                    
            }

            x.RemoveAll(a => listtoremove.Contains(a));
                

            ViewBag.HoursToVisit = x;
            Console.WriteLine("x");
            return View(items);
        }
        [Authorize(Roles =("Admin,Developer"))]
        public ActionResult Stadistics() {
            SqlConnection conn = new SqlConnection(@"Data Source=YUNIORPC\SQLEXPRESS;Initial Catalog=SistemaVisitas;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");



            SqlCommand cmd = new SqlCommand("SELECT * FROM returnUPSA()", conn);
            // cmd.CommandType=CommandType.StoredProcedure;  
            cmd.Parameters.AddWithValue("@username", "username");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ViewBag.UPSA = dt;

            cmd = new SqlCommand("SELECT * FROM returnUPSB()", conn);
            // cmd.CommandType=CommandType.StoredProcedure;  
            cmd.Parameters.AddWithValue("@username", "username");
            da = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da.Fill(dt2);
            ViewBag.UPSB = dt2;

            
            cmd = new SqlCommand("SELECT * FROM returnAC20()", conn);
            // cmd.CommandType=CommandType.StoredProcedure;  
            cmd.Parameters.AddWithValue("@username", "username");
            da = new SqlDataAdapter(cmd);
            DataTable dt3 = new DataTable();
            da.Fill(dt3);
            ViewBag.AC20 = dt3;

            cmd = new SqlCommand("SELECT * FROM returnAC5()", conn);
            // cmd.CommandType=CommandType.StoredProcedure;  
            cmd.Parameters.AddWithValue("@username", "username");
            da = new SqlDataAdapter(cmd);
            DataTable dt4 = new DataTable();
            da.Fill(dt4);
            ViewBag.AC5 = dt4;

            cmd = new SqlCommand("SELECT * FROM returnPDUA()", conn);
            // cmd.CommandType=CommandType.StoredProcedure;  
            cmd.Parameters.AddWithValue("@username", "username");
            da = new SqlDataAdapter(cmd);
            DataTable dt5 = new DataTable();
            da.Fill(dt5);
            ViewBag.PDUA = dt5;

            cmd = new SqlCommand("SELECT * FROM returnPDUB()", conn);
            // cmd.CommandType=CommandType.StoredProcedure;  
            cmd.Parameters.AddWithValue("@username", "username");
            da = new SqlDataAdapter(cmd);
            DataTable dt6 = new DataTable();
            da.Fill(dt6);
            ViewBag.PDUB = dt6;

         /*   cmd = new SqlCommand("SELECT * FROM ReporteGeneral('03-04-2021')", conn);
            // cmd.CommandType=CommandType.StoredProcedure;  
            cmd.Parameters.AddWithValue("@username", "username");
            da = new SqlDataAdapter(cmd);
            DataTable dt7 = new DataTable();
            da.Fill(dt7);
            ViewBag.ReporteGeneral = dt7;*/


            cmd = new SqlCommand("SELECT * FROM ReporteGeneral()", conn);
            // cmd.CommandType=CommandType.StoredProcedure;  
            cmd.Parameters.AddWithValue("@username", "username");
            da = new SqlDataAdapter(cmd);
            DataTable dt8 = new DataTable();
            da.Fill(dt8);


            ViewBag.ReporteGeneral = dt8;



            ReporteVisitaModelList Model = new ReporteVisitaModelList()
            {
                DataList  = new List<ReporteVisitaModel>()

            };

         /*   for (int i = 0; i < dt.Rows.Count; i++) {

                DataRow dr = dt8.Rows[i];
                Model.DataList.Add(new ReporteVisitaModel { 
                
                Fecha = dr["FECHA"].ToString(),
                Operador = dr["USERNAME"].ToString()

                
                });
            
            
            }*/

           






            /* SqlCommand c = new SqlCommand(" SELECT TOP " +
                 "(1000) HORA_INICIO AS 'Hora Inicio',FECHA AS 'Fecha',TEMPERATURA AS 'Temperatura',  VOLTAJE_ENTRADA_L12 AS 'Voltaje Entrada 12'," +
                 "  VOLTAJE_ENTRADA_L23 AS 'Voltaje Entrada 23',  VOLTAJE_ENTRADA_L31 AS 'Voltaje Entrada 31'," +
                 "  VOLTAJE_SALIDA_L12 AS 'Voltaje Salida 12',  VOLTAJE_SALIDA_L23 AS 'Voltaje Salida 23',  VOLTAJE_SALIDA_L31 AS 'Voltaje Salida 31'," +
                 "  VOLTAJE_BYPASS AS 'Voltaje Baterias',  AMPERAJE_BYPASS  AS 'Amperaje Baterias'  FROM[SistemaVisitas].[dbo].UPSA UPSA join REGISTROVISITAS RV on UPSA.IDUPSA = RV.IDUPSA  ");*/


            var items = db.REGISTROVISITAS.ToList();

            return View(Model);
        }

        public ActionResult Graficos()
        {

            return View();
        }


            [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}