using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace School_MS.Models
{
    public class tblQuestion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? SubjectId { get; set; }
        public int? Chaptertid { get; set; }
        [Display(Name ="Question No")]
        [Required(ErrorMessage = "* Question No is Required")]
        public string QuestionNo { get; set; }
        [Display(Name = "Question Name")]
        [Required(ErrorMessage = "* Question Name is Required")]
        public string QuestionName { get; set; }

        public string QuestionAnswer{ get; set; }
        public string ImageUrl{ get; set; }
        public string VideoUrl{ get; set; }
        public DateTime? CreatedDate{ get; set; }
        public DateTime? CreatedBy{ get; set; }
        

        [ForeignKey("SubjectId")]
        public tblSubject tblSubject { get; set; }
        [ForeignKey("Chaptertid")]
        public tblChapter tblChapter { get; set; }
    }
}
