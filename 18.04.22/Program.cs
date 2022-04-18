using _18._04._22.DAL;
using _18._04._22.Exceptions;
using _18._04._22.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _18._04._22
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            AddPost(post);
            //EditPostTitle(2);
            //GetPostById(1);
            //GetAllPosts();
            //DeletePost(3);
        }

        //1-
        static void AddPost(Post post)
        {
            post.Title = "Test";
            post.Content = "Test";
            post.Image = "test.jpg";
        

            using (AppDbContext dbContext = new AppDbContext())
            {
               
                dbContext.Posts.Add(post);
                dbContext.SaveChanges();
            }
            Console.WriteLine($"{post.Title} created");
        }

        //2 deqiq bilmirem
        static void EditPostTitle(int? id,string title)
        {
            if (id == null)
            {
                throw new NullReferenceException("id null ola bilmez");
                
            }
            using (AppDbContext dbContext = new AppDbContext())
            {
                Post post = dbContext.Posts.FirstOrDefault(p => p.Id == id);
                if (post == null)
                {
                    throw new NotFoundException("Bele post tapilmadi");
                }
                post.Title = "Test";
                dbContext.SaveChanges();
                Console.WriteLine($"{post.Title} changed");
            }
        }

        //3 mence duzdu
        static void GetPostById(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException("id null ola bilmez");
            }
            using (AppDbContext dbContext = new AppDbContext())
            {
                Post post = dbContext.Posts.FirstOrDefault(p => p.Id == id);
                if (post == null)
                {
                    throw new NotFoundException("Post tapilmadi");
                }
                Console.WriteLine($"{post.Title} {post.Content} {post.Image}");


            }
        }

        //4+
        static void GetAllPosts()
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
        
        //5+
        static void DeletePost(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException("Id null ola bilmez");
                
            }
            using (AppDbContext dbContext = new AppDbContext())
            {
                Post post = dbContext.Posts.FirstOrDefault(p => p.Id == id);
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
