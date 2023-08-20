namespace DTI.Services.Interfaces
{
    public interface IClientExternalRepository
    {
        Task<bool> ValidateDukcapil(string identityNumber, string IdentityFamilyNumber);
        Task<bool> ValidateTelco(string phone);
        Task<bool> ValidateBPJS(string bpjsNumber);
        Task<bool> ValidateTax(string taxNumber);
    }
}
