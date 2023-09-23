using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyRating
{
    public class DataBaseManager
    {
        private ApplicationContext ApplicationContext { get; }
        public DataBaseManager()
        {
            ApplicationContext = new ApplicationContext();
        }

        public async Task SaveRatingAsync(Monopolia.Player player, int tern)
        {
            Rating rat = new Rating(player.Name, player.Money, tern);
            using (var context = new ApplicationContext())
            {
                await context.Ratings.AddAsync(rat);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Rating>> LoadRatingsAsync()
        {
            using (var context = new ApplicationContext())
            {
                return await context.Ratings.ToListAsync();
            }
        }
        public void Close()
        {
            ApplicationContext.Database.CloseConnection();
            ApplicationContext.Dispose();
        }

    }
}
