﻿using System.Data.Entity.Infrastructure;

namespace EFConvention.Interceptors
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPreInsertEventListener
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityEntry"></param>
        void OnInsert(DbEntityEntry entityEntry);
    }
}
