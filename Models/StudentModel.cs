namespace UniversityApi.Models
{
    public class StudentModel : BaseModel
    {
        public ICollection<SubjectModel> Subjects { get; set; } = new List<SubjectModel>();
    }

}
