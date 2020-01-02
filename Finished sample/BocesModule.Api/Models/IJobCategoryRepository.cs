using System.Collections.Generic;
using BocesModule.Shared;

namespace BocesModule.Api.Models
{
    public interface IJobCategoryRepository
    {
        IEnumerable<JobCategory> GetAllJobCategories();
        JobCategory GetJobCategoryById(int jobCategoryId);
    }
}
