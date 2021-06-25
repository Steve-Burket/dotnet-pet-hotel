using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Transaction : ControllerBase
    {
        private readonly ApplicationContext _context;
        public TransactionController(ApplicationContext context)
        {
            _context = context;
        }

        //GET api/transaction

        [HttpGet] // GET /api/transaction/
        public IEnumerable<Transaction> GetTransactions()
        {
            return _context.Transactions;

        }


        // /api/transactions
        [HttpPost]
        public IActionResult CreateTransaction(Transaction transaction) {
            Transaction transactionEvent = new Transaction
            _context.Add(transactionEvent);
            _context.SaveChanges();
            return _context.Transactions;
        }


    }
}
