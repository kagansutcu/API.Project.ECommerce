﻿using BLL.DesignPatterns.RepositoryPattern.IRep;
using BLL.DesignPatterns.SingeltonPattern;
using DAL.Context;
using Model;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DesignPatterns.RepositoryPattern.BaseRep
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected MyContext db;
        public BaseRepository()
        {
            db = DBTool.DBInstance;
        }
        public void Add(T item)
        {
            db.Set<T>().Add(item);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Any(exp);
        }

        public T Default(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().FirstOrDefault(exp);
        }

        public void Delete(T item)
        {
            item.DeletedDate = DateTime.Now;
            item.Status = DataStatus.Deleted;
            Save();
        }

        public void Destroy(T item)
        {
            db.Set<T>().Remove(item);
            Save();
        }

        public T Find(int id)
        {
            return db.Set<T>().Find(id);
        }

        public List<T> GetActives()
        {
            return db.Set<T>().Where(x => x.Status != DataStatus.Deleted).ToList();
        }

        public List<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public List<T> GetModifieds()
        {
            return db.Set<T>().Where(x => x.Status == DataStatus.Updated).ToList();
        }

        public List<T> GetPassives()
        {
            return db.Set<T>().Where(x => x.Status == DataStatus.Deleted).ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public object Select(Expression<Func<T, object>> exp)
        {
            return db.Set<T>().Select(exp).ToList();
        }

        public void Update(T item)
        {
            T toBeUpdated = db.Set<T>().Find(item.ID);
            item.ModifiedDate = DateTime.Now;
            item.Status = DataStatus.Updated;
            db.Entry(toBeUpdated).CurrentValues.SetValues(item);
            Save();
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Where(exp).ToList();
        }
    }
}
