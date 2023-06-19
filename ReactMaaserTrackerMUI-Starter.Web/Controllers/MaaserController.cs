using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactMaaserTrackerMUI_Starter.Data;
using ReactMaaserTrackerMUI_Starter.Web.Models;

namespace ReactMaaserTrackerMUI_Starter.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaaserController : ControllerBase
    {
        private readonly string _connectionString;
        public MaaserController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }
        [Route("getIncome")]
        [HttpGet]
        public List<IncomeWithLabel> GetIncome()
        {
            var repo = new Repo(_connectionString);
            var incomes = repo.GetIncome();
            return incomes.Select(income => new IncomeWithLabel
            {
                Income = income,
                Label = repo.GetLabelForIncome(income.SourceId)
            }).ToList();

        }
        [Route("getMaaser")]
        [HttpGet]
        public List<Maaser> GetMaaser()
        {
            var repo = new Repo(_connectionString);
            return repo.GetMaaser();
        }
        [Route("getSources")]
        [HttpGet]
        public List<Source> GetSources()
        {
            var repo = new Repo(_connectionString);
            return repo.GetSources();
        }
        [Route("getSourceswithincomes")]
        [HttpGet]
        public List<Source> GetSourcesWithIncomes()
        {
            var repo = new Repo(_connectionString);
            return repo.GetSourcesWithIncomes();
        }
        [Route("getOverview")]
        [HttpGet]
        public Object GetOverview()
        {
            var repo = new Repo(_connectionString);
            return repo.GetOverview();
        }
        [Route("Delete")]
        [HttpPost]
        public void Delete(Source source)
        {
            var repo = new Repo(_connectionString);
            repo.DeleteSource(source);
        }
        [Route("Edit")]
        [HttpPost]
        public void Edit(Source source)
        {
            var repo = new Repo(_connectionString);
            repo.EditSource(source);
        }
        [Route("AddIncome")]
        [HttpPost]
        public void AddIncome(Income income)
        {
            var repo = new Repo(_connectionString);
            repo.AddIncome(income);
        }
        [Route("AddMaaser")]
        [HttpPost]
        public void AddMaaser(Maaser maaser)
        {
            var repo = new Repo(_connectionString);
            repo.AddMaaser(maaser);
        }
        [Route("AddSource")]
        [HttpPost]
        public void AddSource(Source source)
        {
            var repo = new Repo(_connectionString);
            repo.AddSource(source);
        }
    }
}
