using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SistemaVisitas.Models;
using Excel = Microsoft.Office.Interop.Excel;


namespace SistemaVisitas.Controllers
{
    public class RoomsController : Controller
    {
        SistemaVisitasEntitites db = new SistemaVisitasEntitites();
        private ApplicationDbContext context = new ApplicationDbContext();




        static GeneratorRoomViewModel generatorWeek = new GeneratorRoomViewModel
        {

            IDGR = 0,
            NIVEL_COMBUSTIBLE = 0,
            PRUEBA_BOMBA = true,

            CONTACTOS_BATERIA = true,
            CARGADOR_BATERIA = 0,
            POSICION_BREAKERS = true,
            FUGA_ACEITE = false,
            TABLERO_G1 = true,
            TABLERO_G2 = true,
            EXTINTOR = true,
            DESAGUE_OBSTRUIDO = true,
            VALVULA_DESAGUE = true,
            NIVEL_GASOIL = 0,
            LETREROS = true,
            LIMPIEZA_GENERAL = true,
            VALVULA_TANQUES = true,
            

        };

        static TimeSpan HoraInicio;
        static UPSAViewModel uPSA;
        static UPSBViewModel uPSB;
        static EntranceRoomViewModel entranceRoom;
        static GeneratorRoomViewModel generatorRoom;
        static ServerRoomViewModel serverRoom;
        static OdcOfficeViewModel odcOffice;




        // GET: Rooms
        public ActionResult Index()
        {
            
            return View();
        }

        [Authorize]
        public ActionResult EntranceRoom()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult EntranceRoom( EntranceRoomViewModel model)
        {


            if (ModelState.IsValid)
            {
                entranceRoom = model;
                return RedirectToAction("UPSA");
            }

            else
            {

                return View();
            }
           

        }

        [Authorize]
        public ActionResult GeneratorRoom()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GeneratorRoom(GeneratorRoomViewModel model)
        {

            if (ModelState.IsValid)
            {
                generatorRoom = model;

                db.ENTRANCEROOMs.Add(entranceRoom);
                db.GENERATORROOMs.Add(generatorRoom);
                db.SERVERROOMs.Add(serverRoom);
                db.ODCOFFICEs.Add(odcOffice);
                db.UPSAs.Add(uPSA);
                db.UPSBs.Add(uPSB);
                db.SaveChanges();
                var x = DateTime.Now;

                RegistroVisitasViewModel registro = new RegistroVisitasViewModel()
                {

                    IDER = entranceRoom.IDER,
                    IDGR = generatorRoom.IDGR,
                    IDSR = serverRoom.IDSR,
                    IDODC = odcOffice.IDODC,
                    IDUPSA = uPSA.IDUPSA,
                    IDUPSB = uPSB.IDUPSB,
                    HORA_INICIO = HoraInicio,
                    HORA_FINAL = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0),
                    FECHA = DateTime.Now,
                    USERNAME = User.Identity.GetUserName()



                };

                db.SaveChanges();

                db.REGISTROVISITAS.Add(registro);

                db.SaveChanges();


                return RedirectToAction("Index", "Home");

            }

            else
            {
                return View();
            }


        }

        [Authorize]
        public ActionResult UPSA()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UPSA(UPSAViewModel model)
        {
           

            if ((DateTime.Now.DayOfWeek == DayOfWeek.Saturday) && DateTime.Now.Hour >= 10 && DateTime.Now.Hour < 13 )
            {

                if (ModelState.IsValid)
                {
                    uPSA = model;

                    return RedirectToAction("GeneratorRoom");
                }

                else
                {
                    return View();
                }





            }
            else {

                if (ModelState.IsValid)
                {
                    uPSA = model;

                    db.ENTRANCEROOMs.Add(entranceRoom);
                    db.GENERATORROOMs.Add(generatorWeek);
                    db.SERVERROOMs.Add(serverRoom);
                    db.ODCOFFICEs.Add(odcOffice);
                    db.UPSAs.Add(uPSA);
                    db.UPSBs.Add(uPSB);
                    db.SaveChanges();
                    var x = DateTime.Now;

                    RegistroVisitasViewModel registro = new RegistroVisitasViewModel()
                    {

                        IDER = entranceRoom.IDER,
                        IDGR = generatorWeek.IDGR, //Aqui envio el mismo ID que UPSA por que los dias normales, el generator room no se le hace visita. Cambio a ultimo momento.
                        IDSR = serverRoom.IDSR,
                        IDODC = odcOffice.IDODC,
                        IDUPSA = uPSA.IDUPSA,
                        IDUPSB = uPSB.IDUPSB,
                        HORA_INICIO = HoraInicio,
                        HORA_FINAL = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0),
                        FECHA = DateTime.Now,
                        USERNAME = User.Identity.GetUserName()



                    };

                    db.SaveChanges();

                    db.REGISTROVISITAS.Add(registro);

                    db.SaveChanges();


                    return RedirectToAction("Index", "Home");

                }

                else
                {
                    return View();
                }


            }
            
            
            
           

        }

        [Authorize]
        public ActionResult UPSB()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UPSB(UPSBViewModel model)
        {

            if (ModelState.IsValid)
            {
                uPSB = model;

                return RedirectToAction("EntranceRoom");
            }

            else
            {
                return View();
            }
         
        }

        [Authorize]
        public ActionResult ODCOffice()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ODCOffice(OdcOfficeViewModel model)
        {

            if (ModelState.IsValid)
            {
                odcOffice = model;

                return RedirectToAction("ServerRoom");
            }

            else
            {
                return View();
            }


        }

        [Authorize]
        public ActionResult ServerRoom()
        {
            HoraInicio = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0);
            
            return View();
        }

      
        public JsonResult GetDevicesPerRack(string rackName) {


            int column = 0;

            switch (rackName) {
                case "1":
                    column = 0;
                    break;
                case "2":
                    column = 1;
                    break;
                case "3":
                    column = 2;
                    break;
                case "4":
                    column = 3;
                    break;
                case "5":
                    column = 4;
                    break;
                case "11":
                    column = 5;
                    break;
                case "12":
                    column = 6;
                    break;
                case "13":
                    column = 7;
                    break;
                case "14":
                    column = 8;
                    break;
                case "15":
                    column = 9;
                    break;
                case "16A":
                    column = 10;
                    break;
                case "16B":
                    column = 11;
                    break;
                case "21":
                    column = 12;
                    break;
                case "22":
                    column = 13;
                    break;
                case "23":
                    column = 14;
                    break;
                case "24":
                    column = 15;
                    break;
                case "25A":
                    column = 16;
                    break;
                case "25B":
                    column = 17;
                    break;
                case "26A":
                    column = 18;
                    break;
                case "26B":
                    column = 19;
                    break;
                case "27":
                    column = 20;
                    break;
                case "28":
                    column = 21;
                    break;
                case "29":
                    column = 22;
                    break;
                default:
                    column = 23;
                    break;
            }


            List<string> xx = new List<string>();

            string con =
     @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:/Users/Junio/source/repos/SistemaVisitas/SistemaVisitas/Data/data.xls;" +
     @"Extended Properties='Excel 8.0;HDR=Yes;'";
            using (OleDbConnection connection = new OleDbConnection(con))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from [Sheet1$]", connection);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var row1Col0 = dr[column];
                        xx.Add(row1Col0.ToString());

                    }
                }
            }


            return Json(xx, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ServerRoom(ServerRoomViewModel model)
        {
           if (ModelState.IsValid)
            {
                serverRoom = model;
                return RedirectToAction("UPSB");
            }

            else {

                return View();
            }
           
        }
    }
}