﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestApp.Data;
using TestApp.Models;

namespace TestApp.Controllers
{
    [Authorize]
    public class CategoriaItemController : Controller
    {
        private readonly TestAppContext _context;

        public CategoriaItemController(TestAppContext context)
        {
            _context = context;
        }

        // GET: CategoriaItem
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoriaItem.ToListAsync());
        }

        // GET: CategoriaItem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaItem = await _context.CategoriaItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoriaItem == null)
            {
                return NotFound();
            }

            return View(categoriaItem);
        }

        // GET: CategoriaItem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaItem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] CategoriaItem categoriaItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaItem);
        }

        // GET: CategoriaItem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaItem = await _context.CategoriaItem.FindAsync(id);
            if (categoriaItem == null)
            {
                return NotFound();
            }
            return View(categoriaItem);
        }

        // POST: CategoriaItem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] CategoriaItem categoriaItem)
        {
            if (id != categoriaItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaItemExists(categoriaItem.Id))
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
            return View(categoriaItem);
        }

        // GET: CategoriaItem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaItem = await _context.CategoriaItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoriaItem == null)
            {
                return NotFound();
            }

            return View(categoriaItem);
        }

        // POST: CategoriaItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriaItem = await _context.CategoriaItem.FindAsync(id);
            if (categoriaItem != null)
            {
                _context.CategoriaItem.Remove(categoriaItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaItemExists(int id)
        {
            return _context.CategoriaItem.Any(e => e.Id == id);
        }
    }
}
