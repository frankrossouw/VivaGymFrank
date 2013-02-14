using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using VivaGymWebApi.Caching;
using VivaGymWebApi.Models;
using VivaWeb.Infrastructure.Caching;

namespace VivaGymWebApi.Controllers
{
  public class PeopleController : ApiController
  {
    private readonly List<Person> _people;
    private readonly ICacheStore _cache;

    public PeopleController()
    {
      _cache = new HTTPRuntimeCacheStore();
      _people = _cache.GetCachedData<List<Person>>("people");
      if (_people == null || !_people.Any())
      {
        _people = new List<Person>() {new Person() {Name = "Frank", Age = 34}, new Person() {Name = "Paul", Age = 35}};
        _cache.StoreDataInCache("people", _people);
      }
    }

    // GET api/values
    public IEnumerable<Person> Get()
    {
      return _people;
    }

    // GET api/values/5
    public Person Get(string id)
    {
      var foundPerson = _people.SingleOrDefault(person => person.Name.ToUpper() == id.ToUpper());
      return foundPerson;
    }

    // POST api/values
    public Person Post(Person person)
    {
      if (!_people.Any(a => a.Name == person.Name))
      {
        _people.Add(person);
      }
      _cache.StoreDataInCache("people", _people);
      return person;
    }

    // PUT api/values/5
    public Person Put(string id, Person person)
    {
      var foundPerson = _people.SingleOrDefault(a => a.Name == person.Name);
      if (foundPerson != null)
      {
        foundPerson = person;
      }
      _cache.StoreDataInCache("people", _people);
      return person;
    }

    // DELETE api/values/5
    public void Delete(string id)
    {
      var foundPerson = _people.SingleOrDefault(person => person.Name.ToUpper() == id.ToUpper());
      _people.Remove(foundPerson);
      _cache.StoreDataInCache("people", _people);
    }
  }
}