using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    /// <summary>
    /// 帳戶類別，用於儲存使用者資訊
    /// </summary>
    public class Account
    {
        /// <summary>
        /// 使用者名稱
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 使用者密碼
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 使用者獲勝次數
        /// </summary>
        public int WinCount { get; set; }
    }
}
