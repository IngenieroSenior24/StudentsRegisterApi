using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Inicialize.Entities;

public static class SubjectSeeder
{
    public static async Task InitializeAsync(PersistenceContext context)
    {
        if (context.Subjects.Any()) return;

        List<Subject> subjects = new List<Subject>
        {
            new("Mathematics"),
            new("Physics"),
            new("Chemistry"),
            new("Biology"),
            new("History"),
            new("Geography"),
            new("English"),
            new("Computer Science"),
            new("Physical Education"),
            new("Art")
        };

        List<Professor> professors = new List<Professor>
        {
            new Professor("Professor A"),
            new Professor("Professor B"),
            new Professor("Professor C"),
            new Professor("Professor D"),
            new Professor("Professor E")
        };

        context.AddRange(subjects);
        context.AddRange(professors);
        await context.SaveChangesAsync();

        // Asignar materias a profesores (2 materias por profesor)
        professors[0].AddSubject(subjects[0]); // Professor A -> Mathematics
        professors[0].AddSubject(subjects[1]); // Professor A -> Physics

        professors[1].AddSubject(subjects[2]); // Professor B -> Chemistry
        professors[1].AddSubject(subjects[3]); // Professor B -> Biology

        professors[2].AddSubject(subjects[4]); // Professor C -> History
        professors[2].AddSubject(subjects[5]); // Professor C -> Geography

        professors[3].AddSubject(subjects[6]); // Professor D -> English
        professors[3].AddSubject(subjects[7]); // Professor D -> Computer Science

        professors[4].AddSubject(subjects[8]); // Professor E -> Physical Education
        professors[4].AddSubject(subjects[9]); // Professor E -> Art

        await context.SaveChangesAsync();
    }
}