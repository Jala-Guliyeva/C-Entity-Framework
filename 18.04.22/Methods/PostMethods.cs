using _18._04._22.DAL;
using _18._04._22.Exceptions;
using _18._04._22.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _18._04._22.Methods
{
    internal class PostMethods
    {
        public void AddPost(Post post)
        {
           


            using (AppDbContext dbContext = new AppDbContext())
            {

                dbContext.Posts.Add(post);
                dbContext.SaveChanges();
            }
            Console.WriteLine($"{post.Title} created");
        }

        //2 
        public void EditPostTitle(int? id, string title)
        {
            if (id == null)
            {
                throw new NullReferenceException("id null ola bilmez");

            }
            using (AppDbContext dbContext = new AppDbContext())
            {
                Post post = dbContext.Posts.Find(id);
                if (post == null)
                {
                    throw new NotFoundException("Bele post tapilmadi");
                }
                post.Title = title;
                dbContext.SaveChanges();
                Console.WriteLine($"{post.Title} changed");
            }
        }

        //3.
        public Post GetPostById(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException("id null ola bilmez");
            }
            using (AppDbContext dbContext = new AppDbContext())
            {
                Post post = dbContext.Posts.Find(id);
                if (post == null)
                {
                    throw new NotFoundException("Post tapilmadi");
                }

                return post;

            }
            

        }

        //4.
        public void GetAllPosts()
        {

            using (AppDbContext dbContext = new AppDbContext())
            {
                List<Post> posts = dbContext.Posts.ToList();
                Console.WriteLine($"Posts list:");
                foreach (var item in posts)
                {
                    Console.WriteLine($"{item.Title} {item.Content} {item.Image}");
                }
            }



        }

        //5.
        public void DeletePost(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException("Id null ola bilmez");

            }
            using (AppDbContext dbContext = new AppDbContext())
            {
                Post post = dbContext.Posts.Find(id);
                if (post == null)
                {
                    throw new NotFoundException("Bele bir sey tapilmadi");
                }
                dbContext.Posts.Remove(post);
                dbContext.SaveChanges();
                Console.WriteLine($"{post.Title} removed");
            }
        }
    }
}
