using System.Collections.Generic;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    // pattern [baseurl]/api/commands
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
		private readonly ICommanderRepo _repository;

		public CommandsController(ICommanderRepo repository)
        {
            _repository = repository;
        }
        // private readonly MockCommanderRepo _repository  = new MockCommanderRepo();


        // pattern [baseurl]/api/commands/
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetCommands();
            return Ok(commandItems);
        }

        // pattern [baseurl]/api/commands/id
        // pattern [baseurl]/api/commands/6
        [HttpGet("{id}")]
        public ActionResult <Command> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            return Ok(commandItem);
        }
    }
}