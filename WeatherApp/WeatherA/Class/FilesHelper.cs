using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WeatherA.Class
{
    public class FilesHelper
    {
        public static bool UploadImage(HttpPostedFileBase file, string folder, string name)
        {
            if (file == null || string.IsNullOrEmpty(folder) || string.IsNullOrEmpty(name))
            {
                return false;
            }
            try
            {
                string path = string.Empty;
                path = Path.Combine(HttpContext.Current.Server.MapPath(folder), name);
                file.SaveAs(path);
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public static bool UploadImagePath(String file, string folder, string name)
        {
            if (file == null || string.IsNullOrEmpty(folder) || string.IsNullOrEmpty(name))
            {
                return false;
            }
            try
            {
                string Pic_Path = Path.Combine(HttpContext.Current.Server.MapPath(folder), name);
                using (FileStream fs = new FileStream(Pic_Path, FileMode.Create))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        byte[] data = Convert.FromBase64String(file);
                        bw.Write(data);
                        bw.Close();
                    }
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


    }
}