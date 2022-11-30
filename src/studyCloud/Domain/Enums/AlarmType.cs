using System.ComponentModel;

namespace Domain.Enums;

public enum AlarmType
{
    [Description("{0} sizi takip etmeye başladı.")]
    FOLLOW,

    [Description("{0} gönderinizi beğendi.")]
    LIKE_POST,
    [Description("{0} bir gönderide sizden bahsetti: {1}")]
    MENTION_POST,
    
    [Description("{0} gönderinize şu yorumu yaptı: {1}")]
    COMMENT,
    [Description("{0} yorumunuzu beğendi: {1}")]
    LIKE_COMMENT,
    [Description("{0} bir yorumda sizden bahsetti: {1}")]
    MENTION_COMMENT,
}