namespace Web_API_Patients.Data.Entities
{
    public class Patients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PassportNumber { get; set; }

        public int Emirates_ID { get; set; }

        public string Emirate { get; set; }

        public string Address { get; set; }

        public string FirstDose { get; set; }

        public string SecondDose { get; set; }

        public string ThirdDose { get; set; }
        public string ForthDose { get; set; }
        public DateTime? RecordCreatedOn { get; set; }

    }
}
