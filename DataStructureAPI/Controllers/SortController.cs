using System.Collections.Generic;
using System.Linq;
using DataStructureAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SortLib.Sort;
using SortLib.Search;
using System.Net;

namespace DataStructureAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SortController : ControllerBase
    {
        // GET: api/Sort
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Sort/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Sort  heapsort, mergesort, quicksort, bubblesort
        [HttpPost]
        public ActionResult Sort([FromBody] InputElements values)
        {
            if (values == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            OutSorted data = new OutSorted();
            int[] result = values.Itens;
            if (!string.IsNullOrEmpty(values.Algorithm))
            {
                switch (values.Algorithm.ToLower())
                {
                    case "mergesort":
                        MergeSort<int> mSort = new MergeSort<int>();
                        mSort.MergesortTime(result, 0, result.Length - 1);

                        data.Complexity = "n log(n)";
                        data.Time = mSort.MSlog;
                        data.Itens = result;
                        return Ok(JsonConvert.SerializeObject(data));
                    case "quicksort":
                        QuickSort<int> qSort = new QuickSort<int>();

                        qSort.QuickSortTime(result, 0, result.Length - 1);
                        data.Complexity = "Ω(n log(n))	O(n²)";
                        data.Time = qSort.QSLog;
                        data.Itens = result;

                        return Ok(JsonConvert.SerializeObject(data));
                    case "bubblesort":
                        break;
                    case "heapsort":

                        HeapSort<int, int> hSort = new HeapSort<int, int>();
                        int index = 0;

                        foreach (Node<int, int> node in hSort.Heapsort(BuildNodeArray<int>(result)))
                        {
                            result[index] = node.Key;
                            index++;
                        }
                        data.Complexity = "Ω(n log(n))	O(n log(n))";
                        data.Time = hSort.HSlog;
                        data.Itens = result;
                        return Ok(JsonConvert.SerializeObject(data));
                    case "all":
                        break;
                    default:
                        return NotFound(values.Algorithm.ToLower());
                }
            }
            return Ok();
        }

        private static Node<T, int>[] BuildNodeArray<T>(T[] data)
        {
            int index = 0;
            Node<T, int>[] nodes = new Node<T, int>[data.Length];
            int value = 0;
            foreach (T item in data)
            {
                nodes[index] = new Node<T, int>(index, item, value, null);
                index++;value++;
            }
            return nodes;
        }
    }
}
