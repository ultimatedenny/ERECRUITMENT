using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERECRUITMENT_BROADCASTER.Model
{
    public class ModelDBContact
    {
        public string NameEmp { get; set; }
        public string PhoneEmp { get; set; }
        public string BatchEmp { get; set; }
        public string InvitationEmp { get; set; }
        public string StatusEmp { get; set; }
        public string Remark { get; set; }
    }
    public class ModelGoogleContact
    {
        public string Name { get; set; }
        public string PhoneNumbers { get; set; }
        public string ResourceName { get; set; }
    }
    public class ModelTelegramContact
    {
        public string Phone { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public int Id { get; set; }
    }
}
