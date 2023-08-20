namespace DTI.Models.Entities
{
    public class Society
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Domicile { get; set; }
        public string IdentityNumber { get; set; }
        public string IdentityFamilyNumber { get; set; }
        public string TaxNumber { get; set; }
        public string BPJSNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string SelfiePhoto { get; set; }
        public bool IsActive { get; set; }
    }
}
