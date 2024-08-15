using Microsoft.EntityFrameworkCore;

namespace MaxCoRetailManager.Application.Specs;

public class Pagination<T> where T : class
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public long Count { get; set; }
    public IReadOnlyList<T> Data { get; set; }

    public Pagination(int pageIndex, int pageSize, int count, IReadOnlyList<T> data)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
        Count = count;
        Data = data;
    }
    public Pagination()
    {

    }
    public static Pagination<T> ToPagedList(IReadOnlyList<T> source, int pageIndex, int pageSize, int count)
    {
        return new Pagination<T>(pageIndex, pageSize, count, source);
    }

    public static async Task<Pagination<T>> ToPagedListAsync(IQueryable<T> source, int pageIndex, int pageSize)
    {
        var count = await source.CountAsync();
        var data = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        return new Pagination<T>(pageIndex, pageSize, count, data);
    }


}
