using Application.UseCases.Students.Queries.GetStudentsBySubjectIdAndIdentification;
using Application.UseCases.Subjects.Queries.GetAllSubject;
using Application.UseCases.Subjects.Queries.GetSubjectsByIdentification;
using Domain.Entities;
using Mapster;
using ProfessorDto = Application.UseCases.Subjects.Queries.GetAllSubject.ProfessorDto;

namespace Application;

public class MapsterSettings
{
    public static void Configure()
    {
        TypeAdapterConfig.GlobalSettings.Default.NameMatchingStrategy(NameMatchingStrategy.Flexible);
        TypeAdapterConfig<Subject, GetAllSubjectDto>.NewConfig()
            .Map(dest => dest.Professor, src => src.ProfessorSubjects.First().Professor.Adapt<ProfessorDto>());
        
        TypeAdapterConfig<StudentSubject, GetSubjectByIdentificationDto>.NewConfig()
            .Map(dest => dest.Id, src => src.Subject.Id)
            .Map(dest => dest.Name, src => src.Subject.Name)
            .Map(dest => dest.Professor, src => src.Professor.Adapt<ProfessorDto>());

        TypeAdapterConfig<StudentSubject, GetStudentsBySubjectIdAndIndentificationDto>.NewConfig()
            .Map(dest => dest.Name, src => src.Student.Name);
        
        TypeAdapterConfig<Professor, ProfessorDto>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name);
        
        TypeAdapterConfig<Professor, GetSubjectByIdentificationProfessorDto>.NewConfig()
            .Map(dest => dest.Name, src => src.Name);
    }
}