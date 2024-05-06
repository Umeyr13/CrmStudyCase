using CustomerRelationsManagementDomain.Entities;
using CustomerRelationsMangementApplication.IRepository;
using CustomerRelationsMangementApplication.IServices;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CustomerRelationsManagementPersistence.Services
{
    public class TaskService : ITaskService
    {
        readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public Task CreateTaskAsync(Tasks task)
        {
            return _taskRepository.AddAsync(task);
            
        }

        public Task DeleteTaskAsync(int taskId)
        {
            return _taskRepository.RemoveIdAsync(taskId);
        }

        public  Task<List<Tasks>> GetAllTaskAsync()
        {
            var data = _taskRepository.Table.Include(t=> t.Employee).ToListAsync();
            return data;
        }

        public Task<Tasks> GetTaskByIdAsync(int TaskId)
        {
            return _taskRepository.GetByIdAsync(TaskId);
        }

        public bool UpdateTaskAsync(Tasks task)
        {
            return true;
        }
    }
}
