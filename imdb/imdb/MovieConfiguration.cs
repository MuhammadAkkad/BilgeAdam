﻿using System.Data.Entity.ModelConfiguration;

namespace imdb
{
    class MovieConfiguration :
       EntityTypeConfiguration<Movie>
    {

        public MovieConfiguration() {
            Property(m => m.Name).IsRequired();            
        }

    }
}