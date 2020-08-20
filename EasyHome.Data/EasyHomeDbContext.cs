using EasyHome.Shared;
using EasyHome.Shared.MSF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyHome.Data
{
    public class EasyHomeDbContext : DbContext
    {
        public EasyHomeDbContext(DbContextOptions<EasyHomeDbContext> options) : base(options)
        {

        }

        public DbSet<MSFCharacter> MSFCharacters { get; set; }
        public DbSet<MSFCharacterOrganization> MSFCharacterOrganization { get; set; }
        public DbSet<MSFCharacterExtra> MSFCharacterExtra { get; set; }
        public DbSet<MSFTeam> MSFTeam { get; set; }
        public DbSet<FUTPlayer> FUTPlayer { get; set; }
    }
}
