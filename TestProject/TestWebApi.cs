using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_RsystemDemoProject.Service;
using Web_RsystemDemoProject.Model;
using Web_RsystemDemoProject.Controllers;
using Microsoft.Extensions.Caching.Memory;

namespace TestProject
{
    /// <summary>
    /// Test Web Api Class
    /// </summary>
    [TestClass]
    public class TestWebApi
    {


        /// <summary>
        /// check whether Stories controller and Stories Service working properly
        /// </summary>
        [TestMethod]
        public void TestStoriesController()
        {    
             var storiesRepository = new Mock<IStoriesService>();
            var memoryRepository = new Mock<IMemoryCache>();

            storiesRepository.Setup(x => x.GetStories("1")).ReturnsAsync(new Stories() { Id = 1, Url = "Newdemo.com", Title = "Newdemo" });
            var controller = new StoriesController(memoryRepository.Object, storiesRepository.Object);
            var getStories = controller.GetIndex(1,1);
            Assert.IsNotNull(getStories);    
        }



    }
}
