using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AjudaHumana.ONG.Data;
using AjudaHumana.ONG.Domain;
using AjudaHumana.ONG.Application.Services;

namespace AjudaHumana.Web.Controllers
{
    public class ONGController : Controller
    {
        private readonly IONGAppService _ongAppService;

        public ONGController(IONGAppService ongAppService)
        {
            _ongAppService = ongAppService;
        }

        // GET: NonGovernamentalOrganizations
        public async Task<IActionResult> Index()
        {
            //var oNGContext = _context.ONGs.Include(n => n.Responsible);
            //return View(await oNGContext.ToListAsync());

            return View(new List<NonGovernamentalOrganization>());
        }

        // GET: NonGovernamentalOrganizations/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var nonGovernamentalOrganization = await _context.ONGs
            //    .Include(n => n.Responsible)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (nonGovernamentalOrganization == null)
            //{
            //    return NotFound();
            //}

            //return View(nonGovernamentalOrganization);

            return View();
        }

        // GET: NonGovernamentalOrganizations/Create
        public IActionResult Create()
        {
            // ViewData["Id"] = new SelectList(_context.Responsibles, "Id", "CPF");
            return View();
        }

        // POST: NonGovernamentalOrganizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResponsibleId,AddressId,CNPJ,Description,Approved,Id,CreatedAt,UpdatedAt,IsActive")] NonGovernamentalOrganization nonGovernamentalOrganization)
        {
            if (!ModelState.IsValid) return View(nonGovernamentalOrganization);

            await _ongAppService.Create(nonGovernamentalOrganization);

            return RedirectToAction("Index");
        }

        // GET: NonGovernamentalOrganizations/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var nonGovernamentalOrganization = await _context.ONGs.FindAsync(id);
            //if (nonGovernamentalOrganization == null)
            //{
            //    return NotFound();
            //}
            //ViewData["Id"] = new SelectList(_context.Responsibles, "Id", "CPF", nonGovernamentalOrganization.Id);
            //return View(nonGovernamentalOrganization);

            return View();
        }

        // POST: NonGovernamentalOrganizations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ResponsibleId,AddressId,CNPJ,Description,Approved,Id,CreatedAt,UpdatedAt,IsActive")] NonGovernamentalOrganization nonGovernamentalOrganization)
        {
            //if (id != nonGovernamentalOrganization.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(nonGovernamentalOrganization);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!NonGovernamentalOrganizationExists(nonGovernamentalOrganization.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["Id"] = new SelectList(_context.Responsibles, "Id", "CPF", nonGovernamentalOrganization.Id);
            //return View(nonGovernamentalOrganization);

            return View();
        }

        // GET: NonGovernamentalOrganizations/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var nonGovernamentalOrganization = await _context.ONGs
            //    .Include(n => n.Responsible)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (nonGovernamentalOrganization == null)
            //{
            //    return NotFound();
            //}

            //return View(nonGovernamentalOrganization);

            return View();
        }

        // POST: NonGovernamentalOrganizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            //var nonGovernamentalOrganization = await _context.ONGs.FindAsync(id);
            //_context.ONGs.Remove(nonGovernamentalOrganization);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NonGovernamentalOrganizationExists(Guid id)
        {
            // return _context.ONGs.Any(e => e.Id == id);
            return true;
        }
    }
}
