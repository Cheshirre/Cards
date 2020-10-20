using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Cards.Models;
using CardsLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cards.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackController : ControllerBase
    {
        IStorage _storage;
        IDeckFactory _deckFactory;
        readonly IOptions<Settings> _settings;
        IShuffle _shuffle;

        public PackController(IStorage storage, IDeckFactory deckFactory, IOptions<Settings> settings, IShuffle shuffle)
        {
            _storage = storage;
            _deckFactory = deckFactory;
            _settings = settings;
            _shuffle = shuffle;
        }

        // GET: api/<PackController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _storage.GetDeckNames();
        }

        // GET api/<PackController>/5
        [HttpGet("{name}")]
        public async Task<Deck> Get(string name)
        {
            try
            {
                return _storage.GetDeck(name);
            }
            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await Response.WriteAsync($"Ошибка получения колоды {name}");

                throw;
            }
        }

        // POST api/<PackController>
        [HttpPost]
        public async Task Post([FromBody] DeckModel value)
        {
            try
            {
                _deckFactory.Create(value.Name, value.Size);
            }
            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await Response.WriteAsync($"Ошибка создания колоды {value.Name}");
            }
        }

        // PUT api/<PackController>/5
        [HttpPut("{name}")]
        public void Put(int name, [FromBody] DeckModel value)
        {
            Response.StatusCode = (int)HttpStatusCode.NotImplemented;
        }

        // DELETE api/<PackController>/5
        [HttpDelete("{name}")]
        public async Task Delete(string name)
        {
            if(!_storage.DeleteDeck(name))
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await Response.WriteAsync($"Ошибка удаления колоды {name}");
            }    
        }

        [HttpGet("shuffle/{name}")]
        public async Task<Deck> GetShuffled (string name)
        {
            try
            {
                return _shuffle.Start(_storage.GetDeck(name));
            }
            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await Response.WriteAsync($"Ошибка удаления колоды {name}");

                throw;
            }
        }
    }
}
