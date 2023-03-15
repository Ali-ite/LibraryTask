using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryTask.StackOverFllowCalls
{
    public interface IStackOverFllowService
    {
        Task<List<Question>> GetLatestQuestions();
    }
}