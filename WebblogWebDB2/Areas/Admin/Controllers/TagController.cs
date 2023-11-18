using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using WebblogWebDB2.Data;
using WebblogWebDB2.Models;

namespace WebblogWebDB2.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class TagController : Controller
    {
        private readonly AppDBContext _dbContext;

        public TagController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var tags = _dbContext.Tags.ToList();
            return View(tags);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tag tag)
        {
            var Tags = _dbContext.Tags.FirstOrDefault(t => t.TagName == tag.TagName);

            if (Tags != null)
            {
                return View();
            }
            if (tag == null) return NotFound();

            if (ModelState.IsValid)
            {
                tag.CreatedDate = DateTime.Now;
                _dbContext.Tags.Add(tag);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Tag");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();
            Tag tag = _dbContext.Tags.FirstOrDefault(y => y.Id == id);
            if (tag == null) return NotFound();
            return View(tag);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            Tag tag = _dbContext.Tags.FirstOrDefault(y => y.Id == id);
            if (tag == null) return NotFound();
            return View(tag);
        }

        [HttpPost]
        public IActionResult Delete(Tag tag3)
        {
            _dbContext.Tags.Remove(tag3);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            Tag tag = _dbContext.Tags.FirstOrDefault(x => x.Id == id);
            if (tag == null) return NotFound();
            return View(tag);

        }

        [HttpPost]
        public IActionResult Update(Tag tag)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(tag);
                }

                if (tag == null) return NotFound();
                tag.UpdatedDate = DateTime.Now;
                _dbContext.Tags.Update(tag);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Errors = ex.Message;
                throw;
            }
        }

    }

}


