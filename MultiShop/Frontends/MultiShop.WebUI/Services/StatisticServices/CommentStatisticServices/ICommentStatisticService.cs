namespace MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices
{
    public interface ICommentStatisticService
    {
        Task<int> GetCommentCount();
        Task<int> GetActiveCommentCount();
        Task<int> GetPassiveCommentCount();
    }
}
