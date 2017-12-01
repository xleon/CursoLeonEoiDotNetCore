using Newtonsoft.Json;

namespace TodoApi.Model
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

        public int TodoListId { get; set; }

        [JsonIgnore]
        public TodoList TodoList { get; set; }
    }
}
