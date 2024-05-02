using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ToDO.Models;
using Microsoft.Extensions.Configuration;
using System.Configuration;

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
    {


        IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json")
           .Build();

        optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyDbConnection"));
    }



}
