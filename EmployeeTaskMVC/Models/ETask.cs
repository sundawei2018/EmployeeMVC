namespace EmployeeTaskMVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ETask
    {
        [Key]
        public int TaskId { get; set; }

        public int EmployeeId { get; set; }

        public string TaskName { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime Deadline { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
