﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Synchronic_World.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class synchronicDBEntities : DbContext
    {
        public synchronicDBEntities()
            : base("name=synchronicDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<User> UserSet { get; set; }
        public DbSet<Event> EventSet { get; set; }
        public DbSet<Contribution> ContributionSet { get; set; }
        public DbSet<Friends> FriendsSet { get; set; }
    }
}
