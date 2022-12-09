using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.RepositoryInterfaces;
using DTOs.ProjectTasksDTOs;
using Services.Interfaces;
using Domain;
using Domain.Enums;

namespace Services
{
    public class ProjectTaskService : IProjectTaskService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ProjectTask> _repository;

        public ProjectTaskService(IMapper mapper, IGenericRepository<ProjectTask> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<int> CreateAsync(CreateProjectTaskDTO model)
        {
            var newEntity = _mapper.Map<ProjectTask>(model);
            newEntity.Time = DateTime.Now;
            return await _repository.CreateAsync(newEntity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = (await _repository.GetByCondition(e => e.Id == id)).FirstOrDefault();

            if(entity is null)
            {
                throw new ItemNotFoundException(ErrorMessages.TaskNotFound);
            }

            await _repository.DeleteAsync(entity);
        }

        public async Task<List<T>> GetAllAsync<T>()
        {
            var entities = await _repository.GetAll();
            return _mapper.Map<List<T>>(entities.ToList());
        }

        public async Task UpdateAsync(UpdateProjectTaskDTO dto)
        {
            var entity = (await _repository.GetByCondition(e => e.Id == dto.Id)).FirstOrDefault();

            if (entity is null)
            {
                throw new ItemNotFoundException(ErrorMessages.TaskNotFound);
            }

            entity.Priority = dto.Priority;
            entity.Status = 
                dto.Status == Status.ToDo.ToString() ? Status.ToDo
                : dto.Status == Status.OnReview.ToString() ? Status.OnReview
                : dto.Status == Status.InProgress.ToString() ? Status.InProgress
                : dto.Status == Status.Done.ToString() ? Status.Done : Status.ToDo;

            entity.Text = dto.Text;
            await _repository.UpdateAsync(entity);
        }
    }
}
