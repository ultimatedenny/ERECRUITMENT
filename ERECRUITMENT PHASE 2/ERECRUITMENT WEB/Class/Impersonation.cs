﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Security.Principal;
using System.Runtime.InteropServices;
using System.Web;

namespace ERECRUITMENT_WEB.Class
{
    public class Impersonation
    {
        public const int LOGON32_PROVIDER_DEFAULT = 0;
        public const int LOGON32_LOGON_INTERACTIVE = 2; // local machine accounts only
        public const int LOGON32_LOGON_NETWORK = 3; // active directory only
        public const int LOGON32_LOGON_NEW_CREDENTIALS = 9; // always works (useless)

        public WindowsImpersonationContext impersonationContext;
        public WindowsIdentity windowsIdentity;

        [DllImport("advapi32.dll")] // unicode
        public static extern int LogonUser(String lpszUserName, String lpszDomain, String lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

        [DllImport("advapi32.dll")] // ascii
        public static extern int LogonUserA(String lpszUserName, String lpszDomain, String lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool RevertToSelf();

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool CloseHandle(IntPtr handle);

        public bool Impersonate(String username, String password, String domain)
        {
            IntPtr token = IntPtr.Zero;
            if (RevertToSelf())
            {
                if (LogonUser(username, domain, password, LOGON32_LOGON_NETWORK, LOGON32_PROVIDER_DEFAULT, ref token) != 0)
                {
                    windowsIdentity = new WindowsIdentity(token);
                    impersonationContext = windowsIdentity.Impersonate();
                    if (impersonationContext != null)
                    {
                        CloseHandle(token);
                        return true;
                    }
                }
            }
            if (token != IntPtr.Zero)
                CloseHandle(token);

            if (impersonationContext != null)
                return false;

            return false;
        }

        public void Undo()
        {
            if (impersonationContext != null)
                impersonationContext.Undo();
        }
    }
}