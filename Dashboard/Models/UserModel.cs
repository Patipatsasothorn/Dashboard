using System;

namespace Dashboard.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Password { get; set; } = null!;  // NOT NULL

        public string? PhoneNumber { get; set; }       // DEFAULT NULL

        public string? BankProvider { get; set; }      // DEFAULT NULL

        public string? BankAccountNumber { get; set; } // DEFAULT NULL

        public DateTime created_at { get; set; }        // NOT NULL DEFAULT CURRENT_TIMESTAMP

        public decimal Wallet { get; set; } = 0.00m;   // NOT NULL DEFAULT 0.00

        public decimal total_win { get; set; } = 0.00m; // NOT NULL DEFAULT 0.00

        public DateTime? last_login { get; set; }       // DEFAULT NULL

        public decimal Rate { get; set; }      // เพิ่ม Rate เป็น Decimal
    }
}
