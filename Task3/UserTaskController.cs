using System;
using Task3.DoNotChange;
using Task3.Exceptions;

namespace Task3
{
    public class UserTaskController(UserTaskService taskService)
    {
        public bool AddTaskForUser(int userId, string description, IResponseModel model)
        {
            var task = new UserTask(description);

            try
            {
                taskService.AddTaskForUser(userId, task);
            }
            catch (Exception ex) when (ex is UserException or UserTaskException)
            {
                model.AddAttribute("action_result", ex.Message);
                return false;
            }

            return true;
        }
    }
}