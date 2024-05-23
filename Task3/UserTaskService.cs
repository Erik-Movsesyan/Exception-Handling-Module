using System;
using System.Linq;
using Task3.DoNotChange;
using Task3.Exceptions;

namespace Task3
{
    public class UserTaskService(IUserDao userDao)
    {
        public void AddTaskForUser(int userId, UserTask task)
        {
            if (userId < 0)
                throw new UserException("Invalid userId");

            var user = userDao.GetUser(userId);

            if (user == null)
                throw new UserException("User not found");

            var tasks = user.Tasks;

            if (tasks.Any(t => string.Equals(task.Description, t.Description, StringComparison.OrdinalIgnoreCase)))
            {
                throw new UserTaskException("The task already exists");
            }

            tasks.Add(task);
        }
    }
}