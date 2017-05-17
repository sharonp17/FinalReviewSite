namespace Wahoo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Wahoo.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<Wahoo.Models.WahooContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Wahoo.Models.WahooContext context)
        {
            context.Reviews.AddOrUpdate(x => x.ReviewId,
        new Models.Review() { ReviewId = 1, ReviewerName = "Pak Jun Key", ReviewDate = "4 / 17 / 2015", Comments = "Definitely a must see during the fall!", Rating = 3 , Mountain = "Jirisan"},
        new Models.Review() { ReviewId = 2, ReviewerName = "Borinji Wontay", ReviewDate = "12 / 4 / 2016", Comments = "If you go early enough you'll be able to stand amongst the clouds", Rating = 5, Mountain = "Seoraksan" },
        new Models.Review() { ReviewId = 3, ReviewerName = "Lee Jok Sun", ReviewDate = "1 / 28 / 15", Comments = "Over 20 different trails to choose from, you'll never get bored!", Rating = 4, Mountain = "Bukhansan" },
        new Models.Review() { ReviewId = 4, ReviewerName = "Nimfadora", ReviewDate = "2 / 13 / 14", Comments = "Not much of a challenge but absolutely stunning", Rating = 4, Mountain = "Hallasan" },
        new Models.Review() { ReviewId = 5, ReviewerName = "PUgsley", ReviewDate = "7 / 7 / 2016", Comments = "Not only is it the tallest Mountain in S.Korea but it's also the most beautiful!", Rating = 5, Mountain = "Songnisan" }
        );

            context.MountainCategories.AddOrUpdate(x => x.CategoryID,
   new Models.MountainCategory() { CategoryID = 1, TrailName = "Jirisan", TrailLocation = "South Gyeongsang Province", Elevation = "6,283 ft", ReviewId = 1 },
   new Models.MountainCategory() { CategoryID = 2, TrailName = "Seoraksan", TrailLocation = "Gangwon Province", Elevation = "5,604 ft", ReviewId = 2 },
   new Models.MountainCategory() { CategoryID = 3, TrailName = "Bukhansan", TrailLocation = "North Seoul Province", Elevation = "2,744 ft", ReviewId = 3 },
   new Models.MountainCategory() { CategoryID = 4, TrailName = "Songnisan", TrailLocation = "Chungcheongbuk-Do Province", Elevation = "3,472 ft", ReviewId = 4 },
   new Models.MountainCategory() { CategoryID = 5, TrailName = "Hallasan", TrailLocation = "Jeju Island", Elevation = "6,400 ft", ReviewId = 5 }
   );
        }
    }
}
