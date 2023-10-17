using Microsoft.EntityFrameworkCore;
using PaintyTestTask.Data;
using PaintyTestTask.Entities;
using PaintyTestTask.Helpers;

namespace PaintyTestTask.API.Data
{
    public class DataDbInitializer
    {
        private readonly ApplicationDbContext _db;
        public DataDbInitializer(ApplicationDbContext db) {  _db = db; }
        public void Initialize() 
        {
            _db.Database.Migrate();
            if(_db.Users.Any()) { return; }
            var rnd = new Random();
            Parallel.ForEach(Enumerable.Range(1, 11), i =>
            {
                User user = new User
                {
                    Name = $"{Faker.Name.First()} " + $"{Faker.Name.Middle()} ",
                    Username = Faker.Name.First(),
                    Password = HashPasswordHelper.HashPassword(Faker.Phone.Number()),
                };
                _db.Users.Add(user);
            });
            _db.SaveChanges();

        }
           
    }
}
