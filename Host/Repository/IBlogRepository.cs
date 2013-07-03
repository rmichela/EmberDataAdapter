using System.Collections.Generic;
using Host.Models;

namespace Host.Repository
{
    public interface IBlogRepository
    {
        IEnumerable<Post> GetPosts();
        Post GetPost(int id);
        void AddPost(Post newPost);
        void DeletePost(int id);
        void UpdatePost(int id, Post updatedPost);
        IEnumerable<Comment> GetComments();
        Comment GetComment(int id);
    }
}