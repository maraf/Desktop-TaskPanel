using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace TaskPanel.Core.Domain
{
    public interface ITask
    {
        int ID { get; set; }
        string Content { get; set; }
        string Solution { get; set; }
        decimal Priority { get; set; }

        //NotPersistent
        decimal TotalPriority { get; }

        DateTime Created { get; set; }
        DateTime Modified { get; set; }
        DateTime? Deadline { get; set; }

        IGroup Group { get; set; }
        IUser User { get; set; }
        ITaskState State { get; set; }
    }
}
