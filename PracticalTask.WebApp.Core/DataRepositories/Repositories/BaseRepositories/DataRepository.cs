using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PracticalTask.WebApp.Core.DataModels.Sheets;
using PracticalTask.WebApp.Core.DataRepositories.Contracts.BaseContracts;
using PracticalTask.WebApp.Data.Contexts;
using PracticalTask.WebApp.Dto.DtoModels;

namespace PracticalTask.WebApp.Core.DataRepositories.Repositories.BaseRepositories;

public class DataRepository<T> : IDataRepository<T> where T : class
{
    protected readonly AppDbContext Context;
    protected readonly IMapper Mapper;

    public DataRepository(AppDbContext context, IMapper mapper)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(mapper);

        Context = context;
        Mapper = mapper;
    }

    public async Task<TResult> CreateAsync<TSource, TResult>(TSource source)
    {
        var entity = Mapper.Map<T>(source);
        await Context.AddAsync(entity);
        await Context.SaveChangesAsync();
        return Mapper.Map<TResult>(entity);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await GetAsync(id);
        if (entity is null)
        {
            return false;
        }
        Context.Set<T>().Remove(entity);
        await Context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Exists(int id)
    {
        var entity = await GetAsync(id);
        return entity != null;
    }

    public async Task<List<TResult>> GetAllAsync<TResult>()
    {
        return await Context.Set<T>()
            .ProjectTo<TResult>(Mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<SheetResult<TResult>> GetAllAsync<TResult>(SheetQuery sheetQuery)
    {
        var totalSize = await Context.Set<T>().CountAsync();
        var items = await Context.Set<T>()
            .Skip(sheetQuery.StartIndex)
            .Take(sheetQuery.SheetSize)
            .ProjectTo<TResult>(Mapper.ConfigurationProvider)
            .ToListAsync();

        return new SheetResult<TResult>
        {
            TotalCount = totalSize,
            RecordNumber = sheetQuery.SheetSize,
            SheetNumber = sheetQuery.SheetNumber,
            Items = items,
        };
    }

    public async Task<T?> GetAsync(int id)
    {
        var result = await Context.Set<T>().FindAsync(id);
        if (result is null)
        {
            return null;
        }
        return result;
    }

    public async Task<TResult?> GetAsync<TResult>(int id)
    {
        var result = await Context.Set<T>().FindAsync(id);
        if (result is null)
        {
            return default;
        }
        return Mapper.Map<TResult>(result);
    }

    public async Task<bool> UpdateAsync<TSource>(int id, TSource source) where TSource : IDto
    {
        var entity = await GetAsync(id);
        if (entity == null)
        {
            return false;
        }
        Mapper.Map(source, entity);
        Context.Update(entity);
        await Context.SaveChangesAsync();
        return true;
    }
}