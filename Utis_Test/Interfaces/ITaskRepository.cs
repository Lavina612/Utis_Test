using System.Collections.Generic;
using Utis_Test.Data.Entities;
using Utis_Test.Models;

namespace Utis_Test.Interfaces
{
    public interface ITaskRepository
    {
        public List<TaskEntity> GetAll(int page, int pageSize);

        public List<TaskEntity> GetByStatus(string status, int page, int pageSize);

        public TaskEntity? GetById(int id);

        public void Add(TaskEntity addingTask);

        public bool Update(TaskEntity updatingTask);

        public void Delete(TaskEntity deletingTask);
    }
}
