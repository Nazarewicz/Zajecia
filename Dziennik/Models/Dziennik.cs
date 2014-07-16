using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.ComponentModel.DataAnnotations;

namespace AppDziennik.Models
{
   // public class Dziennik
   // {
        public class Uczen
        {
            [Key]
            public int Id_u { set; get; }
            public string Imie { set; get; }
            public string Nazwisko { set; get; }
            public int Wiek { set; get; }
            public int Klasa { set; get; }
            public ICollection<Ocena> Oceny { set; get; }

        }
        public class UczenDataContext : DbContext
        {
            public DbSet<Uczen> Uczniowie { set; get; }
        }

        public class Ocena
        {
            [Key]
            public int Id_o { set; get; }
            public int Id_u { set; get; }
            public int Wartosc { set; get; }
            public Uczen Uczen { set; get; }
        }

        public class OcenaDataContext : DbContext
        {
            public DbSet<Ocena> Oceny { set; get; }
        }

        public class DBDziennik : DbContext
        {
            public DbSet<Uczen> Uczniowie { set; get; }
            public DbSet<Ocena> Oceny { set; get; }
        }

   // }
}