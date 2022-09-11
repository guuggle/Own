using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Own.Domain.Common
{
    public class AuditableBaseEntity<T> : BaseEntity<T>, AuditableEntity
    {
        [Column("created")]
        public DateTime Created { get; set; }
        [Column("creator")]
        public string Creator { get; set; }
        [Column("modified")]
        public DateTime? Modified { get; set; }
        [Column("modifier")]
        public string Modifier { get; set; }
    }
}
