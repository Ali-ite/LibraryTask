using Abp.Application.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LibraryTask.StackOverFllowCalls
{
    public class StackOverFllowService : ApplicationService, IStackOverFllowService
    {
        
        private const string StackOverflowApiUrl = "https://api.stackexchange.com/2.3";
        private const string StackOverflowSite = "stackoverflow";
        public async Task<List<Question>> GetLatestQuestions()
        {
            try
            {
                var url = $"{StackOverflowApiUrl}/questions?order=desc&sort=activity&site={StackOverflowSite}&pagesize=50";
                var client = new HttpClient();
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();

               

                //  return
            }
            catch (Exception e) { }
        
            return new List<Question>();
          
        }
        public class QuestionList
        {
            public List<Question> Items { get; set; }
        }
    }
}
