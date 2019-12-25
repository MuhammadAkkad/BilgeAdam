using Services;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace API.Controllers
{
    public class ValuesController : ApiController
    {
        CastService castService = new CastService();
        MovieService movieServices = new MovieService();
        imdbServices imdbService = new imdbServices();

        // GET api/values
        [HttpGet]
        public List<MovieDTO> Get()
        {
            var obj = movieServices.GetAllMovies();
            List<MovieDTO> movie = new List<MovieDTO>();
            movie = new JavaScriptSerializer().Deserialize<List<MovieDTO>>(obj);
            return movie;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
