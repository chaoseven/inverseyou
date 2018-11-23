using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace inverseyou.ddd.Values
{
    /// <summary>
    /// 性别
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// 男
        /// </summary>
        [Description("男")]
        Male,
        /// <summary>
        /// 女
        /// </summary>
        [Description("女")]
        Female
    }
}
