using Microsoft.EntityFrameworkCore;
using Movies_APIs.Entities;
using Movies_APIs.Entities.Contaxt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_APIs.Services
{
    public class GenresRepository : IRepository
    {
        private readonly ApplicationDbContaxt context;

        public GenresRepository(ApplicationDbContaxt context)
        {
            this.context = context;
        }
        public async Task<List<Genres>> GetAllRenres()
        {
            return await context.Genres.ToListAsync();
        }

        public async Task AddGenra(Genres model)
        {

            await context.Genres.AddAsync(model);

            await context.SaveChangesAsync();
        }
        public Genres GetGenrasById(int id)
        {
            return context.Genres.Where(s => s.Id == id).SingleOrDefault();
        }

        public async Task DeleteGenres(int id)
        {
            var data = context.Genres.Where(s => s.Id == id).FirstOrDefault();

            context.Genres.Remove(data);

            await context.SaveChangesAsync();
            
        }
    }
}
