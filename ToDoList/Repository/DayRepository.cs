using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Repository
{
    public class DayRepository
    {
        public void Create(Day day)
        {
            using var dbcontext = new ToDoListContext();
            dbcontext.days.Add(day);
            dbcontext.SaveChanges();
        }
        public List<Day> Read()
        {
            using var dbcontext = new ToDoListContext();
            return dbcontext.days.ToList();
        }
        public void Delete(Day day)
        {
            using var dbcontext = new ToDoListContext();
            dbcontext.days.Remove(day);
            dbcontext.SaveChanges();
        }
    }
}
