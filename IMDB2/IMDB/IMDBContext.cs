﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace IMDB
{
    class IMDBContext : DbContext
    {
        public IMDBContext() : base("name=IMDBConnectionString")
        {
            Database.SetInitializer<IMDBContext>(new CreateDatabaseIfNotExists<IMDBContext>());
        }

        public DbSet<Movie> movies { get; set; }
        public DbSet<Cast> casts { get; set; }
        public DbSet<CastRole> castRoles { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
    }
}
