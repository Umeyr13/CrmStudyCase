using CustomerRelationsManagementDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationsMangementApplication.IServices
{
    public interface ITaskService
    {
        Task<List<Tasks>> GetAllTaskAsync();
        Task<Tasks> GetTaskByIdAsync(int TaskId);
        Task CreateTaskAsync(Tasks task);
        bool UpdateTaskAsync(Tasks task);
        Task DeleteTaskAsync(int taskId);
    }
}
