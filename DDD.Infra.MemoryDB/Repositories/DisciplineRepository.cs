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
        public List<Discipline> GetDiciplines()
        {
            var list = _context.Disciplines.ToList();
            return list;
        }

        public void InsertDicipline(Discipline dicipline)
        {
            _context.Disciplines.Add(dicipline);
            _context.SaveChanges();
        }
        public void UpdateDiscipline(Discipline dicipline)
        {
            _context.Entry(dicipline).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void DeleteStudent(Discipline dicipline)
        {
            _context.Set<Discipline>().Remove(dicipline);
            _context.SaveChanges(); 
        }

        public List<Discipline> GetDisciplines()
        {
            throw new NotImplementedException();
        }

        public void DeleteDiscipline(Discipline discipline)
        {
            throw new NotImplementedException();
        }
    }
}
