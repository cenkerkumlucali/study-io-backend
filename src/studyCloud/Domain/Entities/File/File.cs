using System.ComponentModel.DataAnnotations.Schema;
using BaseEntity = Domain.Entities.Common.BaseEntity;

namespace Domain.Entities.File;

public class File : BaseEntity
{
    public string FileName { get; set; }
    public string Path { get; set; }
    public string Storage { get; set; }
    [NotMapped]
    public override DateTime UpdatedDate { get; set; }
}