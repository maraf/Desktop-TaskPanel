using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesktopCore;

namespace TaskPanel.Core.Domain
{
    public enum TaskStateFlag
    {
        [Resource("TaskStateFlag.None")]
        None,

        [Resource("TaskStateFlag.Initial")]
        Initial,

        [Resource("TaskStateFlag.Completed")]
        Completed
    }
}
