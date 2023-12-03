using Microsoft.EntityFrameworkCore;
using OnlineExam1.Entity;
using System.Collections.Generic;
namespace OnlineExam1.Entity
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<QuestionBank> QuestionBanks { get; set; }
        public DbSet<TestStructure> TestStructures { get; set; }
        public DbSet<AssignedTest> AssignedTests{ get; set; }
        public DbSet<UserResponse> UserResponses { get; set; }
    }
   
}