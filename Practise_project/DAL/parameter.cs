using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Practise_project.BAL
{
    public class parameter
    {
        public SqlParameter IntInputPara(string pname, int pvalue)
        {
            SqlParameter Parameter = new SqlParameter();

            Parameter.DbType = DbType.Int32;
            Parameter.Direction = ParameterDirection.Input;
            Parameter.ParameterName = pname;
            Parameter.Value = pvalue;
            return Parameter;
        }
        public SqlParameter CreateIntOutParameter(string ParaName, int ParaValue)
        {
            SqlParameter para = new SqlParameter();

            para.DbType = DbType.Int32;
            para.Direction = ParameterDirection.Output;
            para.ParameterName = ParaName;
            para.Value = ParaValue;

            return para;
        }

        public SqlParameter IntOutputPara(string pname)
        {
            SqlParameter Parameter = new SqlParameter();

            Parameter.DbType = DbType.Int32;
            Parameter.Direction = ParameterDirection.Output;
            Parameter.ParameterName = pname;
            return Parameter;
        }

        public SqlParameter StringInputPara(string pname, string pvalue)
        {
            SqlParameter para = new SqlParameter();
            para.DbType = DbType.String;
            para.Direction = ParameterDirection.Input;
            para.ParameterName = pname;
            para.Value = pvalue;
            return para;
        }

        public SqlParameter StringOutputPara(string pname)
        {
            SqlParameter Parameter = new SqlParameter();

            Parameter.DbType = DbType.String;
            Parameter.Size = 300;
            Parameter.Direction = ParameterDirection.Output;
            Parameter.ParameterName = pname;
            return Parameter;
        }
    }
}