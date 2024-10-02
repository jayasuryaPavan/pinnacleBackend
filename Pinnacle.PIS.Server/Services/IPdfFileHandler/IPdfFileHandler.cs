namespace Pinnacle.PIS.Server.Services
{
    public interface IPdfFileHandler
    {
        Task<string> pdfText(string path);
    }
}
