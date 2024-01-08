using System;
using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class University : IUniversity
    {
        private int universityId;
        private string universityName;
        private string category;
        private int capacity;
        private List<int> requiredSubjects;
        public University(int universityId, string universityName, string category, int capacity, ICollection<int> requiredSubjects)
        {
            this.Id = universityId;
            this.Name = universityName;
            this.Category = category;
            this.Capacity=capacity;
            this.requiredSubjects=requiredSubjects.ToList();
        }
        public int Id { get => universityId;private set => universityId = value; }

        public string Name
        {
            get=>universityName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.NameNullOrWhitespace));

                universityName = value;
            }
        }

        public string Category
        {
            get=>category;
            private set
            {
              

                if(value!= "Technical"&&value!= "Economical"&&value!= "Humanity")
                    throw new ArgumentException(string.Format(ExceptionMessages.CategoryNotAllowed, value));

                category = value;
            }
        }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if(value<0)
                    throw new ArgumentException(string.Format(ExceptionMessages.CapacityNegative));

                capacity = value;
            }
        }

        public IReadOnlyCollection<int> RequiredSubjects => this.requiredSubjects.AsReadOnly();
    }
}
