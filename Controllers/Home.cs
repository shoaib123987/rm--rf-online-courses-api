using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Courses.Helper;
using Online_Courses.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Online_Courses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Home : ControllerBase
    {
        private readonly OnlineCoursesContext db;

        public Home(OnlineCoursesContext db)
        {
            this.db = db;
        }

        [HttpGet("crousel")]

        public async Task<ActionResult> getData()
        {
            var data = await db.Crousels.ToListAsync();
            return Ok(data);
        }

        [HttpPost("crousel")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> setData([FromForm] Crousel data,  IFormFile image)
        {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads");

            string imageName = await ImageHelper.UploadImageAsync(image, folderPath);

            data.Image = imageName; // Set ho gaya model me image ka naam

            await db.Crousels.AddAsync(data);
            await db.SaveChangesAsync();
            return Ok();
        }


        [HttpGet("about")]

        public async Task<ActionResult> aboutGet()
        {
            var data=await db.Abouts.ToListAsync();
            return Ok(data);
        }

        [HttpPost("about")]
        [Consumes("multipart/form-data")]

        public async Task<ActionResult> aboutSet([FromForm] About data, IFormFile img)
        {
          

                string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads");

                string imageName = await ImageHelper.UploadImageAsync(img, folderPath);

                data.AboutImg = imageName;
          

            await db.Abouts.AddAsync(data);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("register")]
        [Consumes("multipart/form-data")]

        public async Task<ActionResult> Register([FromForm] Register data, IFormFile img)
        {

            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads");

            string imageName = await ImageHelper.UploadImageAsync(img, folderPath);

            data.Profileimg = imageName;

            await db.Registers.AddAsync(data);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(Register data)
        {
            var user = await db.Registers
          .FirstOrDefaultAsync(u => u.Email == data.Email && u.Password == data.Password);
            HttpContext.Session.SetString("userEmail", user.Email);

            return Ok(new
            {
                message = "Login successful",
                user = new
                {
                    user.Id,
                    user.Name,
                    user.Email,
                    user.Profileimg
                }
            });
        }


        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
            if (HttpContext.Session.GetString("userEmail") != null)
            {
                HttpContext.Session.Clear(); // ✅ This clears all session data
               
            }

            return Ok();
        }


        [HttpPost("subjects")]
        [Consumes("multipart/form-data")]

        public async Task<ActionResult> Setsubject([FromForm] ExploreSubject data, IFormFile img)
        {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads");

            string imageName = await ImageHelper.UploadImageAsync(img, folderPath);

            data.CImg = imageName;

            await db.ExploreSubjects.AddAsync(data);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("subject")]
        public async Task<ActionResult> Getsubject()
        {
            var data = await db.ExploreSubjects.ToListAsync();
            return Ok(data);
        }


        [HttpPost("acCourses")]
        [Consumes("multipart/form-data")]

        public async Task<ActionResult> acCourses([FromForm] Course data, IFormFile img)
        {

            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads");

            string imageName = await ImageHelper.UploadImageAsync(img, folderPath);

            data.CourseImg = imageName;

            await db.Courses.AddAsync(data);
            await db.SaveChangesAsync();
            return Ok();

        }

        [HttpGet("acCourses")]
        public async Task<ActionResult> getacCourses()
        {
            var data = await db.Courses.ToListAsync();

            return Ok(data);
        }

        [HttpGet("git")]
        public async Task<ActionResult> git()
        {
            var data = await db.Courses.ToListAsync();

            return Ok(data);
        }

    }
}
