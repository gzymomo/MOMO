using System;
using MOMO.Domain.Enum;

namespace MOMO.Domain
{
    public class User:Entity
    {
	    /// <summary>
	    /// 账号  
	    /// </summary>
	    public string Account { get; set; }
	    /// <summary>
	    /// 密码
	    /// </summary>
	    public string Password { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public Sex Sex { get; set; }
        /// <summary>
        /// 邮箱地址
        /// </summary>
        public string EMail { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string MobileNumber { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public UserType Type { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string BizCode { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public long? CreateId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 上次登录时间
        /// </summary>
        public DateTime LastLoginTime { get; set; }
        /// <summary>
        /// 登录次数
        /// </summary>
        public int LoginTimes { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public long DepartmentId { get; set; }

        /// <summary>
        /// 是否已删除
        /// </summary>
        public int IsDeleted { get; set; }
        /// <summary>
        /// 所属部门实体
        /// </summary>
        public virtual Department Department { get; set; }
    }
}
