using RealEstate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Models
{
    public class PropertyRepository : IPropertyRepository
    {
        public readonly RealEstateContext _realEstateContext;
        public PropertyRepository(RealEstateContext realEstateContext)
        {
            _realEstateContext = realEstateContext;
        }

        public void Add(Property propertyToAdd)
        {
            _realEstateContext.Properties.Add(propertyToAdd);
            _realEstateContext.SaveChanges();
        }

        public IEnumerable<Property> GetAll()
        {
           var properties = _realEstateContext.Properties.ToList();
            return properties;
        }

        public Property GetProperty(int id)
        {
            var property = _realEstateContext.Properties.Where(p => p.Id == id).FirstOrDefault();
            return property;
        }

        public void Update(Property propertyToUpdate)
        {
            _realEstateContext.Properties.Update(propertyToUpdate);
            _realEstateContext.SaveChanges();
        }
    }
}
