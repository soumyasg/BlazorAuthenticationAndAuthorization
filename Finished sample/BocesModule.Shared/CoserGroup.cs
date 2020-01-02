using System.ComponentModel.DataAnnotations;

namespace BocesModule.Shared
{
    public class CoSerGroup
    {
        public virtual int CoSerGroupId { get; set; }

        [Required]
        public virtual string CoSerGroupCode { get; set; }

        [Required]
        public virtual string CoSerGroupName { get; set; }
    }
}
