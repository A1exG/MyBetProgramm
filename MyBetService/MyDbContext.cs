using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBetModel.Model;

namespace MyBetService
{
    public class MyDbContext : DbContext
    {
        public DbSet<Bet> Bets { get; set; }
        public DbSet<EventBet> EventBets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Result> Results { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=DbTestTask;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bet>().ToTable("Bets").HasKey(p => p.BetId).HasName("PrimaryKey_BlogId"); 
            modelBuilder.Entity<EventBet>().ToTable("Events").HasKey(p => p.EventId).HasName("PrimaryKey_EventId");
            modelBuilder.Entity<Result>().ToTable("Results").HasKey(p => p.ResultId).HasName("PrimaryKey_ResultId");
            modelBuilder.Entity<User>().ToTable("Users").HasKey(p => p.UserId).HasName("PrimaryKey_UserId");
            modelBuilder.Entity<History>().ToTable("History").HasKey(p => p.EventId).HasName("PrimaryKey_EventId");
        }
    }
}