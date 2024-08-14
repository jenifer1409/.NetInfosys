using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VehicleWebApplication.Models;

namespace VehicleWebApplication.Controllers
{
    public class VehicleStatusTrackersController : Controller
    {
        private readonly VehicleContext _context;

        public VehicleStatusTrackersController(VehicleContext context)
        {
            _context = context;
        }

        // GET: VehicleStatusTrackers
        public async Task<IActionResult> Index()
        {
            return View(await _context.vehicleStatusTrackers.ToListAsync());
        }

        // GET: VehicleStatusTrackers/Details/5
        // <purpose>get details</purpose>
        //<param name='id'></param>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vehicleStatusTracker = await _context.vehicleStatusTrackers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleStatusTracker == null)
            {
                return NotFound();
            }
            return View(vehicleStatusTracker);
        }

        // GET: VehicleStatusTrackers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleStatusTrackers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Status,Speed")] VehicleStatusTracker vehicleStatusTracker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleStatusTracker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleStatusTracker);
        }

        // GET: VehicleStatusTrackers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleStatusTracker = await _context.vehicleStatusTrackers.FindAsync(id);
            if (vehicleStatusTracker == null)
            {
                return NotFound();
            }
            return View(vehicleStatusTracker);
        }

        // POST: VehicleStatusTrackers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Status,Speed")] VehicleStatusTracker vehicleStatusTracker)
        {
            if (id != vehicleStatusTracker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleStatusTracker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleStatusTrackerExists(vehicleStatusTracker.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleStatusTracker);
        }

        // GET: VehicleStatusTrackers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleStatusTracker = await _context.vehicleStatusTrackers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleStatusTracker == null)
            {
                return NotFound();
            }

            return View(vehicleStatusTracker);
        }

        // POST: VehicleStatusTrackers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleStatusTracker = await _context.vehicleStatusTrackers.FindAsync(id);
            if (vehicleStatusTracker != null)
            {
                _context.vehicleStatusTrackers.Remove(vehicleStatusTracker);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleStatusTrackerExists(int id)
        {
            return _context.vehicleStatusTrackers.Any(e => e.Id == id);
        }
    }
}
