using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlUtility
{
    class Query
    {
        private string tableName;
        private string sql;
        private string fileName;

        public Query(string table, string sql)
        {
            this.tableName = table;
            this.sql = sql;
        }

        public Query(string table, string sql, string fileName)
        {
            this.tableName = table;
            this.sql = sql;
            this.fileName = fileName;
        }

        public Query(string fileName)
        {
            this.fileName = fileName;
        }

        public string TableName
        {
            get { return this.tableName; }
            set { this.tableName = value; }
        }    

        public string Sql
        {
            get { return this.sql; }
            set { this.sql = value; }
        }

        public string FileName
        {
            get { return this.fileName; }
            set { this.fileName = value; }
        }


    }
}
