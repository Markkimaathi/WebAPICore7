using APIDEV.Modal;


namespace APIDEV.Service
{
    public interface IEmailService
    {
        Task SendEmail(Mailrequest mailrequest);
    }
}