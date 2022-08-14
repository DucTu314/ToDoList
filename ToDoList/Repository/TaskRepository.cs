using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using ToDoList.Models;


namespace ToDoList.Repository
{
    public class TaskRepository
    {
        public void Create(Task task)
        {
            using var dbcontext = new ToDoListContext();
            dbcontext.tasks.Add(task);
            dbcontext.SaveChanges();
        }
        public List<Task> Read(Guid id)
        {
            using var dbcontext = new ToDoListContext();

            return (from p in dbcontext.tasks.ToList()
                    where p.DayId == id
                    select p).ToList();
        }
        public void Delete(Guid Id)
        {
            using var dbcontext = new ToDoListContext();
            var task = (from p in dbcontext.tasks
                        where p.Id == Id
                        select p).FirstOrDefault();
            dbcontext.tasks.Remove(task);
            dbcontext.SaveChanges();
        }

        public void UpdateTask(ObservableCollection<Task> listTasks)
        {
            using var dbcontext = new ToDoListContext();
            foreach (var task in listTasks)
            {
                var temp = (from p in dbcontext.tasks
                            where p.Id == task.Id
                            select p).FirstOrDefault();
                if (temp != null)
                {
                    temp.TaskName = task.TaskName;
                    temp.IsDone = task.IsDone;
                    dbcontext.SaveChanges();
                }
            }
        }
    }
}
