using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practical_WAD.Models
{
    public class Exam
    {
        public int id { get; set; }
        public int subjectId { get; set; }
        public virtual Subject Subject { get; set; }

        [DataType(DataType.Time)]
        [Required(ErrorMessage = "Vui lòng nhập giờ!")]

        public DateTime startTime { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngày !")]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime examDate { get; set; }
        public int dutation { get; set; }
        public int classroomId { get; set; }
        public virtual Classroom Classroom { get; set; }
        public int falcultyId { get; set; }
        public virtual Falculty Falculty { get; set; }
        public int statusId { get; set; }
        public virtual Status Status { get; set; }
    }
}