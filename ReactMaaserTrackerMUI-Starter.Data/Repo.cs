using Microsoft.EntityFrameworkCore;

namespace ReactMaaserTrackerMUI_Starter.Data
{
    public class Repo
    {
        private readonly string _connectionString;
        public Repo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddIncome(Income inc)
        {
            var context = new DataContext(_connectionString);
            context.Income.Add(inc);
            context.SaveChanges();
        }
        public void AddMaaser(Maaser maaser)
        {
            var context = new DataContext(_connectionString);
            context.Maaser.Add(maaser);
            context.SaveChanges();
        }
        public void AddSource(Source source)
        {
            var context = new DataContext(_connectionString);
            context.Sources.Add(source);
            context.SaveChanges();
        }
        public void EditSource(Source source)
        {
            var context = new DataContext(_connectionString);
            context.Database.ExecuteSqlInterpolated($"UPDATE Sources SET Label = {source.Label} WHERE Id = {source.Id}");
        }
        public void DeleteSource(Source source)
        {
            var context = new DataContext(_connectionString);
            context.Sources.Remove(source);
            context.SaveChanges();
        }
        public List<Income> GetIncome()
        {
            var context = new DataContext(_connectionString);
            return context.Income.Include(i => i.Source).ToList();
        }
        public List<Maaser> GetMaaser()
        {
            var context = new DataContext(_connectionString);
            return context.Maaser.ToList();
        }
        public List<Source> GetSources()
        {
            var context = new DataContext(_connectionString);
            return context.Sources.ToList();
        }
        public List<Source> GetSourcesWithIncomes()
        {
            var context = new DataContext(_connectionString);
            return context.Sources.Include(s => s.Incomes).ToList();
        }
        public object GetOverview()
        {
            var context = new DataContext(_connectionString);
            var totalIncome = context.Income.Sum(i => i.Amount);
            var totalMaaser = context.Maaser.Sum(m => m.Amount);
            var totalObligation = totalIncome / 10;
            return new
            {
                TotalIncome = totalIncome,
                TotalMaaser = totalMaaser,
                TotalObligation = totalObligation,
                TotalStillObligated = totalObligation - totalMaaser
            };
                
        }
        public string GetLabelForIncome(int id)
        {
            var context = new DataContext(_connectionString);
            return context.Sources.FirstOrDefault(s => s.Id == id).Label;
        }
    }
}