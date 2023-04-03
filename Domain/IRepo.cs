using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HW_01_Eurich_Kapitonova.Domain
{
    public interface IRepo<T> : IPagedRepo<T> where T : UniqueEntity { }
    public interface IPagedRepo<T> : IOrderedRepo<T> where T : UniqueEntity
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; }
        public bool HasNextPage { get; }
        public bool HasPreviousPage { get; }
        public int PageSize { get; set; }
    }
    public interface IOrderedRepo<T> : IFilteredRepo<T> where T : UniqueEntity 
    {
        public string? CurrentOrder { get; set; }
        public string SortOrder(string propertyName);
    }
    public interface IFilteredRepo<T> : ICrudRepo<T> where T : UniqueEntity
    {
        public string? CurrentFilter { get; set; }
    }
    public interface ICrudRepo<T> : IBaseRepo<T> where T : UniqueEntity { }
    public interface IBaseRepo<T> where T : UniqueEntity
    {
        //This is CRUD
        bool Add(T obj);//Create
        List<T> Get();//Read
        List<T> GetAll(Func<T, dynamic>? orderBy = null);
        T Get(string id);//Read
        bool Update(T obj);//Update
        bool Delete(string id);//Delete

        Task<bool> AddAsync(T obj);
        Task<List<T>> GetAsync();
        Task<T> GetAsync(string ID);
        Task<bool> UpdateAsync(T obj);
        Task<bool> DeleteAsync(string ID);
    }
}
