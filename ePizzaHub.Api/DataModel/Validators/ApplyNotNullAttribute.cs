using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataModel.Validators
{
    public class ApplyNotNullAttribute : ValidationAttribute
    {

        public ApplyNotNullAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            if (value is IEnumerable<object> list)
            {
                if (list.Count() <=0 )
                {
                    return false;
                }
            }
            else
            {
                if(value == null)
                    return false;
            }

            return true;
        }
    }
}
