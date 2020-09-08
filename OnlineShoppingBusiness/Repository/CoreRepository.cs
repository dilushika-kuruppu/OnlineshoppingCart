using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Business.Repository
{
    public abstract class CoreRepository { }
      //where TContext : DbContext
      //  {
      //      private readonly TContext context;
      //      public CoreRepository(TContext context)
      //      {
      //          this.context = context;
      //      }

      //  public async Task<TEntity> Add(TEntity entity)
      //  {
      //      context.Set<TEntity>().Add(entity);
      //      await context.SaveChangesAsync();
      //      return entity;
      //  }

      

      //  public async Task<TEntity> Get(int id)
      //  {
      //      return await context.Set<TEntity>().FindAsync(id);
      //  }

      //  public async Task<List<TEntity>> GetAll()
      //  {
      //      return await context.Set<TEntity>().ToListAsync();
      //  }

      
    }
      

    
