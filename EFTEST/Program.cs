using CodeFirstEF.DAL;
using CodeFirstEF.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTEST
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DataContext("codeFirstDb"))
            {
                //新增學生guwei4037
                if (!db.Students.Any(x => x.StudentName == "guwei4037"))
                {
                    db.Students.Add(new Student()
                    {
                        StudentName = "guwei4037",
                        Gender = Gender.Male,
                        BirthDay = new DateTime(1984, 11, 25),
                    });
                }

                //新增課程
                if (!db.Subjects.Any(x => x.SubjectName == "English" || x.SubjectName == "Mathmatics" || x.SubjectName == "Computer"))
                {
                    db.Subjects.AddRange(new Subject[]
                    {
                        new Subject()
                        {
                            SubjectName="English",
                        },
                        new Subject()
                        {
                            SubjectName="Mathmatics",
                        },
                        new Subject()
                        {
                            SubjectName="Computer",
                        }
                    });
                }

                //找到guwei4037這個學生
                Student student = db.Students.FirstOrDefault(x => x.StudentName == "guwei4037");

                //找到數學和英語這兩門課程
                List<Subject> subjects = db.Subjects.Where(x => x.SubjectName == "Mathmatics" || x.SubjectName == "English").ToList();

                //給學生新增課程
                foreach (Subject subject in subjects)
                {
                    student.Subjects.Add(subject);
                }

                //讓課程知道有哪些學生選擇了它
                foreach (Subject subject in subjects)
                {
                    subject.Students.Add(student);
                }

                //刪除guwei4037這個學生其中的數學這門課程
                //student.Subjects.Remove(db.Subjects.FirstOrDefault(x => x.SubjectName == "Mathmatics"));

                //儲存上述操作的結果
                db.SaveChanges();
            }
        }
    }
}
