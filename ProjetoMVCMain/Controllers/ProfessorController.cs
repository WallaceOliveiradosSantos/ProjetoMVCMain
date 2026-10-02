
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoMVCMain.Models;

public class ProfessorController : Controller
{
    private readonly DbSistemaEscolarContext _context;

    public ProfessorController(DbSistemaEscolarContext context)
    {
        _context = context;
    }

    // GET: PROFESSORS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Professores.ToListAsync());
    }

    // GET: PROFESSORS/Details/5
    public async Task<IActionResult> Details(int? codigo)
    {
        if (codigo == null)
        {
            return NotFound();
        }

        var professor = await _context.Professores
            .FirstOrDefaultAsync(m => m.Codigo == codigo);
        if (professor == null)
        {
            return NotFound();
        }

        return View(professor);
    }

    // GET: PROFESSORS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: PROFESSORS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Codigo,Nome,Cpf,Especialidade,Salario")] Professor professor)
    {
        if (ModelState.IsValid)
        {
            _context.Add(professor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(professor);
    }

    // GET: PROFESSORS/Edit/5
    public async Task<IActionResult> Edit(int? codigo)
    {
        if (codigo == null)
        {
            return NotFound();
        }

        var professor = await _context.Professores.FindAsync(codigo);
        if (professor == null)
        {
            return NotFound();
        }
        return View(professor);
    }

    // POST: PROFESSORS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? codigo, [Bind("Codigo,Nome,Cpf,Especialidade,Salario")] Professor professor)
    {
        if (codigo != professor.Codigo)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(professor);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessorExists(professor.Codigo))
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
        return View(professor);
    }

    // GET: PROFESSORS/Delete/5
    public async Task<IActionResult> Delete(int? codigo)
    {
        if (codigo == null)
        {
            return NotFound();
        }

        var professor = await _context.Professores
            .FirstOrDefaultAsync(m => m.Codigo == codigo);
        if (professor == null)
        {
            return NotFound();
        }

        return View(professor);
    }

    // POST: PROFESSORS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? codigo)
    {
        var professor = await _context.Professores.FindAsync(codigo);
        if (professor != null)
        {
            _context.Professores.Remove(professor);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ProfessorExists(int? codigo)
    {
        return _context.Professores.Any(e => e.Codigo == codigo);
    }
}
