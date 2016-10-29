﻿using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace SqlBulkTools
{
    /// <summary>
    /// Configurable options for table. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SimpleDeleteQueryTable<T>
    {
        private HashSet<string> Columns { get; set; }
        private string _schema;
        private readonly string _tableName;
        private Dictionary<string, string> CustomColumnMappings { get; set; }
        private int _sqlTimeout;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        public SimpleDeleteQueryTable(string tableName)
        {
            _sqlTimeout = 600;
            _schema = Constants.DefaultSchemaName;
            Columns = new HashSet<string>();
            CustomColumnMappings = new Dictionary<string, string>();
            _tableName = tableName;
            _schema = Constants.DefaultSchemaName;
            Columns = new HashSet<string>();
            CustomColumnMappings = new Dictionary<string, string>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SimpleDeleteQueryCondition<T> Delete()
        {
            return new SimpleDeleteQueryCondition<T>(_tableName, _schema, _sqlTimeout);
        }

        /// <summary>
        /// Explicitley set a schema if your table may have a naming conflict within your database. 
        /// If a schema is not added, the system default schema name 'dbo' will used.. 
        /// </summary>
        /// <param name="schema"></param>
        /// <returns></returns>
        public SimpleDeleteQueryTable<T> WithSchema(string schema)
        {
            _schema = schema;
            return this;
        }

        /// <summary>
        /// Default is 600 seconds. See docs for more info. 
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public SimpleDeleteQueryTable<T> WithSqlCommandTimeout(int seconds)
        {
            _sqlTimeout = seconds;
            return this;
        }
    }
}