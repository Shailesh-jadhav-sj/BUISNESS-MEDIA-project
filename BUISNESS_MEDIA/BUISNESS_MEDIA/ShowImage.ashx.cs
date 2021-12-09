using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace BUISNESS_MEDIA
{
    /// <summary>
    /// Summary description for ShowImage
    /// </summary>
    public class ShowImage : IHttpHandler   
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");

        }

        public Stream ShowEmpImage(byte value)
        {
            return new MemoryStream(value);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}