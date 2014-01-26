using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SmartToDoCS
{
    [Table("TaskTable")]
    public class TaskTable
    {
        [PrimaryKey, Unique, AutoIncrement]
        public int Id { get; set; }
        public string Desc { get; set; }
        public int Time { get; set; }
        public int Week { get; set; }
//        public DateTime whenToDo { get; set; }

        public override string ToString()
        {
            return Desc;
        }
        public int getId()
        {
            return Id;
        }
    }
}