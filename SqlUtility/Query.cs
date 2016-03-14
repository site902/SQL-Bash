using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlUtility
{
    class Query
    {
        private string sql;
        private string fileName;

        public Query(string sql)
        {
            this.sql = sql;
        }

        public Query(string sql, string fileName)
        {
            this.sql = sql;
            this.fileName = fileName;
        }

        public string Sql
        {
            get { return sql; }
            set { sql = value; }
        }

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }


    }
}
