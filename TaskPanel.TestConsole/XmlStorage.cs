using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskPanel.Core.Domain;
using TaskPanel.Core.Domain.Repository;
using TaskPanel.Core.XmlStorage;
using TaskPanel.Core.XmlStorage.Repository;

namespace TaskPanel.TestConsole
{
    class XmlStorage
    {
        public static void LoadAndSave()
        {
            IRepository repo = new XmlRepository();
            repo.Load("TaskPanel.xml", "mara", "1111");

            repo.Save(new Task
            {
                Content = "Newly created task " + DateTime.Now.ToShortTimeString(),
                Group = repo.Groups.First(g => g.ID == 1),
                State = repo.TaskStates.First(s => s.ID == 1)
            });

            foreach (ITask item in repo.Tasks)
            {
                Console.WriteLine("Task: [{0}::{1}] {2}", item.Group.Name, item.State.Name, item.Content);
            }
            Console.ReadKey(true);

            repo.Commit();
        }
    }
}
