using Hospital.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.DBServices.Features
{
    public interface IFeatureService
    {
        IQueryable<AppFeatures> GetAllFeatures();
        Task<AppFeatures> AddNewfeature(AppFeatures appFeatures);
        AppFeatures FeatureActivateDecativate(long Id,bool status);
        IQueryable<AppFeatures> GetFeatureDeatilByID(int Id);
        Task<AppFeatures> GetFeatureDeatilByID(AppFeatures model);
        Task<AppFeatures> DeleteFeatureByID(int id);
    }
}
