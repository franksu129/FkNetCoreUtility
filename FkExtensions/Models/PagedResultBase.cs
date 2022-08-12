namespace FkExtensions.Models;

public abstract class PagedResultBase
{
    /// <summary>
    /// 當前頁面
    /// </summary>
    public int CurrentPage { get; set; }
    /// <summary>
    /// 分頁數量 (或 最後一頁)
    /// </summary>
    public int PageCount { get; set; }
    /// <summary>
    /// 單頁顯示筆數
    /// </summary>
    public int PageSize { get; set; }
    /// <summary>
    /// 總比數
    /// </summary>
    public int RowCount { get; set; }

    /// <summary>
    /// 當前頁面 第一筆 索引(index)
    /// </summary>
    public int FirstRowOnPage
    {
        get { return (CurrentPage - 1) * PageSize + 1; }
    }

    /// <summary>
    /// 當前頁面 最後一筆 索引(index)
    /// </summary>
    public int LastRowOnPage
    {
        get { return Math.Min(CurrentPage * PageSize, RowCount); }
    }
}