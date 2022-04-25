using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timer.Models;

namespace Timer.Service
{
   public interface ITimerService
    {
        public Task<IEnumerable<TimeData>> GetAll();
        public Task Create(TimeData time);
        public Task Delete(TimeData time);
        public Task<TimeData> GetById(int? id);
       
    }
}
