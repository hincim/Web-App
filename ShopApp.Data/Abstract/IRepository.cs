﻿using ShopApp.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopApp.Data.Abstract
{
    public interface IRepository<T>
    {
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        void Create(T entity);
        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
