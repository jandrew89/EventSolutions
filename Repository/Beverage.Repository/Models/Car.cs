using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beverage.Repository.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        public int Year { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public double Displacement { get; set; }

        public int Cylinders { get; set; }
        public int City { get; set; }
        public int Highway { get; set; }
        public int Combined { get; set; }
        public decimal Cost { get; set; }

        public virtual Customer Customer { get; set; }

        //OPEN TYPES
        private IDictionary<string, object> _properties;
        public IDictionary<string, object> Properties
        {
            get
            {
                if(_properties == null)
                {
                    _properties = new Dictionary<string, object>();
                    foreach (var dynamicProperty in DynamicCarProperties)
                    {
                        _properties.Add(dynamicProperty.Key, dynamicProperty.Value);
                    }
                }
                return _properties;
            }
            set
            {
                _properties = value;
            }
        }

        public ICollection<DynamicProperty> DynamicCarProperties { get; set; }

        public Car()
        {
            DynamicCarProperties = new List<DynamicProperty>();
        }
    }
}
