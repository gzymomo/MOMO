using System;
using System.Collections.Generic;
using System.Text;

namespace MOMO.Domain
{
    public class Role : Entity
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public long CreateUserId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }

        public virtual ICollection<RoleMenu> RoleMenus { get; set; }
    }
}
