using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class StudentsBusiness
    {
        readonly StudentsRepository studentsRepository = new StudentsRepository();

        public List<Students> GetStudents1()
        {
            return studentsRepository.GetAllStudents().Where(student => (student.ProjectPoints > 30 && student.TestPoints > 20) && student.ExamMark < 6).ToList();
        }
        public List<Students> GetStudents2()
        {
            return studentsRepository.GetAllStudents().Where(student => student.ExamMark > 5).ToList();
        }
        public List<Students> GetStudents5(bool kutija)
        {
            if(kutija.Equals(true))
            return studentsRepository.GetAllStudents().Where(student => student.ExamMark > 5).ToList();
            else
            return studentsRepository.GetAllStudents().Where(student => (student.ProjectPoints > 30 && student.TestPoints > 20) && student.ExamMark < 6).ToList();


        }
        public bool InsertStudent(Students student)
        {
            return studentsRepository.InsertStudent(student) != 0;
        }
    }
}
