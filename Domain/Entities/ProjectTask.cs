using Domain.Enums;

namespace Domain.Entities
{
    public class ProjectTask : BaseModel
    {
        public string Priority { get; set; }
        public Status Status { get; set; }
        public DateTime Time { get; set; }
        public string Text { get; set; }
    }
}
