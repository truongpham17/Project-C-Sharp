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
            this.Id = id;
            this.Name = name;
            this.year = year;
        }
        public DepartmentDTO(String id, String name)
        {
            this.Id = id;
            this.Name = name;
        }
        public DepartmentDTO() {

        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Year { get => year; set =>  year = value; }   
    }
}
