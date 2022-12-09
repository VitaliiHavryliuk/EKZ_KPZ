using DTOs.BaseDTOs;

namespace DTOs.ProjectTasksDTOs
{
    public class ProjectTaskDTO : BaseIdDTO
    {
        public string Priority { get; set; }
        public string Status { get; set; }
        public DateTime Time { get; set; }
        public string Text { get; set; }
    }
}
