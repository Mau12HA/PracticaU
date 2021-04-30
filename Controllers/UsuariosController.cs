using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArSpFi.Models;
using System.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace ArSpFi.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ASF_2C_2021Context _context;

        public UsuariosController(ASF_2C_2021Context context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var aSF_2C_2021Context = _context.Usuarios.Include(u => u.FkRolNavigation);
            return View(await aSF_2C_2021Context.ToListAsync());
        }


        public  ActionResult Login()
        {
           
            return View();
        }



        //[HttpPost]
        //public ActionResult Login(string usuario, string pass)
        //{
        //    if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(pass))
        //    {
        //        var user = _context.Usuarios.Where(e => e.Nombre == usuario && e.Password == pass);

        //        if (user != null)
        //        {
        //            return RedirectToAction("Menu", "Home");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError(string.Empty, "No encontramos tus datos");
        //            return View();
        //        }
        //    }
        //    else
        //    {
        //        ModelState.AddModelError(string.Empty, "Ingrese los datos correctos para iniciar sesion");
        //        return View();
        //    }

        //}



        [HttpPost]
        public ActionResult Login(string Nombre, string Password)
        {
            var usuario = _context.Usuarios.Where(s => s.Nombre == Nombre && s.Password == Password);

            if (usuario.Any())
            {
                if (usuario.Where(s => s.Nombre == Nombre && s.Password == Password && s.Activo == true).Any())
                {
                    return RedirectToAction("Menu", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Usuario inhabilitado");
                    return View();

                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Ingrese los datos correctos para iniciar sesion");
                return View();


            }


        }


        public async Task<ActionResult<Usuario>> ValidarUsuario(string user, string Pass)
        {
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(
                e => e.Nombre == user && e.Password == Pass && e.Activo == true);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }





        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.FkRolNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewData["FkRol"] = new SelectList(_context.Rols, "IdRol", "NombRol");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,Nombre,Correo,Password,FechaCreado,Activo,FkRol")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkRol"] = new SelectList(_context.Rols, "IdRol", "NombRol", usuario.FkRol);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["FkRol"] = new SelectList(_context.Rols, "IdRol", "NombRol", usuario.FkRol);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,Nombre,Correo,Password,FechaCreado,Activo,FkRol")] Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.IdUsuario))
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
            ViewData["FkRol"] = new SelectList(_context.Rols, "IdRol", "NombRol", usuario.FkRol);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.FkRolNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.IdUsuario == id);
        }


        [Authorize]
        public ActionResult Logout()
        {
            
            return RedirectToAction("Index","Home");
        }



    }
}
