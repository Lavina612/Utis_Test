using System.Collections.Generic;
using System.Linq;
using Utis_Test.Data.Entities;
using Utis_Test.Interfaces;
using Utis_Test.Models;

namespace Utis_Test.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public List<TaskModel> GetAllTasks(int page, int pageSize)
        {
            var taskEntities = _taskRepository.GetAll(page, pageSize);
            return taskEntities.Select(x => x.ToTaskModel()).ToList();
        }

        public List<TaskModel> GetTasksByStatus(string status, int page, int pageSize)
        {
            var taskEntities = _taskRepository.GetByStatus(status, page, pageSize);
            return taskEntities.Select(x => x.ToTaskModel()).ToList();
        }

        public TaskModel? GetTaskById(int id)
        {
            var taskEntity = _taskRepository.GetById(id);
            return taskEntity?.ToTaskModel();
        }

        public int AddTask(TaskModel addingTask)
        {
            var addingTaskEntity = ConvertTaskModelToTaskEntity(addingTask);
            if (addingTaskEntity == null)
                return 0;

            _taskRepository.Add(addingTaskEntity);
            return addingTaskEntity.Id;
        }

        public bool UpdateTask(int id, TaskModel newTask)
        {
            var updatingTask = UpdateTaskEntityByTaskModelProperties(id, newTask);
            if (updatingTask == null)
                return false;

            _taskRepository.Update(updatingTask);
            return true;
        }

        public void DeleteTask(int id)
        {
            var deletingTask = _taskRepository.GetById(id);

            if (deletingTask != null)
            {
                _taskRepository.Delete(deletingTask);
            }
        }

        private TaskEntity? ConvertTaskModelToTaskEntity(TaskModel taskModel)
        {
            var statusId = _taskRepository.GetStatusIdByStatusName(taskModel.StatusName);
            if (statusId == null)
                return null;


            var taskEntity = taskModel.ToTaskEntity();
            taskEntity.StatusId = statusId.Value;
            return taskEntity;
        }

        private TaskEntity? UpdateTaskEntityByTaskModelProperties(int id, TaskModel taskModel)
        {
            var statusId = _taskRepository.GetStatusIdByStatusName(taskModel.StatusName);
            if (statusId == null)
                return null;

            var updatingTask = _taskRepository.GetById(id);

            if (updatingTask != null)
            {
                updatingTask.UpdateProperties(taskModel);
                updatingTask.StatusId = statusId.Value;
                return updatingTask;
            }

            return null;
        }
    }
}
