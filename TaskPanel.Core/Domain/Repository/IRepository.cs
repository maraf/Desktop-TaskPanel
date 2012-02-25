using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskPanel.Core.Domain.Repository
{
    public interface IRepository
    {
        IUser User { get; }

        IQueryable<ITask> Tasks { get; }

        IQueryable<IGroup> Groups { get; }

        IQueryable<ITaskState> TaskStates { get; }

        bool Load(string location, string username, string password);

        bool Register(string location, string username, string password);

        void Save(ITask task);

        void Save(IGroup group);

        void Save(ITaskState state);

        void Delete(ITask task);

        void Delete(IGroup group);

        void Delete(ITaskState state);

        void Commit();
    }
}
