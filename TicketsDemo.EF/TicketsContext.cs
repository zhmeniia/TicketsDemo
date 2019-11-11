﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsDemo.Data.Entities;

namespace TicketsDemo.EF
{
    public class TicketsContext : DbContext
    {
        public DbSet<Train> Trains { get; set; }
        public DbSet<Place> Places {get;set;}
        public DbSet<Carriage> Carriages { get; set; }
        
        public DbSet<Run> Runs {get;set;}
        public DbSet<PlaceInRun> PlacesInRuns {get;set;}
        public DbSet<Reservation> Reservations {get;set;}
        public DbSet<Ticket> Tickets {get;set; }

        public DbSet<PriceComponent> PriceComponents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Train>().HasMany(t => t.Carriages).WithRequired(c => c.Train);

            modelBuilder.Entity<Carriage>().HasMany(c => c.Places).WithRequired(p => p.Carriage);
            
            modelBuilder.Entity<PlaceInRun>().HasRequired(p => p.Run).WithMany(r => r.Places);

            modelBuilder.Entity<Ticket>().HasMany(x => x.PriceComponents).WithRequired(x => x.Ticket);

            modelBuilder.Entity<Reservation>();

            modelBuilder.Entity<CompanyMargin>().HasRequired(m => m.Train).WithOptional(t => t.CompanyMargin);
        } 

    }
}
