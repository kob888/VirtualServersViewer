using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VirtualServersViewer.Data;
using VirtualServersViewer.Models;
using VirtualServersViewer.ViewModels;

namespace VirtualServersViewer.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task<IActionResult> Index()
        {
            var timer = await _db.Timer.Where(p => p.Id == 1).SingleAsync();

            var model = new VirtualServersViewModel
            {
                VirtualServerList = await _db.VirtualServers.ToListAsync(),
                Timer = timer.Timer
            };

            return View(model);
        }

        
        public async Task<IActionResult> Add()
        {
            // Добавляем новый виртуальный сервер
            var model = new VirtualServer()
            {
                CreateDateTime = DateTime.Now,
                RemoveDateTime = null
            };

            _db.VirtualServers.Add(model);

            var count = _db.VirtualServers.Where(p => p.RemoveDateTime == null).Count();

            // Проверка. Если нет открытых соединений, то при создании нового сервера запускается таймер
            if (count == 0)
            {
                var timer = _db.Timer.Where(p => p.Id == 1).Single();
                timer.StartTime = DateTime.Now;
            }

            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Remove(VirtualServersViewModel items)
        {
            foreach (var item in items.VirtualServerList)
            {
                var count = _db.VirtualServers.Where(p => p.RemoveDateTime == null).Count();

                // Для выделенных строк, закрываются соединения
                if (item.isSelectedForRemove)
                {
                    if (_db.VirtualServers.Where(p=>p.VirtualServerId == item.VirtualServerId).First().RemoveDateTime == null)
                    {
                        var model = await _db.VirtualServers.Where(p => p.VirtualServerId == item.VirtualServerId).SingleOrDefaultAsync();
                        model.RemoveDateTime = DateTime.Now;

                        // Если открытые соединения отсутствуют, то таймер останавливается
                        if (count == 0)
                        {
                            var timer = _db.Timer.Where(p => p.Id == 1).Single();

                            var now = DateTime.Now;
                            var start = timer.StartTime;

                            timer.Timer += now - start;

                        }
                    }
                }
            }

            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> CurrentTimer()
        {
            var count = _db.VirtualServers.Where(p => p.RemoveDateTime == null).Count();

            // Если существуют открытые соединения, то таймер обновляется 
            if (count > 0)
            {
                var timer = await _db.Timer.Where(p => p.Id == 1).SingleAsync();
                var now = DateTime.Now;
                var start = timer.StartTime;

                timer.Timer += now - start;
                timer.StartTime = DateTime.Now;

                await _db.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }

    }
}
