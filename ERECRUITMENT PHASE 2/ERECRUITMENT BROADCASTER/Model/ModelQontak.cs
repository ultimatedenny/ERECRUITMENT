using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERECRUITMENT_BROADCASTER.Model
{
    public class MQ_Auth
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
        public int created_at { get; set; }
    }

    /// <summary>
    /// ///MQ_WA_Channel_
    /// </summary>
    public class MQ_WA_Channel_Settings
    {
        public string domain_server { get; set; }
        public string authorization { get; set; }
        public string account_name { get; set; }
        public string server_wa_id { get; set; }
    }

    public class MQ_WA_Channel_Datum
    {
        public string id { get; set; }
        public string target_channel { get; set; }
        public string webhook { get; set; }
        public MQ_WA_Channel_Settings settings { get; set; }
        public string organization_id { get; set; }
        public DateTime created_at { get; set; }
    }

    public class MQ_WA_Channel_Cursor
    {
        public string next { get; set; }
        public string prev { get; set; }
    }

    public class MQ_WA_Channel_Pagination
    {
        public MQ_WA_Channel_Cursor cursor { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
        public int total { get; set; }
    }

    public class MQ_WA_Channel_Meta
    {
        public MQ_WA_Channel_Pagination pagination { get; set; }
    }

    public class MQ_WA_Channel_Root
    {
        public string status { get; set; }
        public List<MQ_WA_Channel_Datum> data { get; set; }
        public MQ_WA_Channel_Meta meta { get; set; }
    }
    /// <summary>
    /// ///MQ_WA_Channel_
    /// </summary>
    /// 



    /// <summary>
    /// ///MQ_WA_Temp_
    /// </summary>
    /// 
    public class MQ_WA_Temp_Datum
    {
        public string id { get; set; }
        public string name { get; set; }
        public string language { get; set; }
        public object header { get; set; }
        public string body { get; set; }
        public object footer { get; set; }
        public string status { get; set; }
        public string category { get; set; }
    }

    public class MQ_WA_Temp_Cursor
    {
        public string next { get; set; }
        public string prev { get; set; }
    }

    public class MQ_WA_Temp_Pagination
    {
        public MQ_WA_Temp_Cursor cursor { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
        public int total { get; set; }
    }

    public class MQ_WA_Temp_Meta
    {
        public MQ_WA_Temp_Pagination pagination { get; set; }
    }

    public class MQ_WA_Temp_Root
    {
        public string status { get; set; }
        public List<MQ_WA_Temp_Datum> data { get; set; }
        public MQ_WA_Temp_Meta meta { get; set; }
    }
    /// <summary>
    /// ///MQ_WA_Temp_
    /// </summary>
    /// 

    /// <summary>
    /// ///MQ_WA_CONTACT_
    /// </summary>
    /// 
    public class MQ_WA_CONTACT_ErrorMessages
    {
    }

    public class MQ_WA_CONTACT_Datum
    {
        public string id { get; set; }
        public string organization_id { get; set; }
        public string source_type { get; set; }
        public object source_id { get; set; }
        public string name { get; set; }
        public int contacts_count { get; set; }
        public int contacts_count_success { get; set; }
        public int contacts_count_failed { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<string> contact_variables { get; set; }
        public DateTime finished_at { get; set; }
        public MQ_WA_CONTACT_ErrorMessages error_messages { get; set; }
        public string progress { get; set; }
    }

    public class MQ_WA_CONTACT_Cursor
    {
        public string next { get; set; }
        public string prev { get; set; }
    }

    public class MQ_WA_CONTACT_Pagination
    {
        public MQ_WA_CONTACT_Cursor cursor { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
        public int total { get; set; }
    }

    public class Meta
    {
        public MQ_WA_CONTACT_Pagination pagination { get; set; }
    }

    public class MQ_WA_CONTACT_Root
    {
        public string status { get; set; }
        public List<MQ_WA_CONTACT_Datum> data { get; set; }
        public Meta meta { get; set; }
    }
    /// <summary>
    /// ///MQ_WA_CONTACT_
    /// </summary>
    ///
    public class MQ_WA_CONDET_ErrorMessages
    {
    }

    public class MQ_WA_CONDET_Extra
    {
        public string company { get; set; }
        public string customer_name { get; set; }
    }

    public class MQ_WA_CONDET_Large
    {
        public string url { get; set; }
    }

    public class MQ_WA_CONDET_Medium
    {
        public string url { get; set; }
    }

    public class MQ_WA_CONDET_Small
    {
        public string url { get; set; }
    }

    public class MQ_WA_CONDET_Avatar
    {
        public string url { get; set; }
        public MQ_WA_CONDET_Large large { get; set; }
        public MQ_WA_CONDET_Medium medium { get; set; }
        public MQ_WA_CONDET_Small small { get; set; }
        public object filename { get; set; }
        public int size { get; set; }
    }

    public class MQ_WA_CONDET_Datum
    {
        public string id { get; set; }
        public string phone_number { get; set; }
        public string full_name { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string code { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string channel { get; set; }
        public string status { get; set; }
        public MQ_WA_CONDET_ErrorMessages error_messages { get; set; }
        public MQ_WA_CONDET_Extra extra { get; set; }
        public string account_uniq_id { get; set; }
        public string channel_integration_id { get; set; }
        public MQ_WA_CONDET_Avatar avatar { get; set; }
        public bool is_valid { get; set; }
        public bool is_blocked { get; set; }
        public object contact_handler_id { get; set; }
    }

    public class MQ_WA_CONDET_Cursor
    {
        public string next { get; set; }
        public string prev { get; set; }
    }

    public class MQ_WA_CONDET_Pagination
    {
        public MQ_WA_CONDET_Cursor cursor { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
        public int total { get; set; }
    }

    public class MQ_WA_CONDET_Meta
    {
        public MQ_WA_CONDET_Pagination pagination { get; set; }
    }

    public class MQ_WA_CONDET_Root
    {
        public string status { get; set; }
        public List<MQ_WA_CONDET_Datum> data { get; set; }
        public Meta meta { get; set; }
    }
    public class MQ_WA_UPLOAD_ErrorMessages
    {
    }
    public class MQ_WA_UPLOAD_Data
    {
        public string id { get; set; }
        public string organization_id { get; set; }
        public string source_type { get; set; }
        public object source_id { get; set; }
        public string name { get; set; }
        public int contacts_count { get; set; }
        public int contacts_count_success { get; set; }
        public int contacts_count_failed { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<object> contact_variables { get; set; }
        public object finished_at { get; set; }
        public MQ_WA_UPLOAD_ErrorMessages error_messages { get; set; }
        public string progress { get; set; }
    }

    public class MQ_WA_UPLOAD_Root
    {
        public string status { get; set; }
        public MQ_WA_UPLOAD_Data data { get; set; }
    }



    public class MQ_WA_DIRECT_Body
    {
        public string _1 { get; set; }
    }

    public class MQ_WA_DIRECT_Data
    {
        public string id { get; set; }
        public string name { get; set; }
        public string organization_id { get; set; }
        public string channel_integration_id { get; set; }
        public object contact_list_id { get; set; }
        public string contact_id { get; set; }
        public string target_channel { get; set; }
        public MQ_WA_DIRECT_Parameters parameters { get; set; }
        public DateTime created_at { get; set; }
        public MQ_WA_DIRECT_MessageStatusCount message_status_count { get; set; }
        public MQ_WA_DIRECT_MessageTemplate message_template { get; set; }
    }

    public class MQ_WA_DIRECT_Header
    {
    }

    public class MQ_WA_DIRECT_MessageStatusCount
    {
        public int failed { get; set; }
        public int delivered { get; set; }
        public int read { get; set; }
        public int pending { get; set; }
        public int sent { get; set; }
    }

    public class MQ_WA_DIRECT_MessageTemplate
    {
        public string id { get; set; }
        public string name { get; set; }
        public string language { get; set; }
        public object header { get; set; }
        public string body { get; set; }
        public object footer { get; set; }
        public string status { get; set; }
        public string category { get; set; }
    }

    public class MQ_WA_DIRECT_Parameters
    {
        public MQ_WA_DIRECT_Header header { get; set; }
        public MQ_WA_DIRECT_Body body { get; set; }
    }

    public class MQ_WA_DIRECT_Root
    {
        public string status { get; set; }
        public MQ_WA_DIRECT_Data data { get; set; }
    }
}
