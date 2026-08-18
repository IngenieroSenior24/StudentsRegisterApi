using Domain.Entities;
using Domain.Exceptions.Common;
using Domain.Ports;

namespace Domain.Services;

[DomainService]
public class SubjectService
{
    private readonly IGenericRepository<Subject> _subjectRepository;

    public SubjectService(IGenericRepository<Subject> subjectRepository) =>
        _subjectRepository = subjectRepository;


    public async Task<Subject> GetSubjectById(Guid id)
    {
        Subject? subject = (await _subjectRepository.GetAsync(s =>
                s.Id == id,
            includeObjectProperties: f => f.ProfessorSubjects)).FirstOrDefault();
        _ = subject ??
            throw new ResourceNotFoundException(string.Format(Messages.ResourceNotFoundException, nameof(id), id));
        return subject;
    }

}