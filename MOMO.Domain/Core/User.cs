using System;
using System.Collections.Generic;
using System.Text;

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
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string BizCode { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public long? CreateId { get; set; }
    }
}
