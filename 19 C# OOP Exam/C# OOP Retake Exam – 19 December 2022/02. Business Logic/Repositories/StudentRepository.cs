using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    internal class StudentRepository : IRepository<IStudent>
    {
        private List<IStudent> students;

        public StudentRepository()
        {
            this.students = new List<IStudent>();
        }
        public IReadOnlyCollection<IStudent> Models => this.students.AsReadOnly();

        public void AddModel(IStudent model)
        {
            this.students.Add(model);
        }

        public IStudent FindById(int id)
        {
           return Models.FirstOrDefault(s=>s.Id==id);   
        }

        public IStudent FindByName(string name)
        {
            var studentName=name.Split().ToArray();
            string firstName = studentName[0];
            string lastName = studentName[1];
            return Models.FirstOrDefault(s=>s.FirstName==firstName && s.LastName==lastName);
        }
    }
}
