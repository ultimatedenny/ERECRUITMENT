using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERECRUITMENT_WEB.Class;
using System.ComponentModel.DataAnnotations;

namespace ERECRUITMENT_WEB.Models
{
    public class IMPORTEXCEL
    {
        [Required(ErrorMessage = "Please select file")]
        [FileExt(Allow = ".xls,.xlsx", ErrorMessage = "Only excel file")]
        public HttpPostedFileBase file { get; set; }
    }
}