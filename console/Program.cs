// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Linq;
using data;
using data.tables;

using var db = new BlogContext();

Console.WriteLine($"Database path: {db.DbPath}.");

// Create
/*
Console.WriteLine("Inserting a new blog");
db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
db.SaveChanges();
*/
var blog = new Blog();
blog.Url = "http://www.google.com";
blog.Rating = 5;

var post = new Post();
post.Title = "New Post";
post.Content = "New Content";

var blog2 = new Blog(); 
blog2.Url = "https://github.com/OmerDemir0"; 
blog.Rating = 10; 

var blog3 = new Blog(); 
blog2.Url = "https://github.com/mehmetfrk";  
blog.Rating = 10; 

var blog4 = new Blog(); 
blog2.Url = "https://github.com/bechesoftware";  
blog.Rating = 10; 

var jokes = new Jokes(); 
jokes.jcontext = "dunyanınenkomiksakasi";


blog.Posts.Add(post);
db.Add(blog); 
db.Add(blog2); 
db.Add(blog3); 
db.Add(blog4);
db.Add(jokes);
db.SaveChanges();