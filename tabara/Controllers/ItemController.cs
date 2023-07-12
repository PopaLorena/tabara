using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proiectPIU.Models;
using System.Linq;
using System.Threading.Tasks;

namespace proiectPIU.Controllers
{
    [Route("api/item")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly Context.ContextDb _context;

        public ItemController(Context.ContextDb context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetItems()
        {
            var items = _context.Items.ToList();
            return Ok(items);
        }

        [HttpGet]
        [Route("getItems/{id}")]
        public async Task<IActionResult> getItemById(int id)
        {
            var items =  _context.Items.SingleOrDefault(x => x.Id == id);
            if (items != null)
            {
                return Ok(items);
            }

            return NotFound($"cant find any item");
        }

        [HttpPost]
        [Route("post")]
        public async Task<IActionResult> CreateItem(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + item.Id,
                item);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteItemById(int id)
        {
            var item = _context.Items.SingleOrDefault(x => x.Id == id);
            if (item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

        [HttpPut]
        [Route("edit/{id}")]
        public async Task<IActionResult> EditItemById(int id, Item item)
        {

            var existingItem = _context.Items.SingleOrDefault(x => x.Id == id);
            if (existingItem != null)
            {
                item.Id = existingItem.Id;

                existingItem.Name = item.Name;
                existingItem.Number = item.Number;
                existingItem.Category = item.Category;

                _context.Items.Update(existingItem);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
