using DTOs.ProjectTasksDTOs;

namespace Services.Interfaces
{
    public interface IProjectTaskService
    {
        Task<List<T>> GetAllAsync<T>();
        Task DeleteByIdAsync(int id);
        Task<int> CreateAsync(CreateProjectTaskDTO model);
        Task UpdateAsync(UpdateProjectTaskDTO model);
    }
}
