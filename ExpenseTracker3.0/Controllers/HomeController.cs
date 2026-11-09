using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ExpenseTracker3._0.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpenseTracker3._0.Migrations;

namespace ExpenseTracker3._0.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly ExpensesDbContext _context;

    public HomeController(ILogger<HomeController> logger, ExpensesDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        List<string> expense = new List<string>()
            {
                
            };

        ViewBag.Expense = new SelectList(expense);

        return View();
    }

    public IActionResult Expenses()
    {
        var allExpenses = _context.Expenses.ToList();

        var totalExpenses = allExpenses.Sum(x => x.Value);

        ViewBag.Expenses = totalExpenses;

        return View(allExpenses);


    }


    public IActionResult CreateEditExpense(int? id)
    {
        var ExpenseTypes = _context.ExpenseTypes.Select(X => X.Description).ToList();
        

        var expenseTypes = new List<string>
        {
            "Utilities",
            "Groceries/Food",
            "Transportation",
            "Subscription",
            "Vacation"
        };

        ViewBag.ExpenseTypes = new SelectList(ExpenseTypes);

        if (id != null)
        {
            // editing -> load an expense by id
            var expenseinDb = _context.Expenses.SingleOrDefault(expense => expense.Id == id);
            if (expenseinDb != null)
            {
                return View(expenseinDb);
            }
        }

        return View(new Expense { Description = string.Empty, ExpenseDate = DateTime.Now});
    }

    public IActionResult DeleteExpense(int id)
    {
        var expenseinDb = _context.Expenses.SingleOrDefault(expense => expense.Id == id);
        if (expenseinDb != null)
        {
            _context.Expenses.Remove(expenseinDb);
            _context.SaveChanges();
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }

    public IActionResult CreateEditExpenseForm(Expense model)
    {
        if (!ModelState.IsValid)

        {
            var expenseTypes = _context.ExpenseTypes.Select(x => x.Description).ToList();
            ViewBag.ExpenseTypes = new SelectList(expenseTypes);
            return View("CreateEditExpense", model);
        }

        if (model.Id == 0)
        {
            // Create

            var temp = model.ExpenseDate.ToString("MM/dd/yyyy");
            model.ExpenseDate = model.ExpenseDate.Date;
            _context.Expenses.Add(model);
        }
        else
        {
            // Editing
            _context.Expenses.Update(model);
        }



        _context.SaveChanges();

        return RedirectToAction("Expenses");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
