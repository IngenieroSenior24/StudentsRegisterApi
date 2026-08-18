using Domain.Entities;
using Domain.Tests.Builders;

namespace Domain.Tests;

using System;
using Xunit;
using System.Collections.Generic;

public class StudentTests
{
    [Fact]
    public void UpdateName_ShouldChangeName()
    {
        // Arrange
        Student student = new StudentBuilder().WithName("Old Name").Build();

        // Act
        student.UpdateName("New Name");

        // Assert
        Assert.Equal("New Name", student.Name);
    }

    [Fact]
    public void AddSubject_ShouldAddSubject_WhenLessThanMaxSubjects()
    {
        // Arrange
        Guid subjectId = Guid.NewGuid();
        Guid professorId = Guid.NewGuid();
        Student student = new StudentBuilder().Build();

        // Act
        student.AddSubject(subjectId, professorId);

        // Assert
        Assert.Single(student.StudentSubjects);
    }

    [Fact]
    public void AddSubject_ShouldThrowException_WhenMaxSubjectsReached()
    {
        // Arrange
        StudentSubject subject1 = new (Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());
        StudentSubject subject2 = new (Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());
        StudentSubject subject3 = new (Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());
        StudentSubject subject4 = new (Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());
        Student student = new StudentBuilder()
            .WithSubjects(new List<StudentSubject> { subject1, subject2, subject3 })
            .Build();

        // Act & Assert
        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => student.AddSubject(subject4.SubjectId, subject4.ProfessorId));
        Assert.Equal("El estudiante no puede inscribirse en más de 3 materias.", exception.Message);
    }

    [Fact]
    public void AddSubject_ShouldThrowException_WhenSubjectAlreadyAdded()
    {
        // Arrange
        Guid subjectId = Guid.NewGuid();
        Guid professorId = Guid.NewGuid();
        Student student = new StudentBuilder()
            .WithSubjects(new List<StudentSubject> { new StudentSubject(Guid.NewGuid(), subjectId, professorId) })
            .Build();

        // Act & Assert
        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => student.AddSubject(subjectId, Guid.NewGuid()));
        Assert.Equal("El estudiante no puede tener registrado la misma materia", exception.Message);
    }

    [Fact]
    public void AddSubject_ShouldThrowException_WhenSameProfessorAlreadyAdded()
    {
        // Arrange
        Guid subjectId1 = Guid.NewGuid();
        Guid subjectId2 = Guid.NewGuid();
        Guid professorId = Guid.NewGuid();
        Student student = new StudentBuilder()
            .WithSubjects(new List<StudentSubject> { new StudentSubject(Guid.NewGuid(), subjectId1, professorId) })
            .Build();

        // Act & Assert
        InvalidOperationException? exception = Assert.Throws<InvalidOperationException>(() => student.AddSubject(subjectId2, professorId));
        Assert.Equal("El estudiante no puede tener más de una clase con el mismo profesor.", exception.Message);
    }
}
