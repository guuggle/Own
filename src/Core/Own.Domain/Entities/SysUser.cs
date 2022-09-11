using Own.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Own.Domain.Entites
{
    [Table("sys_user")]
    public class SysUser : AuditableBaseEntity<string>
    {
        [Column("user_id")]
        public string UserId { get; set; }
        [Column("login_name")]
        public string LoginName { get; set; }
        [Column("login_pwd")]
        public string LoginPwd { get; set; }
        [Column("user_name")]
        public string UserName { get; set; }
    }
}
