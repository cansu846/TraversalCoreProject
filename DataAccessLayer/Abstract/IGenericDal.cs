﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T>
    {
        public void Insert(T t);
        public void Delete(T t);
        public void Update(T t);
        public List<T> GetList();
        public T GetById(int id);
        public List<T> GetListByFilter(Expression<Func<T,bool>> filter);
    }
}
