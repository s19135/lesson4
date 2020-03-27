using System.Collections.Generic;
using lesson4.Models;

namespace lesson4.DAL
{
    public interface IDbService
    {
        IEnumerable<Student> GetStudents();
    }
}