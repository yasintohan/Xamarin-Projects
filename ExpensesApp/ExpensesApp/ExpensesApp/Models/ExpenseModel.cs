using System;

namespace ExpensesApp.Models
{
    public class ExpenseModel
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Cost { get; set; }
        public string Type { get; set; }
        public string Currency { get; set; }

    }
}
