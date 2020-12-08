using CCC01.BO;
using CCC01.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC01.BLL
{
    public class SchoolBLO
    {
        private readonly Repository<School> repository;
        public SchoolBLO()
        {
            repository = new Repository<School>("Data");
        }

        public void Save(School school)
        {
            repository.Add(school);
        }

        public IEnumerable<School> GetAllSchool()
        {
            return repository.Find();
        }
    }
}
