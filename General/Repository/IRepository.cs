using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Technology_Tp1_React.General
{
    /// <summary>
    /// Interface for creating new generic repository.
    /// </summary>
    /// <typeparam name="T">Model to handle in the repository</typeparam>
    public interface IRepository<T> 
        where T : IEntity
    {
        /// <summary>
        /// Method that return a collection of entity that can be queryable
        /// </summary>
        /// <returns>Queryable list of model</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Method that return a single model that matches the id
        /// </summary>
        /// <param name="id">Id of the model</param>
        /// <returns></returns>
        T GetById(int id);

        /// <summary>
        /// Method that create a new document.
        /// </summary>
        /// <param name="document">New document to create</param>
        void Create(T document);

        /// <summary>
        /// Method that update a new document
        /// </summary>
        /// <param name="document">New document</param>
        void Update(T document);

        /// <summary>
        /// Method that return a single document based on the predicate
        /// </summary>
        /// <param name="predicate">Predicate</param>
        /// <returns>Single Model</returns>
        T Where(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Method that return a collection of model specified by the predicate
        /// </summary>
        /// <param name="predicate">Predicate</param>
        /// <returns>Collection of model</returns>
        IEnumerable<T> Filter(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Method that check if a model match a predicate
        /// </summary>
        /// <param name="predicate">Predicate</param>
        /// <returns>True if exists</returns>
        bool Contains(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Method that delete a document.
        /// </summary>
        /// <param name="id">id of teh document to delete</param>
        void Delete(int id);

        /// <summary>
        /// Method that save the changes made to the database.
        /// </summary>
        void SaveChanges();
    }
}
