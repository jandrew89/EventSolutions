using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Repository.Models.Enums
{
    public enum Status
    {
        Created = 0,
        Circulating = 1,
        Completed = 2,
        Rejected = 3,
        Cancelled = 4
    }

    public enum Priority
    {
        NA =1,
        Low = 2,
        Medium = 3,
        High = 4,
        Emergency = 5
    }
}
