using BookStore.Core.Dto;
using BookStore.Infrastructure.Utils;

namespace BookStore.Core.Entities;

public class Article
{

    public Article(string title, string description, string body)
    {
        Slug = title.GenerateSlug();
        Title = title;
        Description = description;
        Body = body;
        CreateAt = DateTimeOffset.UtcNow;
        UpdatedAt = DateTimeOffset.UtcNow;
    }


    public Guid Id { get; set; }

    public string Slug { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Body { get; set; }

    public User Author { get; set; } = null!;

    public DateTimeOffset CreateAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }

    public bool Favorite { get; set; }

    public int FavoriteCount { get; set; } = 0;
    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    public List<Comment> Comments { get; set; } = new();
    public ICollection<ArticleFavorite> ArticleFavorites { get; set; } = new List<ArticleFavorite>();


    public void UpdateArticle(ArticleUpdateDto updateDto)
    {
        if (!string.IsNullOrWhiteSpace(updateDto.Title))
        {
            Title = updateDto.Title;
            Slug = updateDto.Title.GenerateSlug();
        }

        if (!string.IsNullOrWhiteSpace(updateDto.Body)) Body = updateDto.Body;

        if (!string.IsNullOrWhiteSpace(updateDto.Description)) Description = updateDto.Description;

        UpdatedAt = DateTimeOffset.UtcNow;
    }
}