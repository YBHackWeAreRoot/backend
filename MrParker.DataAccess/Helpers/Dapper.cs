using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrParker.DataAccess.Helpers
{
    internal static class Dapper
    {

        /// <summary>
        /// Updates table T with the values in param.
        /// The table must have a key named "Id" and the value of id must be included in the "param" anon object. The Id value is used as the "where" clause in the generated SQL
        /// </summary>
        /// <typeparam name="T">Type to update. Translates to table name</typeparam>
        /// <param name="connection"></param>
        /// <param name="param">An anonymous object with key=value types</param>
        /// <returns>The Id of the updated row. If no row was updated or id was not part of fields, returns null</returns>
        public static async Task<object> UpdateFieldsAsync<T>(this IDbConnection connection, Dictionary<string, object> param, IDbTransaction transaction = null, int? commandTimeOut = null, CommandType? commandType = null)
        {
            var names = new List<string>();
            Guid id = Guid.Empty;

            if (param is Dictionary<string, object> dict)
            { 
                dict.TryGetValue("Id", out object guid);
                id = (Guid)guid;

                foreach (KeyValuePair<string, object> kvp in dict)
                {
                    if (!"Id".Equals(kvp.Key, StringComparison.InvariantCultureIgnoreCase))
                    {
                        names.Add(kvp.Key);
                    }
                }

                if (id != Guid.Empty && names.Count > 0)
                {
                    var sql = string.Format("UPDATE {1} SET {0} WHERE Id=@Id", string.Join(",", names.Select(t => { t = t + "=@" + t; return t; })), typeof(T).Name);
                    if (Debugger.IsAttached)
                        Trace.WriteLine(string.Format("UpdateFields: {0}", sql));
                    return await connection.ExecuteAsync(sql, param, transaction, commandTimeOut, commandType) > 0 ? id : null;
                }
            }


            return null;
        }

        public static object UpdateFieldsAsync<T>(this IDbConnection connection, Dictionary<string, object> fields, CommandDefinition commandDefinition)
        {
            return UpdateFieldsAsync<T>(connection, fields, commandDefinition.Transaction, commandDefinition.CommandTimeout, commandDefinition.CommandType);
        }

    }
}
