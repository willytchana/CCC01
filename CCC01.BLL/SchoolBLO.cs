using CCC01.BO;
using CCC01.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            if (school == null)
                throw new ArgumentNullException(nameof(school));
            var erros = validate(school);
            if (erros != null && erros.Count > 0)
                throw new TypingException(erros);
            repository.Add(school);
        }

        public IEnumerable<School> GetAllSchool()
        {
            return repository.Find();
        }

        private List<KeyValuePair<string, string>> validate(School school)
        {
            List<KeyValuePair<string, string>> erros = 
                new List<KeyValuePair<string, string>>();
            if (string.IsNullOrWhiteSpace(school.Email))
                erros.Add(new KeyValuePair<string, string>(nameof(school.Email), "Email cannot be null!"));
            if (!string.IsNullOrWhiteSpace(school.Email) && !new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*").IsMatch(school.Email))
                erros.Add(new KeyValuePair<string, string>(nameof(school.Email), "Invalid email address !"));

            return erros;
        }
    }
}
