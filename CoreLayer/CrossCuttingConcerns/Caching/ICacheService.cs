using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLayer.CrossCuttingConcerns.Caching
{
    public interface ICacheService
    {
        T Get<T>(T key);
        object Get(string key); //alternatif
        void Add(string key, object value, int duration);

        bool IsAdd(string key);
        void Remove(string key);

        void RemoveByPattern(string pattern);
    }
}
