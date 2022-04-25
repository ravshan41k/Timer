using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timer.ContextDB;
using Timer.Models;

namespace Timer.Service
{
    public class TimerService : ITimerService
    {
        private readonly TimerDbContext db;

        public TimerService(TimerDbContext _db)
        {
            this.db = _db;
        }
        public async Task Create(TimeData timeData)
        {
            await db.TimeDatas.AddAsync(timeData);
            await db.SaveChangesAsync();
        }

        public async Task Delete(TimeData time)
        {
            db.TimeDatas.Remove(time);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<TimeData>> GetAll()
        {
          return  await db.TimeDatas.ToListAsync();
        }

        public async Task<TimeData> GetById(int? id)
        {
            var data = await db.TimeDatas.FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }
    }
}
