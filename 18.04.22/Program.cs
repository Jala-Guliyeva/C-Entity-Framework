using _18._04._22.DAL;
using _18._04._22.Exceptions;
using _18._04._22.Methods;
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
            PostMethods post = new PostMethods();
            Post post1=new Post
            {
                Title ="test",
                Content="test1",
                Image="test.jpg"
            };

            //post.AddPost(post1);
            //post.EditPostTitle(3,"test2");
            //post.DeletePost(4);
             //post.GetAllPosts();
                post.GetPostById(3);
           
        }

        
       


    }
}
