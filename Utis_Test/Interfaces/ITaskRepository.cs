using System.Collections.Generic;
using Utis_Test.Models;

namespace Utis_Test.Interfaces
{
    public interface ITaskRepository
    {
        public List<TaskModel> GetAll();

        public TaskModel? GetById(int id);

        public void Add(TaskModel addingTask);

        public void Update(TaskModel updatingTask);

        public void Delete(TaskModel deletingTask);
    }
}
