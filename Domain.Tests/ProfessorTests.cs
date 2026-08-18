using Domain.Entities;
using Domain.Tests.Builders;

namespace Domain.Tests;

using System;
using Xunit;
using System.Collections.Generic;

public class ProfessorTests
{
    [Fact]
    public void AddSubject_ShouldAddSubject_WhenLessThanMaxSubjects()
    {
        // Arrange
        Subject subject = new SubjectBuilder().Build();
        Professor professor = new ProfessorBuilder().Build();

        // Act
        professor.AddSubject(subject);

        // Assert
        Assert.Single(professor.ProfessorSubjects);
    }

    [Fact]
    public void AddSubject_ShouldThrowException_WhenMaxSubjectsReached()
    {
        // Arrange
        Subject subject1 = new SubjectBuilder().WithName("Subject 1").Build();
        Subject subject2 = new SubjectBuilder().WithName("Subject 2").Build();
        Subject subject3 = new SubjectBuilder().WithName("Subject 3").Build();
        Professor professor = new ProfessorBuilder()
            .WithSubjects(new List<ProfessorSubject>
            {
                new(Guid.NewGuid(), subject1.Id),
                new(Guid.NewGuid(), subject2.Id)
            })
            .Build();

        // Act & Assert
        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => professor.AddSubject(subject3));
        Assert.Equal("Un profesor no puede dictar más de 2 materias.", exception.Message);
    }
}
