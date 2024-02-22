﻿using HRAppBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAppBackend.Application.Abstract.IRepositories
{
    public interface ILeaveRepository : IBaseRepository<Leave>
    {
        Task<List<Leave>> GetLeavesByUserIdAsync(string userId);
    }
}
