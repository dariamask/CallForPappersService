﻿using CallForPappersService.Data;
using CallForPappersService.Interfaces;
using CallForPappersService.Models;
using Microsoft.EntityFrameworkCore;

namespace CallForPappersService.Repository
{
    public class ActivityTypeRepository : IActivityTypeRepository
    {
        private readonly DataContext _context;
        public ActivityTypeRepository (DataContext context)
        {
            _context = context;
        }
        public ICollection<ActivityTypeModel> Activities()
        {
            throw new NotImplementedException();
        }
    }
}
