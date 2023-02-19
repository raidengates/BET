using System.ComponentModel.DataAnnotations;

namespace BET.Models
{
    public class Employee : Entity<long>
    {
        /// <summary>
        /// Maximum length of <see cref="EntityTypeFullName"/> property.
        /// Value: 192.
        /// </summary>
        public const int MaxEntityTypeFullNameLength = 192;
        public string? Code { get; set; }

        [StringLength(MaxEntityTypeFullNameLength)]
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public Gender Gender { get; set; }

        public byte[]? Avatar { get; set; }

        public ICollection<DeparmentEmployee>? DeparmentEmployee { get; set; }
    }
}
