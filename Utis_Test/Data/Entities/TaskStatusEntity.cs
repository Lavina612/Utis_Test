namespace Utis_Test.Data.Entities
{
    public class TaskStatusEntity
    {
        public int Id { get; set; }

        public string StatusName { get; set; }

        public TaskStatusEntity(int id, string statusName)
        {
            Id = id;
            StatusName = statusName;
        }
    }
}
