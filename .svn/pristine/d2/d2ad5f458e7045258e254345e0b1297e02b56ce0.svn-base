using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Web;


namespace ERECRUITMENT_WEB.Class
{
    public class ConnectToSharedFolder : IDisposable
    {
        readonly string _networkName;

        public ConnectToSharedFolder(string networkName, NetworkCredential credentials)
        {
            _networkName = networkName;

            var netResource = new NetResource
            {
                Scope = ResourceScope.GlobalNetwork,
                ResourceType = ResourceType.Disk,
                DisplayType = ResourceDisplaytype.Share,
                RemoteName = networkName
            };

            var userName = string.IsNullOrEmpty(credentials.Domain)
                ? credentials.UserName
                : string.Format(@"{0}\{1}", credentials.Domain, credentials.UserName);

            var result = WNetAddConnection2(
                netResource,
                credentials.Password,
                userName,
                0);

            if (result != 0)
            {
                throw new Win32Exception(result, "Error connecting to remote share");
            }
        }

        ~ConnectToSharedFolder()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            WNetCancelConnection2(_networkName, 0, true);
        }

        [DllImport("mpr.dll")]
        private static extern int WNetAddConnection2(NetResource netResource,
            string password, string username, int flags);

        [DllImport("mpr.dll")]
        private static extern int WNetCancelConnection2(string name, int flags,
            bool force);

        [StructLayout(LayoutKind.Sequential)]
        public class NetResource
        {
            public ResourceScope Scope;
            public ResourceType ResourceType;
            public ResourceDisplaytype DisplayType;
            public int Usage;
            public string LocalName;
            public string RemoteName;
            public string Comment;
            public string Provider;
        }

        public enum ResourceScope : int
        {
            Connected = 1,
            GlobalNetwork,
            Remembered,
            Recent,
            Context
        };

        public enum ResourceType : int
        {
            Any = 0,
            Disk = 1,
            Print = 2,
            Reserved = 8,
        }

        public enum ResourceDisplaytype : int
        {
            Generic = 0x0,
            Domain = 0x01,
            Server = 0x02,
            Share = 0x03,
            File = 0x04,
            Group = 0x05,
            Network = 0x06,
            Root = 0x07,
            Shareadmin = 0x08,
            Directory = 0x09,
            Tree = 0x0a,
            Ndscontainer = 0x0b
        }


        string USEID = System.Configuration.ConfigurationManager.AppSettings["USEID"];
        string USEPASS = System.Configuration.ConfigurationManager.AppSettings["USEPASS"];
        string PATH = System.Configuration.ConfigurationManager.AppSettings["PATH"];

        public string networkPath = @"\\172.18.100.125\sbm_bike_common\EDP\IT-BPR\40. Project\10 APPS\IDA - BIKE\PRJ_SBM-BIKE-e-Recruitment PHASE II FRM 210203 TILL -\90. TEMPLATE UPLOAD";

        NetworkCredential credentials = new NetworkCredential(@""+ System.Configuration.ConfigurationManager.AppSettings["USEID"] + "", ""+ System.Configuration.ConfigurationManager.AppSettings["USEPASS"]+"");
        public string myNetworkPath = string.Empty;

        public byte[] DownloadFileByte(string DownloadURL)
        {
            byte[] fileBytes = null;

            using (new ConnectToSharedFolder(networkPath, credentials))
            {
                var fileList = Directory.GetDirectories(networkPath);

                foreach (var item in fileList) { if (item.Contains("ClientDocuments")) { myNetworkPath = item; } }

                myNetworkPath = myNetworkPath + DownloadURL;

                try
                {
                    fileBytes = File.ReadAllBytes(myNetworkPath);
                }
                catch (Exception ex)
                {
                    string Message = ex.Message.ToString();
                }
            }

            return fileBytes;
        }
    }
    
}