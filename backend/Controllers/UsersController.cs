using Microsoft.AspNetCore.Mvc;
   using Microsoft.EntityFrameworkCore;
   using backend.Data;
   using backend.Models;
   using System.Threading.Tasks;

   namespace backend.Controllers
   {
       [Route("api/[controller]")]
       [ApiController]
       public class UsersController : ControllerBase
       {
           private readonly AppDbContext _context;

           public UsersController(AppDbContext context)
           {
               _context = context;
           }

           [HttpPost("register")]
           public async Task<ActionResult<User>> Register(User user)
           {
               _context.Users.Add(user);
               await _context.SaveChangesAsync();
               return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
           }

           [HttpPost("login")]
           public async Task<ActionResult<User>> Login(User user)
           {
               var existingUser = await _context.Users
                   .FirstOrDefaultAsync(u => u.Username == user.Username && u.Password == user.Password);

               if (existingUser == null)
               {
                   return Unauthorized();
               }

               return existingUser;
           }

           [HttpGet("{id}")]
           public async Task<ActionResult<User>> GetUser(int id)
           {
               var user = await _context.Users.FindAsync(id);

               if (user == null)
               {
                   return NotFound();
               }

               return user;
           }
       }
   }