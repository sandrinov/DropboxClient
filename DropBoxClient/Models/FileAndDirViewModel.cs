using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DropBoxClient.Models
{
    public class FileViewModel
    {
        public ulong Size { get; set; }
        public String Name { get; set; }
    }
    public class FileUploadViewModel
    {
        [Required]
        public HttpPostedFileBase File { get; set; }
    }
    public class DirViewModel
    {
        public String Path { get; set; }
        public String Name { get; set; }
    }
}