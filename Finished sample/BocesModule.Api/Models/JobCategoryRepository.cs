﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BocesModule.Shared;

namespace BocesModule.Api.Models
{
    public class JobCategoryRepository: IJobCategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public JobCategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<JobCategory> GetAllJobCategories()
        {
            // return _appDbContext.JobCategories;
            return new List<JobCategory>();
        }

        public JobCategory GetJobCategoryById(int jobCategoryId)
        {
            // return _appDbContext.JobCategories.FirstOrDefault(c => c.JobCategoryId == jobCategoryId);
            return new JobCategory();
        }
    }
}
