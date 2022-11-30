namespace Application.Exceptions;

public static class ErrorCode
{
    public static string MEMBER_NOT_FOUND = "Böyle bir kullanıcı yoktur.";
    public static string BLOCK_MYSELF_FAIL = "Kendini engelleyemezsin.";
    public static string MISMATCHED_ALARM_TYPE = "Alarm formatı yanlış.";
    public static string POST_CANT_DELETE = "Bir gönderinin yalnızca yayıncısı silinebilir.";
}