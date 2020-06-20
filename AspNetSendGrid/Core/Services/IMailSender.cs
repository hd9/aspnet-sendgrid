using System.Threading.Tasks;

namespace AspNetSendGrid.Core.Services
{
    public interface IMailSender
    {
        Task Send(SendMail msg);
    }
}