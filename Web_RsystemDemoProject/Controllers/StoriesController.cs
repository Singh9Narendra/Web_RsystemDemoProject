using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Web_RsystemDemoProject.Model;
using Web_RsystemDemoProject.Service;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Web_RsystemDemoProject.Controllers
{
    [Route("api/Stories")]
    [ApiController]
    public class StoriesController : ControllerBase
    {

        private IMemoryCache _cache;       
        private IStoriesService storiesService { get; set; }
        private ResponseDto? _response;

        /// <summary>
        /// Intialize  IMemoryCache and  IStoriesService Instance
        /// </summary>
        /// <param name="cache">IMemoryCache Object</param>
        /// <param name="_storiesService">IStoriesService Object</param>
        public StoriesController(IMemoryCache cache, IStoriesService _storiesService)
        {
            this.storiesService = _storiesService;
            this._cache = cache;
            this._response = new ResponseDto();
        }

        /// <summary>
        /// Get data from stories service (async call)
        /// </summary>
        /// <param name="storyId">take Stories Id and Return based on that id</param>
        /// <returns>Stories Object</returns>
        private async Task<Stories> GetStories(string storyId)
        {
            return await _cache.GetOrCreateAsync<Stories>(storyId,
                async cacheEntry =>
                {
                    var story = await storiesService.GetStories(storyId);

                    return story;
                });
        }


        /// <summary>
        /// Get Stories based on search query 
        /// </summary>
        /// <param name="query">Search Query for stories</param>
        /// <param name="pageIndex">Current page no</param>
        /// <param name="pageSize">Page size Required</param>
        /// <returns>Paginated list of Stories </returns>
        [HttpGet("Get")]
        public async Task<PaginatedList<Stories>> Get(string query, int pageIndex, int pageSize)
        {
            List<Stories>? stories = new List<Stories>();

            var storiesIdList = await storiesService.GetStoriesIdList();
            if (storiesIdList != null)
            {

                var tasks = storiesIdList.Select(GetStories);
                stories = (await Task.WhenAll(tasks))
            .ToList(); 
                if (!String.IsNullOrEmpty(query))
                {
                    stories = stories.Where(s =>
                                       s.Title.ToLower().IndexOf(query.ToLower()) > -1 ).ToList()
                                       ; 
                }
            }

            var count = stories.Count();
            var totalPages = (int)Math.Ceiling(count / (double)pageSize);

            return new PaginatedList<Stories>(stories.OrderBy(b => b.Id)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToList(), pageIndex, totalPages);
        }



        /// <summary>
        /// Get Stories 
        /// </summary>
        /// <param name="pageIndex">Current page no</param>
        /// <param name="pageSize">Page size Required</param>
        /// <returns>Paginated list of Stories </returns>
        [HttpGet("GetIndex")]
        public async Task<PaginatedList<Stories>> GetIndex(int pageIndex, int pageSize)
        {
            List<Stories>? stories = new List<Stories>();

            var storiesIdList = await storiesService.GetStoriesIdList();
            if (storiesIdList != null)
            {

                var tasks = storiesIdList.Select(GetStories);
                stories = (await Task.WhenAll(tasks))
            .ToList();
            }        

            var count =  stories.Count();
            var totalPages = (int)Math.Ceiling(count / (double)pageSize);
     
            return new PaginatedList<Stories>(stories.OrderBy(b => b.Id)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize).ToList(), pageIndex, totalPages);
        }

    }
}
