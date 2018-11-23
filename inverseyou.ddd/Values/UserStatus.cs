using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace inverseyou.ddd.Values
{
    /// <summary>
    /// 用户账号状态
    /// </summary>
    public enum UserAccountStatus
    {
        /// <summary>
        /// 未激活
        /// </summary>
        [Description("未激活")]
        Unactive,
        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")]
        Normal,
        /// <summary>
        /// 冻结
        /// </summary>
        [Description("冻结")]
        Frozen,
        /// <summary>
        /// 永久冻结
        /// </summary>
        [Description("永久冻结")]
        PermanentFrozen,
        /// <summary>
        /// 注销
        /// </summary>
        [Description("注销")]
        Cancel
    }
}
