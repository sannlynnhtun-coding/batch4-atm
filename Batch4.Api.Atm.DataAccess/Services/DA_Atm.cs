﻿using Batch4.Api.Atm.DataAccess.Db;
using Batch4.Api.Atm.DataAccess.Models;

namespace Batch4.Api.Atm.DataAccess.Services
{
    //DataAccess

    public class DA_Atm
    {
        private readonly AppDbContext _context;

        public DA_Atm()
        {
            _context = new AppDbContext();
        }
    }
}