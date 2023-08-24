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
        public DisciplineRepository()
        {
            using (var context = new ApiContext())
            {
                var disciplines = new List<Discipline>()
                {
                    new Discipline
                    {
                        Name = "Projeto Integrador I",
                        Value = 50,
                        Available = true,
                        Ead = true
                    },
                    new Discipline
                    {
                        Name = "Projeto Integrador II",
                        Value = 60,
                        Available = true,
                        Ead = false
                    },
                    new Discipline
                    {
                        Name = "Banco de Dados I",
                        Value = 40,
                        Available = false,
                        Ead = false
                    }
                };

                context.Disciplines.AddRange(disciplines);
                context.SaveChanges();
            }
        }

        public List<Discipline> GetDisciplines()
        {
            using (var context = new ApiContext())
            {
                return context.Disciplines.ToList();
            }
        }
    }
}
