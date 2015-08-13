using ClassicJaguars.Data.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity.Migrations; //used for AddOrUpdate()
using System.Linq;

namespace ClassicJaguars.Data.Migrations
{
    public static class Seeder
    {
        //UserIDs
        public static string Admin1 { get; set; }

        public static string Admin2 { get; set; }

        public static string Usr1 { get; set; }

        public static void Seed(ApplicationDbContext db,
            bool roles = true,
            bool users = true,
            bool cars = true,
            bool transactions = true)
        {
            if (roles) SeedRoles(db);
            if (users) SeedUsers(db);
            if (cars) SeedCars(db);
            if (transactions) SeedTransactions(db);

            //after users are seeded, store the IDs in a variable
            Admin1 = db.Users.FirstOrDefault(x => x.UserName == "giovanni.rosati@gmail.com").Id;
            Admin2 = db.Users.FirstOrDefault(x => x.UserName == "jjp7@earthlink.net").Id;
            Usr1 = db.Users.FirstOrDefault(x => x.UserName == "user1@test.com").Id;
        }

        public static void SeedRoles(ApplicationDbContext db)
        {
            var store = new RoleStore<IdentityRole>(db);
            var manager = new RoleManager<IdentityRole>(store);

            if (!manager.RoleExists(Roles.USER))
            {
                manager.Create(new IdentityRole() { Name = Roles.USER });
            }
            if (!manager.RoleExists(Roles.ADMIN))
            {
                manager.Create(new IdentityRole() { Name = Roles.ADMIN });
            }
        }

        private static void SeedUsers(ApplicationDbContext db)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            if (!db.Users.Any(x => x.UserName == "giovanni.rosati@gmail.com"))
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = "giovanni.rosati@gmail.com",
                    UserName = "giovanni.rosati@gmail.com",
                    EmailConfirmed = true
                };
                manager.Create(user, "Abcd1234!");
                manager.AddToRole(user.Id, Roles.ADMIN);
            }

            if (!db.Users.Any(x => x.UserName == "jjp7@earthlink.net"))
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = "jjp7@earthlink.net",
                    UserName = "jjp7@earthlink.net",
                    EmailConfirmed = true
                };
                manager.Create(user, "Abcd1234!");
                manager.AddToRole(user.Id, Roles.ADMIN);
            }

            if (!db.Users.Any(x => x.UserName == "user1@test.com"))
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = "user1@test.com",
                    UserName = "user1@test.com",
                    EmailConfirmed = true
                };
                manager.Create(user, "Abcd1234!");
                manager.AddToRole(user.Id, Roles.USER);
            }
        }

        private static void SeedCars(ApplicationDbContext db)
        {
            db.Cars.AddOrUpdate(
                c => c.ModelId,
                new Car
                {
                    ModelId = 1,
                    ModelName = "XKE",
                    FirstYear = 1961,
                    LastYear = 1975,
                    UnitsProduced = 70000,
                    Description = "The Jaguar E-Type (a.k.a. Jaguar XK-E) is a British sports car, which was manufactured by Jaguar Cars Ltd between 1961 and 1975. Its combination of good looks, high performance and competitive pricing established the marque as an icon of 1960s motoring. More than 70,000 E-Types were sold.",
                    Synopsis = "The E-Type was initially designed and shown to the public as a rear-wheel drive grand tourer in two-seater coupé form (FHC or Fixed Head Coupé) and as a two-seater convertible (OTS or Open Two Seater). A \"2+2\" four-seater version of the coupé, with a lengthened wheelbase, was released several years later. On its release Enzo Ferrari called it \"The most beautiful car ever made\". Later model updates of the E-Type were officially designated \"Series 2\" and \"Series 3\", and over time the earlier cars have come to be referred to as \"Series 1\" and \"Series 1½\". Of the \"Series 1\" cars, Jaguar manufactured some limited-edition variants, inspired by motor racing. The \"'Lightweight' E-Type\" which was apparently intended as a sort of follow-up to the D-Type. Jaguar planned to produce 18 units but ultimately only a dozen were reportedly built. Of those, two have been converted to Low-Drag form and two others are known to have been wrecked and deemed to be beyond repair, although one has now been rebuilt. These are exceedingly rare and sought after by collectors. The \"Low Drag Coupé\" was a one-off technical exercise which was ultimately sold to a Jaguar racing driver. It is presently believed to be part of the private collection of the current Viscount Cowdray. The New York City Museum of Modern Art recognised the significance of the E-Type's design in 1996 by adding a blue roadster to its permanent design collection, one of only six automobiles to receive the distinction.",
                    ImgUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9a/1963_Jaguar_XK-E_Roadster.jpg/2560px-1963_Jaguar_XK-E_Roadster.jpg",
                    DateCreated = DateTime.Now
                },

                 new Car
                 {
                     ModelId = 2,
                     ModelName = "Mark 2",
                     FirstYear = 1959,
                     LastYear = 1967,
                     UnitsProduced = 91222,
                     Description = "Medium-sized saloon car built from late 1959 to 1967",
                     Synopsis = "Adhering to Sir William Lyons' maxim of \"grace, pace and space\", the Mark 2 was a fast and capable saloon. It came with a 120 bhp (89 kW; 120 PS) 2,483 cubic centimetres (152 cu in), 210 bhp (160 kW; 210 PS) 3,442 cubic centimetres (210 cu in) or 220 bhp (160 kW; 220 PS) 3,781 cubic centimetres (231 cu in) Jaguar XK engine.[5] The 3.8 is similar to the unit used in the 3.8 E-Type (called XKE in the USA), having the same block, crank, connecting rods and pistons but different inlet manifold and carburation (two SUs versus three on the E-Type in Europe) and therefore 30 bhp (22 kW) less. The head of the six-cylinder engine in the Mark 2 had curved ports compared to the straight ports of the E-Type configuration. The 3.4 Litre and 3.8 Litre cars were fitted with twin SU HD6 carburettors and the 2.4 Litre with twin Solex carburettors. Some explanation is required concerning the claimed bhp figures shown above. Jaguar used gross bhp figures throughout the production period of the Mk II and 240/340 models. A direct conversion into DIN bhp is not possible, but we know that the 3.8 Mk II engine developed around 190bhp DIN.This compares with the later 4.2 XJ6 engine which also gave around 190bhp DIN or 245 gross bhp, according to Jaguar, both being for 8:1 compression engines. The explanation was that the lower peak for the XJ6 4.2 engine meant that the bhp was being delivered at less rpm, for the same output.The camshaft timing and inlet and exhaust valve sizes were the same for the 2.4,3.4,3.8 Mk II and XJ6 4.2 engines, so the engines throttled themselves sooner in the bigger engine sizes. The later 4.2 XJ6 engines had special induction pipes, to reduce exhaust emissions, that crossed over between the inlet and exhaust sides of the engine, which reduced bhp to around 170bhp on later production.",
                     ImgUrl = "https://upload.wikimedia.org/wikipedia/commons/c/cd/Jaguar.3point4.750pix.jpg",
                     DateCreated = DateTime.Now
                 },

                 new Car
                 {
                     ModelId = 3,
                     ModelName = "XK120",
                     FirstYear = 1948,
                     LastYear = 1954,
                     UnitsProduced = 12055,
                     Description = "Jaguar's first sports car since the SS 100, which ceased production in 1940",
                     Synopsis = "The XK120 was launched in open two-seater or (US) roadster form at the 1948 London Motor Show as a testbed and show car for the new Jaguar XK engine. The display car was the first prototype, chassis number 670001. It looked almost identical to the production cars except that the straight outer pillars of its windscreen would be curved on the production version. The roadster caused a sensation, which persuaded Jaguar founder and design boss William Lyons to put it into production.",
                     ImgUrl = "https://upload.wikimedia.org/wikipedia/commons/a/a8/Chichester_-_Jaguar_XK120_-_geograph.org.uk_-_1349971.jpg",
                     DateCreated = DateTime.Now
                 });
        }

        private static void SeedTransactions(ApplicationDbContext db)
        {
            db.Transactions.AddOrUpdate(
                t => t.TransactionId,
                new Transaction
                {
                    TransactionId = 1,
                    ModelId = 1,
                    TransType = "Private",
                    SalePrice = 83000,
                    DateSold = DateTime.Now,
                    SellerName = "Rodney Place",
                    SellerCountry = "USA",
                    BuyerName = "Rodney Place, Jr.",
                    BuyerCountry = "USA",
                    CarYear = 1975,
                    ExtColor = "White",
                    IntColor = "Black",
                    CarMiles = 77000,
                    NumsMatch = true,
                    Notes = "Private party sale."
                },

                new Transaction
                {
                    TransactionId = 2,
                    ModelId = 1,
                    TransType = "Private",
                    SalePrice = 144000,
                    DateSold = DateTime.Now,
                    SellerName = "Seller One",
                    SellerCountry = "USA",
                    BuyerName = "Buyer One",
                    BuyerCountry = "USA",
                    CarYear = 1964,
                    ExtColor = "British Racing Green",
                    IntColor = "Brown",
                    CarMiles = 26000,
                    NumsMatch = true,
                    Notes = "Private party sale."
                },
                new Transaction
                {
                    TransactionId = 3,
                    ModelId = 2,
                    TransType = "Private",
                    SalePrice = 38000,
                    DateSold = DateTime.Now,
                    SellerName = "Rodney Place",
                    SellerCountry = "USA",
                    BuyerName = "Giovanni Rosati",
                    BuyerCountry = "USA",
                    CarYear = 1975,
                    ExtColor = "Blue",
                    IntColor = "Brown",
                    CarMiles = 77000,
                    NumsMatch = true,
                    Notes = "Private party sale."
                },
                new Transaction
                {
                    TransactionId = 4,
                    ModelId = 2,
                    TransType = "Private",
                    SalePrice = 83000,
                    DateSold = DateTime.Now,
                    SellerName = "Seller Two",
                    SellerCountry = "USA",
                    BuyerName = "Buyer Two",
                    BuyerCountry = "USA",
                    CarYear = 1975,
                    ExtColor = "Red",
                    IntColor = "Brown",
                    CarMiles = 77000,
                    NumsMatch = true,
                    Notes = "Private party sale."
                },
                new Transaction
                {
                    TransactionId = 5,
                    ModelId = 3,
                    TransType = "Private",
                    SalePrice = 83000,
                    DateSold = DateTime.Now,
                    SellerName = "Seller Three",
                    SellerCountry = "USA",
                    BuyerName = "Buyer Three",
                    BuyerCountry = "USA",
                    CarYear = 1975,
                    ExtColor = "Green",
                    IntColor = "Brown",
                    CarMiles = 77000,
                    NumsMatch = true,
                    Notes = "Private party sale."
                },

                new Transaction
                {
                    TransactionId = 6,
                    ModelId = 3,
                    TransType = "Private",
                    SalePrice = 83000,
                    DateSold = DateTime.Now,
                    SellerName = "Seller Four",
                    SellerCountry = "USA",
                    BuyerName = "Buyer Four",
                    BuyerCountry = "USA",
                    CarYear = 1964,
                    ExtColor = "Yellow",
                    IntColor = "Black",
                    CarMiles = 83000,
                    NumsMatch = true,
                    Notes = "Private party sale."
                });
        }
    }
}