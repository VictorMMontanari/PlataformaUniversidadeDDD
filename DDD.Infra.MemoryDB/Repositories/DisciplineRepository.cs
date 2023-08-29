using DDD.Infra.MemoryDB.Interfaces;
using DDD.Unimar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.MemoryDB.Repositories
{
    public class DisciplineRepository : IDisciplineRepository
    {
        private readonly ApiContext _context;

        public DisciplineRepository(ApiContext context)
        {
            _context = context;
        }

        public Discipline GetDisciplineById(int id)
        {
            return _context.Disciplines.Find(id);
        }

        public List<Discipline> GetDisciplines() 
        {
            return _context.Disciplines.ToList(); 
        }

        public void InsertDiscipline(Discipline discipline)
        {
            _context.Disciplines.Add(discipline);
            _context.SaveChanges();
        }

        public void UpdateDiscipline(Discipline discipline)
        {
            _context.Entry(discipline).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteDiscipline(Discipline discipline) 
        {
            _context.Disciplines.Remove(discipline); 
            _context.SaveChanges();
        }
    }
}
