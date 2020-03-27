using System.Collections.Generic;
using System.Data.SqlClient;
using lesson4.Models;


namespace lesson4.DAL
{
    public class MockDbService : IDbService
    {
        private static IEnumerable<Student> Students;

        static MockDbService()
        {
            Students = new List<Student>
            {
                new Student("1", "Kirill", "Yayceglist", "234"),
                new Student("2", "MuhamadAhmedAbdul", "YouTube", "5433"),
                new Student("3", "Denys", "Antonov", "1111")
            };
        }


        public IEnumerable<Student> GetStudents()
        {
            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s19135;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "Select * From Student";

                con.Open();
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Student();
                    st.FirstName = dr["FirstName"].ToString();
                    st.IndexNumber = dr["IndexNumber"].ToString();
                    st.LastName = dr["LastName"].ToString();
                }

                return null;
            }
        }
    }
}