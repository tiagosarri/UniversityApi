namespace UniversityApi.Models
{
    public class TeacherModel : BaseModel
    {
        public ICollection<SubjectModel> Subjects { get; set; } = new List<SubjectModel>();
    }
}
