using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beverage.Repository.Models
{
    public class DynamicProperty
    {
        [Key]
        [Column(Order = 1)]
        public string Key { get; set; }
        public string SerializedValue { get; set; }

        public object Value
        {
            get
            {
                return JsonConvert.DeserializeObject(SerializedValue);
            }
            set
            {
                SerializedValue = JsonConvert.SerializeObject(value);
            }
        }

        [Key]
        [Column(Order = 2)]
        public int CarsId { get; set; }
        public virtual Car Car { get; set; }
    }
}
