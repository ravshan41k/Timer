using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Timer.ContextDB;
using Timer.Models;
using Timer.Service;

namespace Timer.Controllers
{
    public  class TimeDatasController : Controller
    {
        
        private readonly ITimerService service;

        public TimeDatasController(ITimerService _service)
        {
            this.service = _service;
        }

        // GET: TimeDatas
        public async Task<IActionResult> Index()
        {
            return View(await service.GetAll());
        }

       

        // GET: TimeDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TimeDatas/Create
       
        [HttpPost]
        
        public async Task<IActionResult> Create(TimeData timeData)
        {
            if (ModelState.IsValid)
            {
                await service.Create(timeData);
                return RedirectToAction(nameof(Index));
            }
            return View(timeData);
        }

       
        [HttpPost]

        // GET: TimeDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeData = await service.GetById(id);
            await service.Delete(timeData);
            if (timeData == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

       
       
    }
}
