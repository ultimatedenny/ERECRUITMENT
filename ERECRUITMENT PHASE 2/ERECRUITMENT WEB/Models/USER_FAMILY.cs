using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERECRUITMENT_WEB.Models
{
    public class USER_FAMILY
    {
        public string BATCH_EMP { get; set; }
        public string NOKK { get; set; }
        public string IMG_KK { get; set; }

        public string FATHER_NAME { get; set; }
        public string FATHER_AGE { get; set; }
        public string FATHER_JOB { get; set; }
        public string FATHER_NIK { get; set; }
        public string FATHER_BIRTHPLACE { get; set; }
        public string FATHER_BIRTHDATE { get; set; }
        public bool FATHER_ALIVE { get; set; }
        public string FATHER_MOBILE { get; set; }

        public string MOTHER_NAME { get; set; }
        public string MOTHER_AGE { get; set; }
        public string MOTHER_JOB { get; set; }
        public string MOTHER_NIK { get; set; }
        public string MOTHER_BIRTHPLACE { get; set; }
        public string MOTHER_BIRTHDATE { get; set; }
        public bool MOTHER_ALIVE { get; set; }
        public string MOTHER_MOBILE { get; set; }
    }
    public class USER_SIBLINGS
    {
        public string BATCH_EMP { get; set; }
        public string SIBLINGS_NAME { get; set; }
        public string SIBLINGS_AGE { get; set; }
        public string SIBLINGS_JOB { get; set; }
    }

    public class USER_SPOUSE
    {
        public string BATCH_EMP { get; set; }
        public bool ISFAMILY { get; set; }
        public string WIFE_NAME { get; set; }
        public string WIFE_NIK { get; set; }
        public string WIFE_BIRTH_PLACE { get; set; }
        public string WIFE_BIRTH_DATE { get; set; }
        public string WIFE_MOBILE { get; set; }
        public string BNIKAH { get; set; }
    }
    public class USER_CHILD
    {
        public string BATCH_EMP { get; set; }
        public string CHILD_NAME { get; set; }
        public string CHILD_NIK { get; set; }
        public string CHILD_BIRTH_PLACE { get; set; }
        public string CHILD_BIRTH_DATE { get; set; }
        public string CHILD_MOBILE { get; set; }
        public string CHILD_DOC { get; set; }
    }
}