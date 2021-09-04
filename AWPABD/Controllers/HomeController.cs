using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AWPABD.Models;
using System.Data.SqlClient;

using System.Activities.Statements;
using System.Data;

namespace AWPABD.Controllers
{
    public class HomeController : Controller


    {
        
        public ActionResult Index()
        {
            AWPABDEntities db = new AWPABDEntities();
            //ViewBag.ServersList = new SelectList(GetServerList(), "Id", "Nazwa");
            //ViewBag.ProceduryList = new SelectList(GetProceduraList(), "Id", "Nazwa");


            return View(new ViewModel { ServersList = new SelectList(GetServerList(), "Id", "Nazwa") , ProceduryList = new SelectList(GetProceduraList(), "Id", "Nazwa") });
        }
      


            [HttpPost]
        public ActionResult Index(ViewModel model)
        {
            var GprocL = GetProceduraList().Find(s => s.Id.ToString() == model.SelectedProcedura);
            var GservL = GetServerList().Find(s => s.Id.ToString() == model.SelectedServer);
            
            SqlConnection conn = new SqlConnection("Server = " + GservL.IP + " ; Database = master; Integrated Security = True; MultipleActiveResultSets = True");
            SqlCommand cmd = new SqlCommand(GprocL.Body, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ViewData["ds"] = ds;
            
            model.data = ds;
            model.SelectedProcedura = null;
            model.SelectedServer = null;
            return View ("Index",model);

            
        }


        public List<Servers> GetServerList()
        {
            AWPABDEntities db = new AWPABDEntities();
            List<Servers> servers = db.Servers.ToList();
            return servers;
        }

        public List<Procedury> GetProceduraList()
        {
            AWPABDEntities db = new AWPABDEntities();
            List<Procedury> proceduries = db.Procedury.ToList();
            return proceduries;
        }

    
    }
}