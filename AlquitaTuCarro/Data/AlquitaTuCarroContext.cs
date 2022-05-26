using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AlquitaTuCarro.Models;
using AlquitaTuCarro.Entities;

namespace AlquitaTuCarro.Data
{
    public class AlquitaTuCarroContext : DbContext
    {
        public AlquitaTuCarroContext (DbContextOptions<AlquitaTuCarroContext> options)
            : base(options)
        {
        }

        public DbSet<AlquitaTuCarro.Models.FuelType>? FuelType { get; set; }

        public DbSet<AlquitaTuCarro.Models.CarInspection>? CarInspection { get; set; }

        public DbSet<AlquitaTuCarro.Models.CarRent>? CarRent { get; set; }

        public DbSet<AlquitaTuCarro.Models.Client>? Client { get; set; }

        public DbSet<AlquitaTuCarro.Models.Employee>? Employee { get; set; }

        public DbSet<AlquitaTuCarro.Models.Vehicle>? Vehicle { get; set; }

        public DbSet<AlquitaTuCarro.Models.VehicleBrand>? VehicleBrand { get; set; }

        public DbSet<AlquitaTuCarro.Models.VehicleType>? VehicleType { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
