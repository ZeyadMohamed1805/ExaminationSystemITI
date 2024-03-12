﻿using ExaminationSystemITI.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystemITI.Abstractions.Interfaces
{
    public interface ITopicService
    {
        public ICollection<Topic> GetTopics();
        public void DeleteTopic(int Id);
        public void EditTopic(Topic topic);
        public void InsertTopic(Topic topic);
        public Topic? FindTopic(int Id);
    }
}
