using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace School_MS.Models
{
    public class tblChapter
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ChaptertName { get; set; }
        public int? SubjectID { get; set; }

        [ForeignKey("SubjectID")]
        public tblSubject tblSubject { get; set; }
    }
}
