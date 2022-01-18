using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace AWPABD.Models
{
    public class ViewModel
    {
        [Required(ErrorMessage = "To pole jest wymagane")]
        public SelectList ServersList { get; set; }
        [Required(ErrorMessage = "Proszę wybrać serwer")]
        public string SelectedServer { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane")]
        public SelectList ProceduryList { get; set; }
        [Required(ErrorMessage = "Proszę wybrać procedurę")]
        public string SelectedProcedura { get; set; }

        public DataSet data { get; set; }

        public DataTableCollection Tables { get; }
    }
}