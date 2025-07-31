using System.Collections.Generic;
using Utis_Test.Data.Entities;
using Utis_Test.Models;

namespace Utis_Test.Interfaces
{
    public interface ITaskRepository
    {
        public List<TaskEntity> GetAll();

        public List<TaskEntity> GetByStatus(string status);

        public TaskEntity? GetById(int id);

        public void Add(TaskEntity addingTask);

        public bool Update(TaskEntity updatingTask);

        public void Delete(TaskEntity deletingTask);
    }
}
