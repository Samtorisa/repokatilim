using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ToDO.Models;

namespace ToDO.Data;

public partial class StajyertestContext : DbContext
{
    public StajyertestContext()
    {
    }

    public StajyertestContext(DbContextOptions<StajyertestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ToDo> ToDos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=SQLTSTSRV02\\SQLGNLTST;Database=STAJYERTEST;User Id=stajyerdbuser;Password=NEBZ*x7wsjmAGp;TrustServerCertificate=True");
    



}
