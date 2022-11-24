using System.ComponentModel;

namespace Application.Abstractions.Services.RabbitMQ;

public class RabbitMQConsts
{
    /// yaşam süresi
    public static int MessagesTTL { get; set; } = 1000 * 60 * 60 * 2;

    //Aynı anda - Eşzamanlı e-posta gönderimi sayısı, thread açma için sınırı belirleriz
    public static ushort ParallelThreadsCount { get; set; } = 3;
    public static string EmailSender = "EmailSender";
    public enum RabbitMqConstsList
    {
        [Description("EmailSender")]
        QueueNameEmail = 1,
        [Description("QueueNameSms")]
        QueueNameSms = 2
    }

}