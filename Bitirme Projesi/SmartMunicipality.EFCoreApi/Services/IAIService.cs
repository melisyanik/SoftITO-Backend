namespace SmartMunicipality.EFCoreApi.Services
{
    public interface IAIService
    {
        Task<string> AskQuestionAsync(string prompt);
    }
}
