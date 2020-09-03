using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Models
{
    public interface IPropertyRepository
    {
        IEnumerable<Property> GetAll();
        void Add(Property propertyToAdd);

        Property GetProperty(int id);

        void Update(Property propertyToUpdate);
    }
}
