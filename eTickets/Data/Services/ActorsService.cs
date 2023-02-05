﻿using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext _context;
        public ActorsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Actor actor)
        {
           await _context.Actors.AddAsync(actor);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(n => n.Id == id);
            _context.Actors.Remove(result);
            await _context.SaveChangesAsync();
        }

       public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var result=await _context.Actors.ToListAsync();
            return result;
        }
        public async Task<Actor> GetByIdAsync(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(n=>n.Id==id);
            return result;
        }

        public async Task<Actor> UpdateAsync(int id, Actor newActor)
        {
            //newActor.Id = id;

            _context.Update(newActor);
            await _context.SaveChangesAsync();
            return newActor;
        }
    }
}
