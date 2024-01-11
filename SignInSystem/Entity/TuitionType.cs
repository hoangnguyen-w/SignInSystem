using System.ComponentModel.DataAnnotations;
#nullable disable
namespace SignInSystem.Entity
{
    public class TuitionType
    {
        [Key]
        public int TuitionTypeID { get; set; }

        public string TuitionTypeName { get; set; }

    }
}
