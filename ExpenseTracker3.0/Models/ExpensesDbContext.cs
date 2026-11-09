using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ExpenseTracker3._0.Models
{
    public class ExpensesDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }

        public ExpensesDbContext(DbContextOptions<ExpensesDbContext> options)
            : base(options)
        {

        }

    }
}
