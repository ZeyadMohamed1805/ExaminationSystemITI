using ExaminationSystemITI.Abstractions.Interfaces;
using ExaminationSystemITI.Models.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystemITI.Controllers
{
    public class TopicController : Controller
    {
        ITopicService _topic;
        public TopicController(ITopicService topic)
        {
            _topic = topic;
        }
        public IActionResult Index()
        {
            ICollection<Topic> topics = _topic.GetTopics();
            return View(topics);
        }

        [HttpGet]
        public IActionResult AddTopic()
        {
            return View("Add");
        }

        [HttpPost]
        public IActionResult AddTopic(Topic topic)
        {
            _topic.InsertTopic(topic);
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Topic topic)
        {
            _topic.DeleteTopic(topic.Id);
            return RedirectToAction("Index");
        }
    }
}
