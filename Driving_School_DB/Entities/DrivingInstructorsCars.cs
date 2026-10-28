using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driving_School_DB.Entities
{
    public class DrivingInstructorsCars
    {
        public int DrivingInstructorId { get; set; }
        public DrivingInstructor DrivingInstructor { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
