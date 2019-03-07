using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TickToolCloud.Entities.Entity;

namespace TickCloud.ClientWebApp.Models
{
    public class Folder
    {
       // public Folder();

        public int Id { get; set; }
        public string FolderName { get; set; }
        public DateTime DateCreated { get; set; }
        public string Location { get; set; }
      
       // public ICollection<Folder> SubFolders { get; set; }
        public Folder ParentFolder { get; set; }
        public int? ParentFolderId { get; set; }
        public ICollection<FileMaster> SubFiles { get; set; }
    }
}
