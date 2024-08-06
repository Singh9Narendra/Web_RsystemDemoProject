using Web_RsystemDemoProject.Model;

namespace Web_RsystemDemoProject.Service
{
    public interface IStoriesService
    {
        IEnumerable<Stories> GetStories();
        IEnumerable<Stories> GetStoriesById(int id);

    }
}
