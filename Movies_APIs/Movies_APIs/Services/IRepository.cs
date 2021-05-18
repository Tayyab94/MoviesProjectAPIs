using Movies_APIs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_APIs.Services
{
    public interface IRepository
    {
        Task<List<Genres>> GetAllRenres();

        Genres GetGenrasById(int id);

        public Task AddGenra(Genres model);


        public Task DeleteGenres(int id);
    }
}
