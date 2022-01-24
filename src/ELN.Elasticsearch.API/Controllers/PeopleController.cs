using ELN.Elasticsearch.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ELN.Elasticsearch.API.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _peopleService.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("name-match/{name}")]
        public async Task<IActionResult> GetByNameWithMatchAsync(string name)
        {
            var result = await _peopleService.GetByNameMatch(name);

            return Ok(result);
        }

        [HttpGet("name-match-phrase/{name}")]
        public async Task<IActionResult> GetByNameWithMatchPhraseAsync(string name)
        {
            var result = await _peopleService.GetByNameMatchPhrase(name);

            return Ok(result);
        }

        [HttpGet("email-wildcard/{wildcard}")]
        public async Task<IActionResult> GetByEmailWithWildcard(string wildcard)
        {
            var result = await _peopleService.GetByEmailWithWildcard(wildcard);

            return Ok(result);
        }

        [HttpGet("age-rang/{start}/{end}")]
        public async Task<IActionResult> GetByAgeRange(int start, int end)
        {
            var result = await _peopleService.GetByAgeRange(start, end);

            return Ok(result);
        }

        [HttpGet("phone-prefix/{prefix}")]
        public async Task<IActionResult> GetByPhonePrefix(string prefix)
        {
            var result = await _peopleService.GetByPhonePrefix(prefix);

            return Ok(result);
        }

    }
}
