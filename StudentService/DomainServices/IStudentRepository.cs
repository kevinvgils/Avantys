﻿using StudentService.Domain;

namespace DomainServices
{
    public interface IStudentRepository
    {
        Student GetStudent();

        Task AddStudent(Student student);
    }
}