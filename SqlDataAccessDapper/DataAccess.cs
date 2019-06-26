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
                //List<Person> output = connection.Query<Person>($"SELECT * FROM People WHERE LastName = '{lastName}'").ToList();

                // Stored Procedure.
                List<Person> output = connection.Query<Person>("dbo.People_GetByLastName @LastName", new { LastName = lastName }).ToList();

                return output;
            }
        }

        internal void InsertPerson(string firstName, string lastName, string emailAddress, string phoneNumber)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                Person newPerson = new Person
                {
                    FirstName = firstName,
                    LastName = lastName,
                    EmailAddress = emailAddress,
                    PhoneNumber = phoneNumber
                };

                List<Person> people = new List<Person>();

                people.Add(newPerson);

                // Stored procedur
                //connection.Execute("dbo.People_Insert @FirstName, @LastName, @EmailAddress, @PhoneNumber", people);

                // Using insert sql.

                string sql = $"INSERT INTO People (FirstName, LastName, EmailAddress, PhoneNumber) " +
                    $"VALUES ('{firstName}', '{lastName}', '{emailAddress}', '{phoneNumber}')";

                connection.Execute(sql);
            }
        }
    }
}
