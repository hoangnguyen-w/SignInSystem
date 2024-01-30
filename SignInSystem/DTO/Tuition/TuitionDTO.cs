#nullable disable
namespace SignInSystem.DTO.Tuition
{
    public class TuitionDTO
    {
        public string ClassID { get; set; } 

        public string StudentID { get; set; }   

        public int TuitionTypeID { get; set; }

        //public float TuitionAmount { get; set; }

        public float Discount { get; set; }

        public string Discription { get; set; }
    }
}
