using System.Net;
using System.Net.Sockets;

namespace ApiDigitalLesson.Common.Services.Impl
{
    /// <summary>
    /// Класс для работы с Ip
    /// </summary>
    public class IpHelper
    {
        /// <summary>
        /// Получить Ip адрес 
        /// </summary>
        public static string GetIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return string.Empty;
        }
    }
}
