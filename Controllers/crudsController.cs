using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using testauthcookiegoogle.Models;

namespace testauthcookiegoogle.Controllers
{
    public class crudsController : Controller
    {
        private readonly dbcontext _context;

        public crudsController(dbcontext context)
        {
            _context = context;
        }

        // GET: cruds
        public async Task<IActionResult> Index()
        {
            //Getdata();
            return View();
        }
        public JsonResult Getdata()
        {
            var data = _context.cruds.ToList();
            return new JsonResult(data);
        }
        // GET: cruds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.cruds == null)
            {
                return NotFound();
            }

            var crud = await _context.cruds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (crud == null)
            {
                return NotFound();
            }

            return View(crud);
        }

        // GET: cruds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cruds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(crud crud)
        {
            var data = new crud()
            {
                name = crud.name,
                email = crud.email,
                phoneNo = crud.phoneNo
            };
          await _context.cruds.AddAsync(data);
           await _context.SaveChangesAsync();
            return new JsonResult("Data saved"); // Return the newly created 'crud' object as JSON



        }
        // GET: cruds/Edit/5
        public JsonResult edit(int? id)
        {
          var data= _context.cruds.Find(id);
            return new JsonResult(data);
        }

        // POST: cruds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public async Task<IActionResult> Edit(crud objData)
        {
            var target = _context.cruds.Where(x => x.Id == objData.Id);
            if (target != null)
            {
                _context.cruds.Update(objData);
                await _context.SaveChangesAsync();
                return new JsonResult("Data Updated");
            }
            else
            {
                return new JsonResult("Data not Updated");
            }
        }

        // GET: cruds/Delete/5
     
       
        public JsonResult delete(int id)
        {
           var data= _context.cruds.Find(id);
            if (data != null)
            {
                _context.cruds.Remove(data);
                _context.SaveChanges();
                return new JsonResult("Data Has Been Deleted");
            }
            return new JsonResult("masla hay");
           
        }

        private bool crudExists(int id)
        {
            return (_context.cruds?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public JsonResult deleteAll()
        {
            var ddata = from a in _context.cruds where a.Id != null select a;
            foreach (var d in ddata)
            {
                _context.Remove(d);

            }
            _context.SaveChanges();
            return new JsonResult("Data Deleted");
        }
    }

}
