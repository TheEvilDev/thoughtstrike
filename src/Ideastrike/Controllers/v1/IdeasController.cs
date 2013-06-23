using System.Collections.Generic;
using System.Web.Http;
using Ideastrike.Models;
using Ideastrike.Models.Repositories;

namespace Ideastrike.Controllers.v1
{
    public class IdeasController : ApiController
    {
        private readonly IIdeaRepository _ideaRepository;

         public IdeasController(IIdeaRepository ideaRepository)
        {
            _ideaRepository = ideaRepository;
        }

        public IEnumerable<Idea> Get()
        {
            return _ideaRepository.GetAll();
        }

        public void Post([FromBody] Idea idea)
        {
            _ideaRepository.Add(idea);
        }

        public void Delete([FromBody]Idea idea)
        {
            _ideaRepository.Delete(idea.Id);
        }
    }
}