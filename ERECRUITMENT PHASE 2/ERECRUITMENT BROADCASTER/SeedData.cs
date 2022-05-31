using System;
using System.Collections.Generic;
using NLog;

namespace ERECRUITMENT_BROADCASTER
{
    public class SeedData
    {
        private static Logger Logger = LogManager.GetCurrentClassLogger();

        public static void Seed()
        {
            CreateNavigation();
        }
        private static void CreateNavigation()
        {
            var sqlCheck = "SELECT TOP 1 * FROM menulist WHERE [Group] = 'ER'";
            var sqlStatement = new List<string>
            {
                "INSERT INTO menulist([Group], MnuSeq, MnuCod, MnuLev, MnuNam, MnuNod, MnuPrt, MnuAct, FRMNAM, Pic) VALUES('ER',1  ,1      ,0,'ER'                      ,'AR'  ,'AR' ,' ', NULL                                                 , 'FORM.ICO')",
                "INSERT INTO menulist([Group], MnuSeq, MnuCod, MnuLev, MnuNam, MnuNod, MnuPrt, MnuAct, FRMNAM, Pic) VALUES('ER',2  ,2000000,1,'Menu'                    ,'AR2' ,'AR' ,' ', NULL                                                 , '')",
                "INSERT INTO menulist([Group], MnuSeq, MnuCod, MnuLev, MnuNam, MnuNod, MnuPrt, MnuAct, FRMNAM, Pic) VALUES('ER',210,2100000,2,'Home'                    ,'AR21','AR2',' ', 'ERECRUITMENT BROADCASTER.Home'                              , 'home_icon')",
                "INSERT INTO menulist([Group], MnuSeq, MnuCod, MnuLev, MnuNam, MnuNod, MnuPrt, MnuAct, FRMNAM, Pic) VALUES('ER',220,2200000,2,'Batch Info'              ,'AR22','AR2',' ', 'ERECRUITMENT BROADCASTER.BatchInfo'                         , 'batch_icon')",
                "INSERT INTO menulist([Group], MnuSeq, MnuCod, MnuLev, MnuNam, MnuNod, MnuPrt, MnuAct, FRMNAM, Pic) VALUES('ER',230,2300000,2,'Batch Upload'            ,'AR23','AR2',' ', 'ERECRUITMENT BROADCASTER.BatchUpload'                         , 'batch_icon')",
                "INSERT INTO menulist([Group], MnuSeq, MnuCod, MnuLev, MnuNam, MnuNod, MnuPrt, MnuAct, FRMNAM, Pic) VALUES('ER',240,2400000,2,'Candidate Info'          ,'AR24','AR2',' ', 'ERECRUITMENT BROADCASTER.CandidateInfo'                     , 'candidate_icon')",
                "INSERT INTO menulist([Group], MnuSeq, MnuCod, MnuLev, MnuNam, MnuNod, MnuPrt, MnuAct, FRMNAM, Pic) VALUES('ER',250,2500000,2,'Whatsapp Sender'         ,'AR25','AR2',' ', 'ERECRUITMENT BROADCASTER.Whatsapp'                          , 'whatsapp_icon')",
                "INSERT INTO menulist([Group], MnuSeq, MnuCod, MnuLev, MnuNam, MnuNod, MnuPrt, MnuAct, FRMNAM, Pic) VALUES('ER',260,2600000,2,'Telegram Sender'         ,'AR26','AR2',' ', 'ERECRUITMENT BROADCASTER.Telegram'                          , 'telegram_icon')",
                "INSERT INTO menulist([Group], MnuSeq, MnuCod, MnuLev, MnuNam, MnuNod, MnuPrt, MnuAct, FRMNAM, Pic) VALUES('ER',270,2700000,2,'Setting'                 ,'AR27','AR2',' ', 'ERECRUITMENT BROADCASTER.Setting'                           , 'setting_icon')",
                "INSERT INTO menulist([Group], MnuSeq, MnuCod, MnuLev, MnuNam, MnuNod, MnuPrt, MnuAct, FRMNAM, Pic) VALUES('ER',9  ,9000000,2,'Footer'                  ,'AR9' ,'AR9',' ', NULL                                                 , '')",
                "INSERT INTO menulist([Group], MnuSeq, MnuCod, MnuLev, MnuNam, MnuNod, MnuPrt, MnuAct, FRMNAM, Pic) VALUES('ER',910,9100000,9,'Sign Out'                ,'AR91','AR9',' ', 'exit'                                               , 'signout_icon')",
                "INSERT INTO menulist([Group], MnuSeq, MnuCod, MnuLev, MnuNam, MnuNod, MnuPrt, MnuAct, FRMNAM, Pic) VALUES('ER',920,9200000,9,'About'                   ,'AR92','AR9',' ', 'ERECRUITMENT BROADCASTER.About'                             , 'about_icon')",

                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 1      , NULL, 'SYSTEM-ADMIN')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 2000000, NULL, 'SYSTEM-ADMIN')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 2100000, NULL, 'SYSTEM-ADMIN')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 2200000, NULL, 'SYSTEM-ADMIN')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 2300000, NULL, 'SYSTEM-ADMIN')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 2400000, NULL, 'SYSTEM-ADMIN')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 2500000, NULL, 'SYSTEM-ADMIN')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 2600000, NULL, 'SYSTEM-ADMIN')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 2700000, NULL, 'SYSTEM-ADMIN')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 9000000, NULL, 'SYSTEM-ADMIN')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 9100000, NULL, 'SYSTEM-ADMIN')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 9200000, NULL, 'SYSTEM-ADMIN')",

                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 1      , NULL, 'SYSTEM-USER')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 2000000, NULL, 'SYSTEM-USER')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 2100000, NULL, 'SYSTEM-USER')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 2200000, NULL, 'SYSTEM-USER')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 2300000, NULL, 'SYSTEM-USER')",
                //"INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 2400000, NULL, 'SYSTEM-USER')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 2500000, NULL, 'SYSTEM-USER')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 2600000, NULL, 'SYSTEM-USER')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 2700000, NULL, 'SYSTEM-USER')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 9000000, NULL, 'SYSTEM-USER')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 9100000, NULL, 'SYSTEM-USER')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 9200000, NULL, 'SYSTEM-USER')",

                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 1      , NULL, 'SYSTEM-HUMANRESOURCE')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 2000000, NULL, 'SYSTEM-HUMANRESOURCE')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 2100000, NULL, 'SYSTEM-HUMANRESOURCE')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 2200000, NULL, 'SYSTEM-HUMANRESOURCE')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 2300000, NULL, 'SYSTEM-HUMANRESOURCE')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 2400000, NULL, 'SYSTEM-HUMANRESOURCE')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 2500000, NULL, 'SYSTEM-HUMANRESOURCE')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 2600000, NULL, 'SYSTEM-HUMANRESOURCE')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 2700000, NULL, 'SYSTEM-HUMANRESOURCE')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 9000000, NULL, 'SYSTEM-HUMANRESOURCE')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 9100000, NULL, 'SYSTEM-HUMANRESOURCE')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 9200000, NULL, 'SYSTEM-HUMANRESOURCE')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 9300000, NULL, 'SYSTEM-HUMANRESOURCE')",
                "INSERT INTO levelmenu([group], MnuCod, level, BusFunc) VALUES('ER', 9400000, NULL, 'SYSTEM-HUMANRESOURCE')",
            };

            var result = SysUtl.ExecuteDTQuery(sqlCheck, null);
            if (result.Rows.Count == 0)
            {
                foreach (var sqlInsert in sqlStatement)
                {
                    var count = SysUtl.ExecuteNonQuery(sqlInsert, null);
                    if (count > 0)
                    {
                        Logger.Info(string.Format("Created {0} in database", sqlInsert));
                    }
                    else
                    {
                        Logger.Info(string.Format("Seed failed for unknown reason {0}", sqlInsert));
                    }
                }
            }
            else
            {
                Logger.Info("Skipped, because data already exists !");
            }
        }
    }
}