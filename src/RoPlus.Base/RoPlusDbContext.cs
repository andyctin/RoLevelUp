﻿using Microsoft.EntityFrameworkCore;

namespace RoPlus.Base.Model {
  public partial class RoPlusDbContext: DbContext {
    public RoPlusDbContext( DbContextOptions<RoPlusDbContext> options )
        : base(options)
    { }
    protected override void OnModelCreating( ModelBuilder modelBuilder ) {

      modelBuilder.Entity<Section>( entity => {
        entity.Property( e => e.Id ).IsRequired();
        entity.Property( e => e.Name ).IsRequired();
        entity.Property( e => e.Description ).IsRequired();
      } );
    }
    public virtual DbSet<Section> Sections { get; set; }
  }
}