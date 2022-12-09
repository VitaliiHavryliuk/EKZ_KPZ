using Domain.Enums;
using DTOs.BaseDTOs;

namespace DTOs.ProjectTasksDTOs
{
    public class UpdateProjectTaskDTO : BaseIdDTO
    {
        public string Priority { get; set; }
        public string Status { get; set; }
        public string Text { get; set; }
    }
}
