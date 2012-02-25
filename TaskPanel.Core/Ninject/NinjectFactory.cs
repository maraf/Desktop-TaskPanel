using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using TaskPanel.Core.Domain;
using TaskPanel.Core.Domain.Repository;
using TaskPanel.Core.XmlStorage;
using TaskPanel.Core.XmlStorage.Repository;

namespace TaskPanel.Core.Ninject
{
    public class NinjectFactory
    {
        private static NinjectFactory instance = new NinjectFactory();
        public static NinjectFactory Instance { get { return instance; } }

        private IKernel kernel;
        public IKernel Kernel { get { return kernel; } }

        protected NinjectFactory()
        {
            kernel = new StandardKernel();
            AddBindings();
        }

        protected void AddBindings()
        {
            kernel.Bind<IUser>().To<User>();
            kernel.Bind<ITask>().To<Task>();
            kernel.Bind<ITaskState>().To<TaskState>();
            kernel.Bind<IGroup>().To<Group>();
            kernel.Bind<IRepository>().To<XmlRepository>();
        }

        public T Get<T>()
        {
            return kernel.Get<T>();
        }
    }
}
