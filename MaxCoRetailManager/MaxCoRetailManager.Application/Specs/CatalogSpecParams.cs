﻿namespace MaxCoRetailManager.Application.Specs;

public class CatalogSpecParams
{
    private const int MaxPageSize = 100;
    public int PageIndex { get; set; } = 1;
    private int _pageSize = 10;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
    public string Sort { get; set; } = string.Empty;
    private string _search = "";
    public string Search
    {
        get => _search;
        set => _search = value.ToLower();
    }
}
