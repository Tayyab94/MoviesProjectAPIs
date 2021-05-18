using Movies_APIs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_APIs.Services
{
    public class InMemoryRepository : IRepository
    {
        private List<Genres> _genres;
        public InMemoryRepository()
        {

            _genres = new List<Genres>()
            {
                new Genres()
                {
                     Id=1,
                      Name="Action"
                },
                new Genres()
                {
                     Id=2,
                      Name="Comedy"
                },

                new Genres()
                {
                     Id=3,
                      Name="Normal Movie"
                },
                new Genres()
                {
                     Id=4,
                      Name="Comedy With"
                },
            };
        }

        public Task AddGenra(Genres model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteGenres(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Genres>> GetAllRenres()
        {
            await Task.Delay(1);
            return _genres;
        }

        public Genres GetGenrasById(int id)
        {
            return _genres.Where(s => s.Id == id).FirstOrDefault();
        }
    }
}
