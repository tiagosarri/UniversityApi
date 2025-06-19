namespace UniversityApi.Models
{
    public class SubjectModel : BaseModel
    {
        public int RoomId { get; set; }
        public RoomModel Room { get; set; } = null!;

        public int TeacherId { get; set; }
        public TeacherModel Teacher { get; set; } = null!;

        public ICollection<StudentModel> Students { get; set; } = new List<StudentModel>();

    }
}
