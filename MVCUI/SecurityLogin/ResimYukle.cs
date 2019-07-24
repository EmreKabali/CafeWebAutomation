using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MVCUI.SecurityLogin
{
    public   class ResimYukle
    {
        public static string UploadSingleImage(string serverPath, HttpPostedFileBase file)
        {
            if (file != null)
            {

                var uniqueName = Guid.NewGuid();
                serverPath = serverPath.Replace("~", string.Empty);

                var fileArray = file.FileName.Split('.');
                string extension = fileArray[fileArray.Length - 1].ToLower();//. dam sonraki kısmını alır (jpg,png)
                var fileName = uniqueName + "." + extension; //dosyanın adını alır.

                if (extension == "jpg" || extension == "png" || extension == "jpeg" || extension == "gif")
                {
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath + fileName)))
                    {
                        return "1";
                    }
                    else
                    {
                        var filePath = HttpContext.Current.Server.MapPath(serverPath + fileName);
                        file.SaveAs(filePath);
                        return serverPath + fileName;

                    }
                }
                else
                {
                    return "2";
                }

            }
            else
            {
                return "0";
            }
        }
    }
}