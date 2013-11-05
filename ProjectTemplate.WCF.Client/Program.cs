using ProjectTemplate.WCF.Client.TaskService;

//todo: need to make sure all session handling is as expected.
namespace ProjectTemplate.WCF.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var taskService = new TaskServiceClient();
            var tasks = taskService.GetAll();
        }
    }
}
