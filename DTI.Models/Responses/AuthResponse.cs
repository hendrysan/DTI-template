namespace DTI.Models.Responses
{
    public class AuthResponse
    {

        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expired { get; set; }
    }
}
