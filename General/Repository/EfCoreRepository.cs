﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using technology_tp1.Models;

namespace Technology_Tp1_React.General
{

    public class EFCoreRepository<T> : IRepository<T>
        where T : class, IEntity
    {
        public AppDbContext DbContext { get; set; }

        public EFCoreRepository(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Create(T document)
        {
            DbContext.Set<T>().Add(document);
        }

        public void Delete(int id)
        {
            T documentToRemove = DbContext
                .Set<T>()
                .FirstOrDefault(d => d.Id == id);

            if (documentToRemove != null)
            {
                DbContext.Set<T>().Remove(documentToRemove);
            }
        }

        public IQueryable<T> GetAll()
        {
            return DbContext.Set<T>().AsQueryable();
        }

        public T GetById(int id)
        {
            return DbContext
                .Set<T>()
                .FirstOrDefault(d => d.Id == id);
        }
        public void Update(T document)
        {
            DbContext.Set<T>().Update(document);
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }
    }
}
