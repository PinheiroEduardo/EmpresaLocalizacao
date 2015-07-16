﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EmpresaLocalizacao.Models;

namespace EmpresaLocalizacao.Context
{
    public class EmpresaLocalizacaoContext : DbContext
    {
        public EmpresaLocalizacaoContext()
            :base("EmpresaLocalizacao")
        {
            
        }

        public DbSet<Empresa> Empresas { get; set; }
    }
}