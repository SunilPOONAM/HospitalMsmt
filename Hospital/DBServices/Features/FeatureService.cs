using Hospital.Data;
using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.DBServices.Features
{
    public class FeatureService : IFeatureService
    {
        private HMSContext _context;
        public FeatureService(HMSContext context)
        {
            _context = context;
        }

        public async Task<AppFeatures> AddNewfeature(AppFeatures appFeatures)
        {
            _context.AppFeatures.Add(appFeatures);
            await _context.SaveChangesAsync();
            return appFeatures;
        }

        public async Task<AppFeatures> DeleteFeatureByID(int id)
        {
            var data = await _context.AppFeatures.FindAsync(id);
            if (data != null)
            {
                _context.Remove(data).CurrentValues.SetValues(id);
                await _context.SaveChangesAsync();
                return data;
            }
            return data;
        }

        public AppFeatures FeatureActivateDecativate(long Id, bool status)
        {
            AppFeatures feature = new AppFeatures();
            feature = _context.AppFeatures.FirstOrDefault(x => x.Id == Id);
            if (feature != null)
            {
                feature.IsActive = status;
                _context.SaveChanges();
            }
            return feature;
        }

        public IQueryable<AppFeatures> GetAllFeatures()
        {
            return from features in _context.AppFeatures select features;
        }

        public IQueryable<AppFeatures> GetFeatureDeatilByID(int Id)
        {
            return from features in _context.AppFeatures where features.Id == Id select features;
        }

        public async Task<AppFeatures> GetFeatureDeatilByID(AppFeatures model)
        {
          var data = await _context.AppFeatures.FindAsync(model.Id);
            if (data == null)
            {
                return null;
            }
            _context.Entry(data).CurrentValues.SetValues(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
