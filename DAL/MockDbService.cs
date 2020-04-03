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


        public IEnumerable<Student> GetStudents(string id)
        {
            //string id = "s1234";
            List<Student> res = new List<Student>();
            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s19135;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "SELECT Semester FROM Student, Enrollment" +
                                  "WHERE Enrollment.IdEnrollment = Student.IdEnrollment " +
                                  "AND IndexNumber = @id";
                com.Parameters.AddWithValue("id", id);

                con.Open();
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Student();
                    st.FirstName = dr["FirstName"].ToString();
                    st.IndexNumber = dr["IndexNumber"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    res.Add(st);
                }

                return null;
            }
        }

        public IEnumerable<Student> GetStudents()
        {
            throw new System.NotImplementedException();
        }
    }
}