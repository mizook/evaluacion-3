using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eval_3.Models;
using eval_3.Data;

namespace eval_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EPController : ControllerBase
    {
        private readonly DbEvaluacion _context;

        public EPController(DbEvaluacion context)
        {
             _context = context;
        }

        [HttpGet("/api/users")]
        public IActionResult GetUsers()
        {
            var users = _context.Users
                .Include(u => u.reserves)
                .ToList();

            var lastMonth = DateTime.Now.AddMonths(-1);

            var result = users.Select(u => new
            {
                u.name,
                u.faculty,
                date_last_reserve = u.reserves.OrderByDescending(r => r.date_reserve).FirstOrDefault()?.date_reserve,
                cant_reserves_last_month = u.reserves.Count(r => r.date_reserve >= lastMonth),
                Reserves = u.reserves.Select(r => new
                {
                    r.book.id,
                    r.code,
                    book = r.book.name,
                    r.book.description
                }).ToList()
            });

            return Ok(result);
        }

        [HttpGet("/api/books")]
        public IActionResult GetBooks()
        {
            var books = _context.Books.Include(b => b.users).ToList();

            var result = books.Select(b => new
            {
                name = b.name,
                description = b.description,
                reserves = b.users.Select(r => new
                {
                    id = r.user.id,
                    name = r.user.name,
                    faculty = r.user.faculty
                }).ToList()
            });

            return Ok(result);
        }
    }
}