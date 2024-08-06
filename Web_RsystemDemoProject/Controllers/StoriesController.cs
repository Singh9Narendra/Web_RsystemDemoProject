using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_RsystemDemoProject.Model;
using Web_RsystemDemoProject.Service;

namespace Web_RsystemDemoProject.Controllers
{
    [Route("api/Stories")]
    [ApiController]
    public class StoriesController : ControllerBase
    {
        private IStoriesService storiesService { get; set; }
        private ResponseDto? _response;
        public StoriesController(IStoriesService _storiesService)
        {
            this.storiesService = _storiesService;
          
            this._response = new ResponseDto();
        }


        [HttpGet]
        public ResponseDto Get()
        {
            try
            {

                IEnumerable<Stories> StoriesList = storiesService.GetStories();
                _response.Result = StoriesList;
                _response.IsSucess = true;

            }
            catch (Exception)
            {
                _response.IsSucess = false;
                _response.Message = "error Occured";
            }


            return _response;

        }



    }
}
