using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_RsystemDemoProject.Service;
using Web_RsystemDemoProject.Model;
using Web_RsystemDemoProject.Controllers;

namespace TestProject
{
    [TestClass]
    public class TestWebApi
    {

        [TestMethod]
        public void TestGetStories()
        {
            var list = new List<Stories>()
            {
                new Stories() { StoriesId=1,Url="Newdemo.com",Title="Newdemo"},
                 new Stories() { StoriesId=2,Url="Newdemo.com",Title="Newdemo"}
            };
          

            var storiesRepository = new Mock<IStoriesService>();
            storiesRepository.Setup(x => x.GetStories()).Returns(list);
            var controller = new StoriesController(storiesRepository.Object);
            var getStories = controller.Get();
            Assert.IsNotNull(getStories);
      

        }

        
    }
}
