using System.Collections.Generic;
using System.Linq;
using Host.Models;

namespace Host.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly List<Post> _posts = new List<Post>
            {
                new Post
                    {
                        Id = 1,
                        Title = "Rails is omakase",
                        Comments = new[]
                            {
                                new Comment
                                    {
                                        Id = 1,
                                        Body = "But is it _lightweight_ omakase?"
                                    },
                                new Comment
                                    {
                                        Id = 2,
                                        Body = "I for one welcome our new omakase overlords"
                                    },
                                new Comment
                                    {
                                        Id = 3,
                                        Body = "Put me on the fast track to a delicious dinner"
                                    }
                            }
                    },
                new Post
                    {
                        Id = 2,
                        Title = "Having fun with ember data",
                        Comments = new[]
                            {
                                new Comment
                                    {
                                        Id = 4,
                                        Body = "But I'm le tired"
                                    }
                            }
                    }
            };

        public IEnumerable<Post> GetPosts()
        {
            return _posts.OrderBy(post => post.Id);
        }

        public Post GetPost(int id)
        {
            return GetPosts().FirstOrDefault(post => post.Id == id);
        }

        public void AddPost(Post newPost)
        {
            newPost.Id = _posts.Max(post => post.Id) + 1;
            _posts.Add(newPost);
        }

        public void DeletePost(int id)
        {
            _posts.RemoveAll(post => post.Id == id);
        }

        public void UpdatePost(int id, Post updatedPost)
        {
            updatedPost.Id = id;
            DeletePost(id);
            AddPost(updatedPost);
        }

        public IEnumerable<Comment> GetComments()
        {
            return GetPosts().SelectMany(post => post.Comments);
        }

        public Comment GetComment(int id)
        {
            return GetComments().FirstOrDefault(comment => comment.Id == id);
        }
    }
}