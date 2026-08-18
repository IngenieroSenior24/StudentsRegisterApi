using System.Linq.Expressions;
using Domain.Entities;
using Domain.Exceptions.Common;
using Domain.Ports;
using Domain.Services;

namespace Domain.Tests;

public class StudentServiceTests
{
    private readonly IGenericRepository<Student> _studentRepository;
    private readonly IGenericRepository<Subject> _subjectRepository;
    private readonly SubjectService _subjectService;
    private readonly StudentService _studentService;

    public StudentServiceTests()
    {
        _studentRepository = Substitute.For<IGenericRepository<Student>>();
        _subjectRepository = Substitute.For<IGenericRepository<Subject>>();
        _subjectService = new SubjectService(_subjectRepository);
        _studentService = new StudentService(_studentRepository, _subjectService);
    }

    [Fact]
    public async Task CreateAsync_ShouldAddStudent_WhenIdentificationIsUnique()
    {
        // Arrange
        Student student = new Student("John Doe", "12345");
        _studentRepository.Exist(Arg.Any<Expression<Func<Student, bool>>>()).Returns(false);

        // Act
        await _studentService.CreateAsync(student);

        // Assert
        await _studentRepository.Received(1).AddAsync(student);
    }

    [Fact]
    public async Task CreateAsync_ShouldThrowException_WhenIdentificationAlreadyExists()
    {
        // Arrange
        Student student = new Student("John Doe", "12345");
        _studentRepository.Exist(Arg.Any<Expression<Func<Student, bool>>>()).Returns(true);

        // Act & Assert
        await Assert.ThrowsAsync<ResourceAlreadyExistException>(() => _studentService.CreateAsync(student));
    }

    [Fact]
    public async Task GetStudentByIdentification_ShouldReturnStudent_WhenStudentExists()
    {
        // Arrange
        const string identification = "12345";
        Student student = new Student("John Doe", identification);
        _studentRepository.GetAsync(
            Arg.Any<Expression<Func<Student, bool>>>(),
            Arg.Any<Func<IQueryable<Student>, IOrderedQueryable<Student>>>(),
            false,
            Arg.Any<Expression<Func<Student, object>>>()
        ).Returns(new List<Student> { student });

        // Act
        Student result = await _studentService.GetStudentByIdentification(identification);

        // Assert
        Assert.Equal(student, result);
    }

    [Fact]
    public async Task GetStudentByIdentification_ShouldThrowException_WhenStudentDoesNotExist()
    {
        // Arrange
        const string identification = "12345";
        _studentRepository.GetAsync(
            Arg.Any<Expression<Func<Student, bool>>>(),
            Arg.Any<Func<IQueryable<Student>, IOrderedQueryable<Student>>>(),
            false,
            Arg.Any<Expression<Func<Student, object>>>()
        ).Returns(new List<Student>());

        // Act & Assert
        await Assert.ThrowsAsync<ResourceNotFoundException>(() => _studentService.GetStudentByIdentification(identification));

    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateStudentName_WhenStudentExists()
    {
        // Arrange
        const string identification = "12345";
        Student student = new Student("John Doe", identification);
        _studentRepository.GetAsync(
            Arg.Any<Expression<Func<Student, bool>>>(),
            Arg.Any<Func<IQueryable<Student>, IOrderedQueryable<Student>>>(),
            false,
            Arg.Any<Expression<Func<Student, object>>>()
        ).Returns(new List<Student> { student });

        // Act
        await _studentService.UpdateAsync(identification, "Jane Doe");

        // Assert
        Assert.Equal("Jane Doe", student.Name);
        await _studentRepository.Received(1).UpdateAsync(student);
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeleteStudent_WhenStudentExists()
    {
        // Arrange
        const string identification = "12345";
        Student student = new Student("John Doe", identification);
        _studentRepository.GetAsync(
            Arg.Any<Expression<Func<Student, bool>>>(),
            Arg.Any<Func<IQueryable<Student>, IOrderedQueryable<Student>>>(),
            false,
            Arg.Any<Expression<Func<Student, object>>>()
        ).Returns(new List<Student> { student });

        // Act
        await _studentService.DeleteAsync(identification);

        // Assert
        await _studentRepository.Received(1).DeleteAsync(student);
    }
}