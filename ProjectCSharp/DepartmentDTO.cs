using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCSharp
{
    class DepartmentDTO
    {
        String id, name;
        int year;

        public DepartmentDTO(String id, String name, int year)
        {
            this.id = id;
            this.name = name;
            this.year = year;
        }
        public DepartmentDTO(String id, String name)
        {
            this.id = id;
            this.name = name;
        }
        public DepartmentDTO() {

        }
    }
}
