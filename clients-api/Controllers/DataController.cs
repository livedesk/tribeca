using clients_api.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace clients_api.Controllers
{
    public class Model
    {
        public string Value { get; set; }
    }



    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly InMemoryStore _inMemoryStore;

        public DataController(InMemoryStore inMemoryStore)
        {
            _inMemoryStore = inMemoryStore;
        }

        [HttpPost("employee")]
        public IActionResult GetEmployee(Model model)
        {
            Employee? employee = _inMemoryStore.GetEmployee(model.Value);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

      

        [HttpPost("client")]
        public IActionResult GetClient(Model model)
        {
            Client? client = _inMemoryStore.GetClient(model.Value);

            if (client == null)
                return NotFound();

            return Ok(client);
        }

        [HttpPost("converttodevmagic")]
        public IActionResult ConvertToDevMagic(Model model)
        {
            string[] words = model.Value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string devMagicSentence = "";

            foreach (string word in words)
            {
                devMagicSentence += word.ConvertToDevMagic() + " ";
            }

            return Ok(devMagicSentence);
        }


        [HttpPost("converttoenglish")]
        public IActionResult ConvertToEnglish(Model model)
        {
            string[] words = model.Value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string devMagicSentence = "";

            foreach (string word in words)
            {
                devMagicSentence += word.ConvertToEnglish() + " ";
            }

            return Ok(devMagicSentence);
        }
    }
}
