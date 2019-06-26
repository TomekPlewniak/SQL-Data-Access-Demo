using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDataAccessDapper
{
    class DataAccess
    {
        public List<Person> GetPeople(string lastName)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                List<Person> output = connection.Query<Person>($"SELECT * FROM People WHERE LastName = '{lastName}'").ToList();

                return output;
            }
        }
    }
}
