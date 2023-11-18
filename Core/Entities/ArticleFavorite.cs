namespace BookStore.Core.Entities;

public class ArticleFavorite
{

    public ArticleFavorite(string userName, Guid articleId)
    {
        UserName = userName;
        ArticleId = articleId;
    }

    public string UserName { get; set; }

    public Guid ArticleId { get; set; }

    public User User { get; set; } = null!;

    public Article Article { get; set; } = null!;
}