using UniversityAPI.DTOs.Marks;
using UniversityAPI.Models;
using UniversityAPI.Repositories.course_Repository;
using UniversityAPI.Repositories.mark_Repository;

namespace UniversityAPI.Services.mark_service
{
    public class MarkService : IMarkService
    {
        private readonly IMarkRepository _markRepo;
        private readonly ICourseRepository _courseRepo;
        public MarkService(IMarkRepository markRepo, ICourseRepository courseRepo)
        {
            _markRepo = markRepo;
            _courseRepo = courseRepo;
        }
        public async Task<(bool flag,string message)> SetMarkByTeacher(CreateMarkDTOs dto)
        {
            var teacherAssigned = await _courseRepo
                .IsTeacherAssignedToCourseAsync(dto.CourseId,dto.TeacherId); 
            if (teacherAssigned == false)
            {
                return (false , "Teacher is not assigned to course.");
            }

            var studentEnroll = await _courseRepo
                .IsStudentEnrollToCourseAsync(dto.CourseId, dto.StudentId);
            if (studentEnroll == false)
            {
                return (false, "Student is not enroll to this course.");
            }
            var mark = new Mark()
            {
                CourseId = dto.CourseId,
                StudentId = dto.StudentId,
                TeacherId = dto.TeacherId,
                Mid = dto.Mid,
                Final = dto.Final,
                Assignment = dto.Assignment,
                Quiz = dto.Quiz,
                Project = dto.Project,
            };
            await _markRepo.AddAsync(mark);
            return (true, "Mark Added Successfully.");
        }

        public async Task<List<MarkResponseDTOs>> GetMarksOfStudentAsync(int studentId)
        {
            var marks = await _markRepo.GetStudentById(studentId);
            return marks.Select(m => new MarkResponseDTOs()
            {
                Score = m.Mid + m.Quiz + m.Assignment + m.Project + m.Final
            }).ToList();
        }
    }
}
