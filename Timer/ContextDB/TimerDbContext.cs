using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timer.Models;

namespace Timer.ContextDB
{
    public class TimerDbContext:DbContext
    {
        public TimerDbContext(DbContextOptions<TimerDbContext> options):base(options)
        {

        }
       public DbSet<TimeData> TimeDatas { get; set; }
    }
}
