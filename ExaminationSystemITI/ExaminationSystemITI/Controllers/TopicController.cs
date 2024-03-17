using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Models.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystemITI.Controllers
{
    public class TopicController : Controller
    {
        ITopicService _topic;
        ICourseService _course;
        public TopicController(ITopicService topic,ICourseService courseService)
        {
            _topic = topic;
            _course = courseService;
        }
     
        public IActionResult Read()
        {
            ICollection<Topic> topics = _topic.GetTopics();
            return View(topics);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.courses=_course.GetCourses();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Topic topic)
        {
            _topic.InsertTopic(topic);
            return RedirectToAction("Read");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var topic = _topic.FindTopic(Id);
            return View(topic);
        }

        [HttpPost]
        public IActionResult Edit(Topic topic)
        {
            _topic.EditTopic(topic);
            return RedirectToAction("Read");
        }

    
        public IActionResult Delete(int id)
        {
            _topic.DeleteTopic(id);
            return RedirectToAction("Read");
        }
    }
}
