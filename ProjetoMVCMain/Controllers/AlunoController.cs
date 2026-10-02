
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoMVCMain.Models;

public class AlunoController : Controller
{
    private readonly DbSistemaEscolarContext _context;

    public AlunoController(DbSistemaEscolarContext context)
    {
        _context = context;
    }

    // GET: ALUNOS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Alunos.ToListAsync());
    }

    // GET: ALUNOS/Details/5
    public async Task<IActionResult> Details(int? codigo)
    {
        if (codigo == null)
        {
            return NotFound();
        }

        var aluno = await _context.Alunos
            .FirstOrDefaultAsync(m => m.Codigo == codigo);
        if (aluno == null)
        {
            return NotFound();
        }

        return View(aluno);
    }

    // GET: ALUNOS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ALUNOS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Codigo,Nome,Cpf,DataNascimento,Telefone")] Aluno aluno)
    {
        if (ModelState.IsValid)
        {
            _context.Add(aluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(aluno);
    }

    // GET: ALUNOS/Edit/5
    public async Task<IActionResult> Edit(int? codigo)
    {
        if (codigo == null)
        {
            return NotFound();
        }

        var aluno = await _context.Alunos.FindAsync(codigo);
        if (aluno == null)
        {
            return NotFound();
        }
        return View(aluno);
    }

    // POST: ALUNOS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? codigo, [Bind("Codigo,Nome,Cpf,DataNascimento,Telefone")] Aluno aluno)
    {
        if (codigo != aluno.Codigo)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(aluno);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(aluno.Codigo))
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
        return View(aluno);
    }

    // GET: ALUNOS/Delete/5
    public async Task<IActionResult> Delete(int? codigo)
    {
        if (codigo == null)
        {
            return NotFound();
        }

        var aluno = await _context.Alunos
            .FirstOrDefaultAsync(m => m.Codigo == codigo);
        if (aluno == null)
        {
            return NotFound();
        }

        return View(aluno);
    }

    // POST: ALUNOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? codigo)
    {
        var aluno = await _context.Alunos.FindAsync(codigo);
        if (aluno != null)
        {
            _context.Alunos.Remove(aluno);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool AlunoExists(int? codigo)
    {
        return _context.Alunos.Any(e => e.Codigo == codigo);
    }
}
