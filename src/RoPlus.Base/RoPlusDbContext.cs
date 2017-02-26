using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RoPlus.Base.Models {
    public partial class RoPlusDbContext: DbContext {
        public RoPlusDbContext( DbContextOptions<RoPlusDbContext> options )
            : base( options ) { }
        protected override void OnModelCreating( ModelBuilder modelBuilder ) {
            base.OnModelCreating( modelBuilder );

            modelBuilder
                .HasAnnotation( "ProductVersion", "1.0.1" )
                .HasAnnotation( "SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn );

            modelBuilder.Entity<ApplicationUser>( entity => {
                entity.Property( p => p.Id );

                entity.Property( p => p.AccessFailedCount );

                entity.Property( p => p.ConcurrencyStamp )
                    .IsConcurrencyToken();

                entity.Property( p => p.Email )
                    .HasAnnotation( "MaxLength", 256 );

                entity.Property( p => p.EmailConfirmed );

                entity.Property( p => p.LockoutEnabled );

                entity.Property( p => p.LockoutEnd );

                entity.Property( p => p.NormalizedEmail )
                    .HasAnnotation( "MaxLength", 256 );

                entity.Property( p => p.NormalizedUserName )
                    .HasAnnotation( "MaxLength", 256 );

                entity.Property( p => p.PasswordHash );

                entity.Property( p => p.PhoneNumber );

                entity.Property( p => p.PhoneNumberConfirmed );

                entity.Property( p => p.SecurityStamp );

                entity.Property( p => p.TwoFactorEnabled );

                entity.Property( p => p.UserName )
                    .HasAnnotation( "MaxLength", 256 );

                entity.HasKey( "Id" );

                entity.HasIndex( "NormalizedEmail" )
                    .HasName( "EmailIndex" );

                entity.HasIndex( "NormalizedUserName" )
                    .IsUnique()
                    .HasName( "UserNameIndex" );

                entity.ToTable( "Account_Users" );
            } );

            modelBuilder.Entity<IdentityRole>( entity => {
                entity.Property( p => p.Id );

                entity.Property( p => p.ConcurrencyStamp )
                    .IsConcurrencyToken();

                entity.Property( p => p.Name )
                    .HasAnnotation( "MaxLength", 256 );

                entity.Property( p => p.NormalizedName )
                    .HasAnnotation( "MaxLength", 256 );

                entity.HasKey( "Id" );

                entity.HasIndex( "NormalizedName" )
                    .HasName( "RoleNameIndex" );

                entity.ToTable( "Account_Roles" );
            } );

            modelBuilder.Entity<IdentityRoleClaim<string>>( entity => {
                entity.Property( p => p.Id )
                    .ValueGeneratedOnAdd();

                entity.Property( p => p.ClaimType );

                entity.Property( p => p.ClaimValue );

                entity.Property( p => p.RoleId )
                    .IsRequired();

                entity.HasKey( "Id" );

                entity.HasIndex( "RoleId" );

                entity.ToTable( "Account_RoleClaims" );
            } );

            modelBuilder.Entity<IdentityUserClaim<string>>( entity => {
                entity.Property( p => p.Id )
                    .ValueGeneratedOnAdd();

                entity.Property( p => p.ClaimType );

                entity.Property( p => p.ClaimValue );

                entity.Property( p => p.UserId )
                    .IsRequired();

                entity.HasKey( "Id" );

                entity.HasIndex( "UserId" );

                entity.ToTable( "Account_UserClaims" );
            } );

            modelBuilder.Entity<IdentityUserLogin<string>>( entity => {
                entity.Property( p => p.LoginProvider );

                entity.Property( p => p.ProviderKey );

                entity.Property( p => p.ProviderDisplayName );

                entity.Property( p => p.UserId )
                    .IsRequired();

                entity.HasKey( "LoginProvider", "ProviderKey" );

                entity.HasIndex( "UserId" );

                entity.ToTable( "Account_UserLogins" );
            } );

            modelBuilder.Entity<IdentityUserRole<string>>( entity => {
                entity.Property( p => p.UserId );

                entity.Property( p => p.RoleId );

                entity.HasKey( "UserId", "RoleId" );

                entity.HasIndex( "RoleId" );

                entity.HasIndex( "UserId" );

                entity.ToTable( "Account_UserRoles" );
            } );

            modelBuilder.Entity<IdentityUserToken<string>>( entity => {
                entity.Property( p => p.UserId );

                entity.Property( p => p.LoginProvider );

                entity.Property( p => p.Name );

                entity.Property( p => p.Value );

                entity.HasKey( "UserId", "LoginProvider", "Name" );

                entity.ToTable( "Account_UserTokens" );
            } );

            modelBuilder.Entity( "Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", entity => {
                entity.HasOne( "Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole" )
                    .WithMany( "Claims" )
                    .HasForeignKey( "RoleId" )
                    .OnDelete( DeleteBehavior.Cascade );
            } );

            modelBuilder.Entity( "Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", entity => {
                entity.HasOne( "CoreWebWithEFCoreUserAccounts.Models.ApplicationUser" )
                    .WithMany( "Claims" )
                    .HasForeignKey( "UserId" )
                    .OnDelete( DeleteBehavior.Cascade );
            } );

            modelBuilder.Entity( "Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", entity => {
                entity.HasOne( "CoreWebWithEFCoreUserAccounts.Models.ApplicationUser" )
                    .WithMany( "Logins" )
                    .HasForeignKey( "UserId" )
                    .OnDelete( DeleteBehavior.Cascade );
            } );

            modelBuilder.Entity<IdentityUserRole<string>>( entity => {
                entity.HasOne<IdentityRole>()
                    .WithMany( "Users" )
                    .HasForeignKey( "RoleId" )
                    .OnDelete( DeleteBehavior.Cascade );

                entity.HasOne<ApplicationUser>()
                    .WithMany( "Roles" )
                    .HasForeignKey( "UserId" )
                    .OnDelete( DeleteBehavior.Cascade );
            } );
            modelBuilder.Entity<Section>( entity => {
                entity.Property( e => e.Id ).IsRequired();
                entity.Property( e => e.Name ).IsRequired();
                entity.Property( e => e.Description ).IsRequired();
                entity.Property( e => e.IsActive ).IsRequired();
            } );

            modelBuilder.Entity<Project>( entity => {
                entity.Property( e => e.Id ).IsRequired();
                entity.Property( e => e.Name ).IsRequired();
                entity.Property( e => e.Description ).IsRequired();
                entity.Property( e => e.ImageUrl ).IsRequired();
                entity.Property( e => e.Code ).IsRequired();
            } );
        }
        public virtual DbSet<Section> Section { get; set; }
        public virtual DbSet<Project> Project { get; set; }
    }
}