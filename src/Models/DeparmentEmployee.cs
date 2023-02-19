using System.ComponentModel.DataAnnotations.Schema;

namespace BET.Models
{
    public class DeparmentEmployee : Entity<long>
    {
        public long DeparmentId { get; set; }

        public long EmployeeId { get; set; }

        [ForeignKey(nameof(DeparmentId))]
        public Deparment Deparment { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
    }
}
