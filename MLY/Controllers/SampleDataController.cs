using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MLY.Model;

namespace MLY.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            try
            {
                string url = "https://jsonplaceholder.typicode.com/users";
                HttpClient client = new HttpClient();
                HttpResponseMessage message = client.GetAsync(url).Result;
                message.EnsureSuccessStatusCode();
                var result = message.Content.ReadAsStringAsync().Result;
                List<Data> data = JsonSerializer.Deserialize<List<Data>>(result);
                return Ok(data);
            }
            catch
            {
                return BadRequest("Internal server error");
            }
        }

    }
}
