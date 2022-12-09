using Domain.Enums;

namespace DTOs.ProjectTasksDTOs
{
    public class CreateProjectTaskDTO
    {
        public string Priority { get; set; }
        public string Status { get; set; }
        public string Text { get; set; }
    }
}
