namespace Utis_Test.Data.Entities
{
    public class TaskStatusEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TaskStatusEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
