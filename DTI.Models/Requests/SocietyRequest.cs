using System.ComponentModel.DataAnnotations;

namespace DTI.Models.Requests
{
    public class SocietyRequest
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Domicile { get; set; }
        [Required]
        public string IdentityNumber { get; set; }
        [Required]
        public string IdentityFamilyNumber { get; set; }
        [Required]
        public string TaxNumber { get; set; }
        [Required]
        public string BPJSNumber { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string SelfiePhoto { get; set; }
    }
}
