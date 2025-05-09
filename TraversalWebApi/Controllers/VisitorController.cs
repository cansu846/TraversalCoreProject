using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TraversalWebApi.DAL.Context;
using TraversalWebApi.Entities;

namespace TraversalWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.ToList();
                return Ok(values);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            using (var context = new VisitorContext())
            {
                var values = context.Find<Visitor>(id);
                if (values == null)
                {
                    return NotFound();
                }

                return Ok(values);
            }
        }

        [HttpPost]
        public IActionResult AddVisitor(Visitor v)
        {
            using (var context = new VisitorContext())
            {
                context.Add(v);
                context.SaveChanges();
                return Ok();
            }
        }
        [HttpPut]
        public IActionResult UpdateVisitor(Visitor v)
        {
            using (var context = new VisitorContext())
            {
                var visitor = context.Find<Visitor>(v.VisitorId);
                if (visitor == null)
                {
                    return NotFound();
                }
                else
                {
                    visitor.Name = v.Name;
                    visitor.Surname = v.Surname;
                    visitor.City = v.City;
                    visitor.Country = v.Country;
                    visitor.Mail = v.Mail;
                    context.Update(visitor);
                    context.SaveChanges();
                    return Ok();
                }
               
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (var context = new VisitorContext())
            {
                var visitor = context.Find<Visitor>(id);
                if (visitor == null)
                {
                    return NotFound();
                }
                else
                {
                    context.Remove(visitor);
                    context.SaveChanges();
                    return Ok();
                }
                    
            }
        }
    }
}
