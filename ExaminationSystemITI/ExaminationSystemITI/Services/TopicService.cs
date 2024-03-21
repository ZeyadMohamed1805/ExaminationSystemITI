using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Database;
using ExaminationSystemITI.Models.Tables;
using ExaminationSystemITI.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ExaminationSystemITI.Services
{
    public class TopicService : ITopicService
    {
        ApplicationDbContext _context;
        public TopicService(ApplicationDbContext context)
        {
            _context = context;
        }
        public ICollection<Topic> GetTopics()
        {
            var topics = _context.Topics.FromSqlRaw("EXEC SelectAllTopics").ToList();
            
            foreach( var topic in topics )
            {
                topic.Course = _context.Courses.FromSql($"EXEC SelectCourseById {topic.CourseId}").ToList()[0];
            }

            return topics;
        }
        public ICollection<Topic> GetCourseTopics(int Id)
        {
            var topics = _context.Topics.FromSql($"EXEC SelectAllCourseTopics {Id}").ToList();
            return topics;
        }

        public Course GetTopicCourse(int Id)
        {
            var course = _context.Courses.FromSqlInterpolated($"select * from Courses where Id ={Id}").ToList()[0];
            return course;
        }
        public void DeleteTopic(int Id)
        {
            _context.Database.ExecuteSqlInterpolated($"EXEC DeleteTopicById {Id}");
        }

        public void EditTopic(Topic topic)
        {
            _context.Database.ExecuteSqlInterpolated($"EXEC EditTopicById {topic.Id},{topic.Name},{topic.CourseId}");
        }

        public void InsertTopic(Topic topic)
        {
            _context.Database.ExecuteSqlInterpolated($"EXEC InsertTopic {topic.Name},{topic.CourseId}");
        }

        public Topic? FindTopic(int Id)
        {
            var topic = _context.Topics.Find(Id);
            return topic;
        }

 
    }
}
