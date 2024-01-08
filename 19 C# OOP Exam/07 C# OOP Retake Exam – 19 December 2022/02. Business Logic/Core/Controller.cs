using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {

        private SubjectRepository subjects;
        private StudentRepository students;
        private UniversityRepository universities;

        public Controller()
        {
            this.subjects = new SubjectRepository();
            this.students = new StudentRepository();
            this.universities = new UniversityRepository();
        }
        public string AddSubject(string subjectName, string subjectType)
        {
            int id = this.subjects.Models.Count + 1;
            ISubject subject;

            if (subjectType == nameof(EconomicalSubject))
            {
                subject = new EconomicalSubject(id, subjectName);
            }
            else if (subjectType == nameof(HumanitySubject))
            {
                subject = new HumanitySubject(id, subjectName);
            }
            else if (subjectType == nameof(TechnicalSubject))
            {
                subject = new TechnicalSubject(id, subjectName);
            }
            else
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }

            if (this.subjects.FindByName(subjectName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedSubject);
            }

            this.subjects.AddModel(subject);


            return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, this.subjects.GetType().Name);
        }
        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            var university = this.universities.FindByName(universityName);
            if (university != null)
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }
            int id = this.universities.Models.Count + 1;
            List<int> ints = new List<int>();
            foreach (var item in requiredSubjects)
            {
                ints.Add(this.subjects.FindByName(item).Id);
            }

            university = new University(id, universityName, category, capacity, ints);

            this.universities.AddModel(university);

            return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, this.universities.GetType().Name);
        }

        public string AddStudent(string firstName, string lastName)
        {
            string name = firstName + " " + lastName;

            var student = this.students.FindByName(name);

            if (student != null)
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }

            int id = this.students.Models.Count + 1;

            student = new Student(id, firstName, lastName);

            this.students.AddModel(student);
            return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, this.students.GetType().Name);
        }

        public string TakeExam(int studentId, int subjectId)
        {
            var student = this.students.FindById(studentId);

            if (student == null)
                return string.Format(OutputMessages.InvalidStudentId);

            var subgect = this.subjects.FindById(subjectId);

            if (subgect == null)
                return string.Format(OutputMessages.InvalidSubjectId);

            if (student.CoveredExams.Contains(subjectId))
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subgect.Name);

            student.CoverExam(subgect);
            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subgect.Name);
        }


        public string ApplyToUniversity(string studentName, string universityName)
        {
            var student = this.students.FindByName(studentName);

            if (student == null)
            {
                string[] nameStudent = studentName.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string firstName = nameStudent[0];
                string lastName = nameStudent[1];
                return string.Format(OutputMessages.StudentNotRegitered, firstName, lastName);
            }
            var university = this.universities.FindByName(universityName);

            if (university == null)
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);

            if (!RequiredExams(student.CoveredExams, university.RequiredSubjects))
            {
                return string.Format(OutputMessages.StudentHasToCoverExams, studentName,universityName);
            }

            if (student.University != null)
            {
                return string.Format(OutputMessages.StudentAlreadyJoined,student.FirstName,student.LastName,student.University.Name);
            }

            student.JoinUniversity(university);

            return string.Format(OutputMessages.StudentSuccessfullyJoined, student.FirstName,student.LastName,universityName);

        }


        public string UniversityReport(int universityId)
        {
            var university=this.universities.FindById(universityId);

            int studentsCount=this.students.Models.Where(x=>x.University==university).Count();
            int capacityLeft = university.Capacity - studentsCount;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"*** {university.Name} ***")
                .AppendLine($"Profile: {university.Category}")
                .AppendLine($"Students admitted: {studentsCount}")
                .AppendLine($"University vacancy: {capacityLeft}");

            return sb.ToString().TrimEnd();
        }
        private bool RequiredExams(IReadOnlyCollection<int> coveredExams, IReadOnlyCollection<int> requiredSubjects)
        {
            int reisred = requiredSubjects.Count;
            int count = 0;
            foreach (int i in requiredSubjects)
            {
                foreach (var item in coveredExams)
                {
                    if(i==item)
                        count++;
                }
            }

            if (count == reisred)
                return true;

            return false;
        }
    }
}
