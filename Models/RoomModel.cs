namespace UniversityApi.Models
{
    public class RoomModel : BaseModel
    {
        public ICollection<SubjectModel> Subjects { get; set; } = new List<SubjectModel>();
    }
}
