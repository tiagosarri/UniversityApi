using UniversityApi.Models;

namespace UniversityApi.Data
{
    public static class DataSeeder
    {
        public static void Seed(UniversityContext db)
        {
            if (db.Students.Any()) return;

            var room = new RoomModel { Name = "Room A" };
            var teacher = new TeacherModel { Name = "Dr. Smith" };
            var subject = new SubjectModel { Name = "LLM AI", Room = room, Teacher = teacher };

            var students = new[]
            {
                new StudentModel { Name = "Alice", Subjects = [subject] },
                new StudentModel { Name = "Bob", Subjects = [subject] }
            };

            db.Rooms.Add(room);
            db.Teachers.Add(teacher);
            db.Subjects.Add(subject);
            db.Students.AddRange(students);
            db.SaveChanges();
        }
    }
}