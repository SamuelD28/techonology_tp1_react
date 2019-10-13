using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using technology_tp1.Models;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Technology_Tp1_React.General
{
    /// <summary>
    /// Repository based on entity framework core. Saves the data in an sql database
    /// </summary>
    /// <typeparam name="T">Entity Model to handle</typeparam>
    public class EFCoreRepository<T> : IRepository<T>
        where T : class, IEntity
    {
        public AppDbContext DbContext { get; set; }

        /// <summary>
        /// Constructor for the repository. Need a database context to operate.
        /// </summary>
        /// <param name="dbContext">Application database context</param>
        public EFCoreRepository(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        /// <summary>
        /// Create a new document in the database
        /// </summary>
        /// <param name="document">Document to create</param>
        public void Create(T document)
        {
            DbContext.Set<T>().Add(document);
        }

        /// <summary>
        /// Delete a document from the database
        /// </summary>
        /// <param name="id">Id of the document to delete</param>
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

        /// <summary>
        /// Get all the document from the database
        /// </summary>
        /// <returns>List of document</returns>
        public IQueryable<T> GetAll()
        {
            return DbContext.Set<T>().AsQueryable();
        }

        /// <summary>
        /// Get a single document by the id
        /// </summary>
        /// <param name="id">Id of the document to retrieve</param>
        /// <returns>Single document or null</returns>
        public T GetById(int id)
        {
            return DbContext
                .Set<T>()
                .FirstOrDefault(d => d.Id == id);
        }

        /// <summary>
        /// Update a document in the database
        /// </summary>
        /// <param name="document">Updated document</param>
        public void Update(T document)
        {
            DbContext.Entry<T>(document).CurrentValues.SetValues(document);
            DbContext.Entry<T>(document).State = EntityState.Modified;
        }

        /// <summary>
        /// Get a single document based on a predicate
        /// </summary>
        /// <param name="predicate">Prediacate</param>
        /// <returns>Single Document</returns>
        public T Where(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().FirstOrDefault(predicate);
        }

        /// <summary>
        /// Get a collection of document based on a predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().Where(predicate);
        }

        /// <summary>
        /// Save the changes made in the database.
        /// </summary>
        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        /// <summary>
        /// Method that verify if a record in teh database match the predicate
        /// </summary>
        /// <param name="predicate">Predicate</param>
        /// <returns>True if it exists</returns>
        public bool Contains(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().Any(predicate);
        }
    }
}
