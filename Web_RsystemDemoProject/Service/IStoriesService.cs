using Web_RsystemDemoProject.Model;

namespace Web_RsystemDemoProject.Service
{
    public interface IStoriesService
    {
        Task<Stories> GetStories(string id);
        Task<IEnumerable<string>> GetStoriesIdList();

    }
}
