using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
namespace Helpers
{
    /// <summary>
    /// MySqlHelper扩展(依赖AutoMapper.dll)
    /// </summary>
    public sealed partial class MySqlHelper
    {
        #region 实例方法

        public T ExecuteObject<T>(string commandText, params MySqlParameter[] parms)
        {
            return ExecuteObject<T>(this.ConnectionString, commandText, parms);
        }
        #endregion

        #region 静态方法
        #endregion
    }
}
