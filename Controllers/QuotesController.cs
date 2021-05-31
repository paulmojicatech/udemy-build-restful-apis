using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemyBuildRestfulApis.data;
using UdemyBuildRestfulApis.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UdemyBuildRestfulApis.Controllers
{
    [Route("api/[controller]")]
    public class QuotesController : Controller
    {
        QuotesDbContext _quotesDbContext;

        public QuotesController(QuotesDbContext ctx)
        {
            _quotesDbContext = ctx;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Quote> Get()
        {
            return _quotesDbContext.Quotes;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Quote Get(int id)
        {
            return _quotesDbContext.Quotes.FirstOrDefault(q => q.Id == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Quote quote)
        {
            _quotesDbContext.Quotes.Add(quote);
            _quotesDbContext.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Quote quote)
        {
            Quote quoteToUpdate = _quotesDbContext.Quotes.Find(id);
            quoteToUpdate.Title = quote.Title;
            quoteToUpdate.Description = quote.Description;
            _quotesDbContext.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Quote quoteToDelete = _quotesDbContext.Quotes.Find(id);
            _quotesDbContext.Quotes.Remove(quoteToDelete);
            _quotesDbContext.SaveChanges();
        }
    }
}
