using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using BookStore.Core.Dto;

namespace BookStore.Core.Entities;

public class User
{
    public User()
    {
    }

    public User(NewUserDto newUserDto)
    {
    }
    
    public string Username { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Bio { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public ICollection<ArticleFavorite>? ArticleFavorites { get; set; }
    public ICollection<Comment>? ArticleComments { get; set; }

    public ICollection<UserLink> Followers { get; set; } = new List<UserLink>();

    public ICollection<UserLink> FollowedUsers { get; set; } = new List<UserLink>();

    public void UpdateUser(UpdatedUserDto updatedUser)
    {
        Username = updatedUser.Username ?? Username;
        Email = updatedUser.Email ?? Email;
        Bio = updatedUser.Bio ?? Bio;
        Image = updatedUser.Image ?? Image;
        Password = updatedUser.Password ?? Password;
    }
}