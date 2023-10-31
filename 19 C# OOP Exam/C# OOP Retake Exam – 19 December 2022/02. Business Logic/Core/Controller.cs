using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {

       

        SubjectRepository subjects;
        StudentRepository students;
        UniversityRepository universities;
        public Controller()
        {
            this.subjects = new SubjectRepository();
            this.students = new StudentRepository();
            this.universities = new UniversityRepository();
        }
        public string AddSubject(string subjectName, string subjectType)
        {
            if (subjectType != nameof(TechnicalSubject) && subjectType != nameof(HumanitySubject) && subjectType != nameof(EconomicalSubject))
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }
            ISubject subject = this.subjects.FindByName(subjectName);
            if (subject != null)
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectType);
            }
            int id = this.subjects.Models.Count + 1;
            if (subjectType == nameof(TechnicalSubject))
            {
                subject = new TechnicalSubject(id, subjectName);
            }
            else if (subjectType == nameof(HumanitySubject))
            {
                subject = new HumanitySubject(id, subjectName);
            }
            else if (subjectType == nameof(EconomicalSubject))
            {
                subject = new EconomicalSubject(id, subjectName);
            }

            this.subjects.AddModel(subject);
            return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, this.subjects.GetType().Name);
        }
        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            IUniversity university = this.universities.FindByName(universityName);
            if (university != null)
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }
            int id = this.universities.Models.Count + 1;
            List<int> ints = new List<int>();
            foreach (var item in requiredSubjects)
            {
                int idS = this.subjects.FindByName(item).Id;
                ints.Add(idS);
            }

            university = new University(id, universityName, category, capacity, ints);

            this.universities.AddModel(university);

            return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, this.universities.GetType().Name);
        }

        public string AddStudent(string firstName, string lastName)
        {
            string sutudentName = $"{firstName} {lastName}";
            IStudent student = this.students.FindByName(sutudentName);
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
            IStudent student = this.students.FindById(studentId);
            if (student == null)
            {
                return string.Format(OutputMessages.InvalidStudentId);
            }
            ISubject subject = this.subjects.FindById(subjectId);
            if (subject == null)
            {
                return string.Format(OutputMessages.InvalidSubjectId);
            }
            if (student.CoveredExams.Any(i => i == subjectId))
            {
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam
                    , student.FirstName, student.LastName, subject.Name);
            }

            student.CoverExam(subject);
            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam
                , student.FirstName, student.LastName, subject.Name);
        }


        public string ApplyToUniversity(string studentName, string universityName)
        {


            IStudent student = this.students.FindByName(studentName);
            var name = studentName.Split().ToArray();
            if (student == null)
            {
                return string.Format(OutputMessages.StudentNotRegitered, name[0], name[1]);
            }
            IUniversity university = this.universities.FindByName(universityName);
            if (university == null)
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }
            int count = 0;
            foreach (var exam in student.CoveredExams)
            {
                if (university.RequiredSubjects.Any(e => e == exam))
                {
                    count++;
                }
            }
            if(count !=university.RequiredSubjects.Count)
            {
                return string.Format(OutputMessages.StudentHasToCoverExams,studentName,universityName);
            }

            if(student.University!=null)
            {
                return string.Format(OutputMessages.StudentAlreadyJoined,student.FirstName,student.LastName,student.University.Name);
            }

            student.JoinUniversity(university);

            return string.Format(OutputMessages.StudentSuccessfullyJoined, student.FirstName, student.LastName, universityName);
        }


        public string UniversityReport(int universityId)
        {
           var university=this.universities.FindById(universityId);

            int studentsCount = this.students.Models.Where(s=>s.University==university).Count();

            StringBuilder sb=new StringBuilder();
            sb.AppendLine($"*** {university.Name} ***")
                .AppendLine($"Profile: {university.Category}")
                .AppendLine($"Students admitted: {studentsCount}")
                .AppendLine($"University vacancy: {university.Capacity-studentsCount}");

            return sb.ToString().TrimEnd();
        }
    }
}
