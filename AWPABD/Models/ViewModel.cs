using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace AWPABD.Models
{
    public class ViewModel
    {
        public SelectList ServersList { get; set; }
        public string SelectedServer { get; set; }
        public SelectList ProceduryList { get; set; }
        public string SelectedProcedura { get; set; }

        public DataSet data { get; set; }

        public DataTableCollection Tables { get; }
    }
}