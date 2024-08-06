using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Web_RsystemDemoProject.Data;
using Web_RsystemDemoProject.Model;

namespace Web_RsystemDemoProject.Service
{
    public class StoriesService : IStoriesService
    {
        private DataBaseContext DbContext { get; set; }
        public StoriesService(DataBaseContext _db)
        {
            this.DbContext = _db;
     
        }
        public IEnumerable<Stories> GetStories()
        {
           IEnumerable < Stories > StoriesList = DbContext.Stories.ToList();
            return StoriesList;
        }

        public IEnumerable<Stories> GetStoriesById(int id)
        {
            IEnumerable<Stories> StoriesList = DbContext.Stories.Where(q=>q.StoriesId==id).ToList();
            return StoriesList;
        }
    }
}
