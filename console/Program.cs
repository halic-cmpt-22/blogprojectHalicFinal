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

var blog2 = new Blog(); // Ömer Faruk
blog2.Url = "https://github.com/OmerDemir0"; // Ömer Faruk
blog.Rating = 10; // Ömer Faruk

var blog3 = new Blog(); // Ömer Faruk
blog2.Url = "https://github.com/mehmetfrk";  // Ömer Faruk
blog.Rating = 10; // Ömer Faruk

var blog4 = new Blog(); // Ömer Faruk
blog2.Url = "https://github.com/bechesoftware";  // Ömer Faruk
blog.Rating = 10; // Ömer Faruk


blog.Posts.Add(post);
db.Add(blog); // Ömer Faruk
db.Add(blog2); // Ömer Faruk
db.Add(blog3); // Ömer Faruk
db.Add(blog4); // Ömer Faruk
db.SaveChanges();