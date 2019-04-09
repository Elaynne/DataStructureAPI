using System.Collections.Generic;
using System.Linq;
using DataStructureAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SortLib.Sort;

namespace DataStructureAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeapSortController : ControllerBase
    {
        // GET: api/HeapSort
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/HeapSort/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/HeapSort
        [HttpPost]
        public ActionResult AddNodes([FromBody] InputElements values)
        {
            if (values == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            HeapSort tree = new HeapSort();
            Dictionary<string, int> sorted = new Dictionary<string, int>();

            foreach (var item in tree.Heapsort(values.Itens.ToArray()))
            {
                sorted.Add("Key: " + item.Index.ToString(), item.Value);
            }
            return Ok(JsonConvert.SerializeObject(sorted));
        }
    }
}
