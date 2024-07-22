using Microsoft.AspNetCore.Identity;
using SimpleETicketPlatform.Infrastructure.Data.Models;

namespace SimpleETicketPlatform.Infrastructure.SeedDb
{
    public class SeedData
    {
        public Cinema Cinema1 { get; set; }
        public Cinema Cinema2 { get; set; }
        public Cinema Cinema3 { get; set; }
        public Movie Movie1 { get; set; }
        public Movie Movie2 { get; set; }
        public Movie Movie3 { get; set; }
        public Movie Movie4 { get; set; }
        public Movie Movie5 { get; set; }
        public Movie Movie6 { get; set; }
        public Producer Producer1 { get; set; }
        public Producer Producer2 { get; set; }
        public Producer Producer3 { get; set; }
        public Producer Producer4 { get; set; }
        public Producer Producer5 { get; set; }
        public Producer Producer6 { get; set; }
		public Actor Actor1 { get; set; }
		public Actor Actor2 { get; set; }
		public Actor Actor3 { get; set; }
		public Actor Actor4 { get; set; }
		public Actor Actor5 { get; set; }
		public Actor Actor6 { get; set; }
		public MovieActor Actor1Movie1 { get; set; }
		public MovieActor Actor2Movie1 { get; set; }
		public MovieActor Actor3Movie2 { get; set; }
		public MovieActor Actor4Movie2 { get; set; }
		public MovieActor Actor5Movie3 { get; set; }
		public MovieActor Actor6Movie3 { get; set; }
		public MovieActor Actor1Movie4 { get; set; }
		public MovieActor Actor6Movie5 { get; set; }
		public MovieCategory Category1 { get; set; }
        public MovieCategory Category2 { get; set; }
        public MovieCategory Category3 { get; set; }
        public MovieCategory Category4 { get; set; }
        public MovieCategory Category5 { get; set; }
        public MovieCategory Category6 { get; set; }
        public MovieCategory Category7 { get; set; }
        public ApplicationUser AdminUser { get; set; }
        public ApplicationUser User { get; set; }
        public SeedData()
        {
			SeedProducers();
			SeedCinemas();
            SeedMovieCategories();
            SeedMovies();            
            SeedActors();
            SeedMovieActors();
            SeedUsers();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            AdminUser = new ApplicationUser
            {
                FullName = "Admin",
                UserName = "admin",
                Email = "admin@gmail.com",
                EmailConfirmed = true
            };

            AdminUser.PasswordHash = hasher.HashPassword(AdminUser, "admin123");

            User = new ApplicationUser
            {
                FullName = "User",
                UserName = "user",
                Email = "user@gmail.com",
                EmailConfirmed = true
            };

            User.PasswordHash = hasher.HashPassword(User, "user123");
        }

        private void SeedMovieCategories()
        {
			Category1 = new MovieCategory
			{
				Id = 1,
				Name = "Action"
			};
            Category2 = new MovieCategory
            {
                Id = 2,
                Name = "Fantasy"
            };
            Category3 = new MovieCategory
            {
                Id = 3,
                Name = "Drama"
            };
            Category4 = new MovieCategory
            {
                Id = 4,
                Name = "Romance"
            };
            Category5 = new MovieCategory
            {
                Id = 5,
                Name = "Cartoon"
            };
            Category6 = new MovieCategory
            {
                Id = 6,
                Name = "Comedy"
            };
            Category7 = new MovieCategory
            {
                Id = 7,
                Name = "Thriller"
            };

        }

        private void SeedProducers()
        {
            Producer1 = new Producer
            {
                Id = 1,
                FullName = "James Cameroon",
                Biography = "James Cameron is a renowned filmmaker and producer known for his innovative and influential work in the film industry. Born in 1954, Cameron directed and produced blockbuster hits such as \"The Terminator,\" \"Avatar,\" and \"Titanic.\" His dedication to pushing technological boundaries has earned him multiple Academy Awards, including Best Picture and Best Director for \"Titanic.\"",
                ProfilePictureURL = "https://media.vanityfair.com/photos/656f89c8710cfd971ca79847/1:1/w_1333,h_1333,c_limit/vf1223-james-cameron.jpg"
            };
            Producer2 = new Producer
            {
                Id = 2,
                FullName = "Tomasz Mandes",
                Biography = "Tomasz Mandes is a Polish actor, director, and producer known for his work in Polish cinema, contributing significantly to both film and television.",
                ProfilePictureURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQi2UgcvhF7fYSMpId7_kKe3gimVzZz3Kha8Q&s"
            };
            Producer3 = new Producer
            {
                Id = 3,
                FullName = "Arnon Milchan",
                Biography = "Arnon Milchan is a prominent Israeli-American film producer known for founding New Regency Productions. His diverse portfolio includes producing hits like \"Mr. & Mrs. Smith,\" \"Pretty Woman,\" and \"The Revenant.\" Milchan's career spans decades, emphasizing his significant impact on Hollywood through successful films and entrepreneurial ventures.",
                ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f7/Arnon_Milchan_%28990040376210205171%29.jpg/640px-Arnon_Milchan_%28990040376210205171%29.jpg"
            };
			Producer4 = new Producer
			{
				Id = 4,
				FullName = "Martin Scorsese",
				Biography = "Martin Scorsese is an acclaimed American filmmaker known for his significant contributions to cinema. Born on November 17, 1942, in New York City, Scorsese has directed numerous iconic films, including \"Taxi Driver,\" \"Goodfellas,\" and \"The Departed.\" His distinctive style often explores themes of crime, redemption, and the human condition. As a producer and director, Scorsese's work on \"The Wolf of Wall Street\" (2013) exemplifies his talent for crafting compelling, character-driven narratives. ",
				ProfilePictureURL = "https://cdn.britannica.com/76/156176-050-90A36E79/Martin-Scorsese-2008.jpg"
			};
			Producer5 = new Producer
			{
				Id = 5,
				FullName = "Joe Roth",
				Biography = "Joe Roth is a prominent American film producer, director, and executive, known for his influential role in Hollywood. Born on June 13, 1948, Roth has produced numerous successful films across various genres. He founded Revolution Studios and served as chairman of Walt Disney Studios and 20th Century Fox. His notable productions include \"Alice in Wonderland,\" \"Snow White and the Huntsman,\" and \"Maleficent.\"",
				ProfilePictureURL = "https://m.media-amazon.com/images/M/MV5BMTgwMDAyNTI0N15BMl5BanBnXkFtZTcwNDY4MDQ4NA@@._V1_.jpg"
			};
			Producer6 = new Producer
			{
				Id = 6,
				FullName = "Pixar Animation Studios",
				Biography = "Pixar Animation Studios, founded in 1986 and now owned by The Walt Disney Company, is renowned for revolutionizing animated filmmaking. Based in Emeryville, California, Pixar has consistently set industry standards with groundbreaking computer-generated imagery (CGI) and storytelling prowess. Their films, including classics like \"Toy Story,\" \"Finding Nemo,\" and \"Up,\" combine technical innovation with heartfelt narratives that appeal to audiences of all ages. Pixar's commitment to creativity and excellence has earned them numerous awards and accolades, solidifying their reputation as one of the most influential animation studios in the world.",
				ProfilePictureURL = "https://www.artofthetitle.com/assets/sm/upload/es/cz/3z/5g/pixar.jpg?k=1ed92a7b61"
			};
		}

        private void SeedCinemas()
        {
            Cinema1 = new Cinema
            {
                Id = 1,
                Name = "Cinema City",
                Logo = "https://cdn.vectorstock.com/i/1000v/38/76/cinema-logo-movie-emblem-template-vector-19873876.jpg",
                Description = "Cinema City is a modern and stylish cinema offering an exceptional movie-going experience. With state-of-the-art projection and sound systems, comfortable seating, and a wide selection of films ranging from the latest blockbusters to indie gems, Cinema1 is the perfect destination for all film enthusiasts."
            };
            Cinema2 = new Cinema
            {
                Id = 2,
                Name = "Cinema World",
                Logo = "https://as2.ftcdn.net/v2/jpg/02/24/93/07/1000_F_224930739_ucWKbPcRZVWSksyE71jRP9Y5Phhwx92i.jpg",
                Description = "Cinema World is a premier destination for movie lovers, offering an immersive cinematic experience with the latest in audio-visual technology. Enjoy a diverse selection of films from Hollywood blockbusters to indie favorites in our comfortable, modern theaters. With a range of delicious concessions and exceptional service, Cinema World is the perfect place for an unforgettable movie-going experience."
            };
            Cinema3 = new Cinema
            {
                Id = 3,
                Name = "Cinema 1",
                Logo = "https://seeklogo.com/images/C/cinema-film-logo-4400A608DF-seeklogo.com.png",
                Description = "Cinema1 is the newest addition to the town, offering a state-of-the-art movie-going experience. Featuring the latest in projection and sound technology, Cinema1 provides comfortable seating and a diverse selection of films, from the latest blockbusters to indie favorites. With a modern ambiance, a variety of snacks, and top-notch service, Cinema1 is set to become the town's premier destination for all cinema enthusiasts."
            };
        }

        private void SeedMovies()
        {
            Movie1 = new Movie
            {
                Id = 1,
                Name = "Titanic",
                Description = "\"Titanic\" is a 1997 epic romance and disaster film directed by James Cameron. It tells the poignant love story of Jack Dawson (Leonardo DiCaprio) and Rose DeWitt Bukater (Kate Winslet), two passengers from different social classes who meet and fall in love aboard the ill-fated RMS Titanic. As the ship tragically sinks on its maiden voyage, their love is tested amidst the chaos and calamity, making \"Titanic\" a timeless tale of love, loss, and human resilience.",
                CinemaId = Cinema1.Id,
                ProducerId = Producer1.Id,
                MovieCategoryId = Category3.Id,
                Price = 12.99m,
                PhotoURL = "https://m.media-amazon.com/images/M/MV5BMDdmZGU3NDQtY2E5My00ZTliLWIzOTUtMTY4ZGI1YjdiNjk3XkEyXkFqcGdeQXVyNTA4NzY1MzY@._V1_.jpg",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(40)
            };
            Movie2 = new Movie
            {
                Id = 2,
                Name = "365 Days",
                Description = "\"365 Days\" is a Polish romantic drama film released in 2020, based on the novel by Blanka Lipińska. The story follows Laura Biel, a sales director who is kidnapped by a Sicilian mafia boss named Massimo Torricelli. Massimo gives Laura 365 days to fall in love with him, promising her a life of luxury and passion. The film explores themes of desire, obsession, and power dynamics amidst a backdrop of opulent settings and intense emotions. ",
                CinemaId = Cinema1.Id,
                ProducerId = Producer2.Id,
                MovieCategoryId = Category4.Id,
                Price = 9.99m,
                PhotoURL = "https://m.media-amazon.com/images/M/MV5BYjY2NzUxNjgtNjJhNy00NTA4LTlmNzItYzQ4MDdjNWYxZjkwXkEyXkFqcGdeQXVyMTEwMTY3NDI@._V1_FMjpg_UX1000_.jpg",
                StartDate = DateTime.Today.AddDays(-20),
                EndDate = DateTime.Today.AddDays(30)
            };
            Movie3 = new Movie
            {
                Id = 3,
                Name = "Mr. and Mrs. Smith",
                Description = "Starring Brad Pitt and Angelina Jolie, the story revolves around John and Jane Smith, a married couple who are unaware that they are both secretly highly skilled assassins working for competing agencies. When they are assigned to kill each other, their seemingly ordinary suburban life turns into a high-stakes game of cat and mouse. Packed with witty banter, explosive action sequences, and charismatic performances from its leads, \"Mr. & Mrs. Smith\" blends romance, humor, and thrilling espionage in a captivating and entertaining manner.",
                ProducerId = Producer3.Id,
                CinemaId = Cinema2.Id,
                MovieCategoryId = Category1.Id,
                Price = 14.99m,
                PhotoURL = "https://m.media-amazon.com/images/M/MV5BYjY2NzUxNjgtNjJhNy00NTA4LTlmNzItYzQ4MDdjNWYxZjkwXkEyXkFqcGdeQXVyMTEwMTY3NDI@._V1_FMjpg_UX1000_.jpg",
                StartDate = DateTime.Today.AddDays(20),
                EndDate = DateTime.Today.AddDays(70)
            };
			Movie4 = new Movie
			{
				Id = 4,
				Name = "The Wolf of Wall Street",
				Description = "\"The Wolf of Wall Street\" is a 2013 biographical black comedy directed by Martin Scorsese. Starring Leonardo DiCaprio as Jordan Belfort, the film chronicles Belfort's rise and fall as a stockbroker who engages in rampant corruption and fraud on Wall Street. Known for its high-energy storytelling, extravagant lifestyle depictions, and dark humor, the movie delves into themes of greed, excess, and moral ambiguity. With standout performances, particularly by DiCaprio and Jonah Hill, \"The Wolf of Wall Street\" is both a cautionary tale and an entertaining exploration of the excesses of the financial world.",
				ProducerId = Producer4.Id,
                CinemaId = Cinema3.Id,
				MovieCategoryId = Category3.Id,
				Price = 19.99m,
				PhotoURL = "https://m.media-amazon.com/images/M/MV5BMjIxMjgxNTk0MF5BMl5BanBnXkFtZTgwNjIyOTg2MDE@._V1_.jpg",
				StartDate = DateTime.Today.AddDays(30),
				EndDate = DateTime.Today.AddDays(100)
			};
			Movie5 = new Movie
			{
				Id = 5,
				Name = "Maleficent",
				Description = "\"Maleficent\" is a 2014 fantasy film directed by Robert Stromberg. It stars Angelina Jolie as Maleficent, a powerful fairy who becomes vengeful after being betrayed. The film reimagines the classic \"Sleeping Beauty\" tale from Maleficent's perspective, exploring her backstory and the events that led her to curse Princess Aurora. With stunning visuals, a captivating performance by Jolie, and a fresh take on a well-known story, \"Maleficent\" delves into themes of betrayal, redemption, and the complexity of good and evil.",
				ProducerId = Producer5.Id,
				CinemaId = Cinema2.Id,
				MovieCategoryId = Category2.Id,
				Price = 7.99m,
				PhotoURL = "https://upload.wikimedia.org/wikipedia/en/5/55/Maleficent_poster.jpg",
				StartDate = DateTime.Today.AddDays(90),
				EndDate = DateTime.Today.AddDays(140)
			};
			Movie6 = new Movie
			{
				Id = 6,
				Name = "Inside out",
				Description = "\"Inside Out\" is a 2015 Pixar film directed by Pete Docter. It cleverly explores emotions through the story of Riley, a young girl navigating life's challenges with the help of Joy, Sadness, Anger, Fear, and Disgust—personified as characters inside her mind's control center. The film's imaginative concept and heartfelt storytelling delve into the complexities of growing up, memory, and the importance of embracing all emotions.",
				ProducerId = Producer6.Id,
				CinemaId = Cinema2.Id,
				MovieCategoryId = Category5.Id,
				Price = 5.99m,
				PhotoURL = "https://m.media-amazon.com/images/M/MV5BOTgxMDQwMDk0OF5BMl5BanBnXkFtZTgwNjU5OTg2NDE@._V1_.jpg",
				StartDate = DateTime.Today.AddDays(10),
				EndDate = DateTime.Today.AddDays(70)
			};
		}
		private void SeedActors()
		{
            Actor1 = new Actor()
            {
                Id = 1,
                FullName = "Leonardo DiCaprio",
				Biography = "Leonardo DiCaprio is a renowned American actor and film producer, born on November 11, 1974, in Los Angeles, California. He gained fame with his roles in \"Titanic\" (1997) and \"Romeo + Juliet\" (1996) and is known for his versatility and intense performances. DiCaprio has starred in numerous critically acclaimed films, including \"The Wolf of Wall Street,\" \"Inception,\" and \"The Revenant,\" for which he won an Academy Award for Best Actor. Beyond acting, he is an active environmentalist, advocating for climate change awareness and sustainability through his Leonardo DiCaprio Foundation.",
                ProfilePictureURL = "https://s2.r29static.com/bin/entry/84e/720x864,85/1884149/image.webp"
			};
			Actor2 = new Actor()
			{
				Id = 2,
				FullName = "Kate Winslet",
				Biography = "Kate Winslet is a celebrated British actress, born on October 5, 1975, in Reading, England. She rose to international prominence with her role as Rose DeWitt Bukater in \"Titanic\" (1997). Known for her versatility and depth, Winslet has delivered powerful performances in films such as \"Eternal Sunshine of the Spotless Mind,\" \"The Reader,\" for which she won an Academy Award for Best Actress, and \"Steve Jobs.\" Winslet is acclaimed for her ability to portray complex characters and has earned numerous awards throughout her career. She is also an advocate for body positivity and various humanitarian causes.",
				ProfilePictureURL = "https://cdn.britannica.com/38/130638-050-DBCE19EE/Kate-Winslet.jpg"
			};
			Actor3 = new Actor()
			{
				Id = 3,
				FullName = "Michele Morrone",
				Biography = "Michele Morrone is an Italian actor, model, and singer, born on October 3, 1990, in Melegnano, Italy. He gained international fame for his role as Massimo Torricelli in the 2020 film \"365 Days.\" Known for his charismatic screen presence and intense performances, Morrone has captivated audiences worldwide. In addition to acting, he has a successful music career, with his debut album \"Dark Room\" featuring songs from the \"365 Days\" soundtrack. ",
				ProfilePictureURL = "https://i.pinimg.com/736x/cb/d2/b3/cbd2b39d8dd9f39f4499aaa21c5af529.jpg"
			};
			Actor4 = new Actor()
			{
				Id = 4,
				FullName = "Anna-Maria Sieklucka",
				Biography = "Anna-Maria Sieklucka is a Polish actress, known for her breakout role as Laura Biel in the 2020 film \"365 Days.\" Born on May 31, 1992, Sieklucka garnered attention for her compelling portrayal of a young woman caught in a complex and intense relationship with a mafia boss. Her performance in \"365 Days\" propelled her to international recognition, showcasing her talent for emotive storytelling and on-screen chemistry. Beyond acting, Sieklucka continues to engage audiences with her dedication to her craft and is poised for further success in her career.",
				ProfilePictureURL = "https://media.themoviedb.org/t/p/w500/c5Rhg0pewnANvLfx2fDXKTLawTb.jpg"
			};
			Actor5 = new Actor()
			{
				Id = 5,
				FullName = "Brad Pitt",
				Biography = "Brad Pitt is a highly acclaimed American actor and film producer, born on December 18, 1963, in Shawnee, Oklahoma. Known for his charismatic presence and versatile performances, Pitt has starred in a wide range of successful films. He gained prominence in the early 1990s with roles in \"Thelma & Louise\" and \"A River Runs Through It,\" and solidified his status as a leading actor with iconic performances in \"Fight Club,\" \"Ocean's Eleven,\" and \"Troy.\" Pitt's acting prowess has earned him numerous awards, including an Academy Award for Best Supporting Actor for his role in \"Once Upon a Time in Hollywood.\" In addition to his acting career, Pitt is also a successful film producer, known for his work with Plan B Entertainment.",
				ProfilePictureURL = "https://resizing.flixster.com/SAUTcTD8KmznQaWfE7okll09Fgc=/218x280/v2/https://resizing.flixster.com/-XZAfHZM39UwaGJIFWKAE8fS0ak=/v3/t/assets/1366_v9_bc.jpg"
			};
			Actor6 = new Actor()
			{
				Id = 6,
				FullName = "Angelina Jolie",
				Biography = "Angelina Jolie is an iconic American actress, filmmaker, and humanitarian, born on June 4, 1975, in Los Angeles, California. Known for her captivating performances and striking beauty, Jolie has starred in a diverse range of films, including \"Girl, Interrupted,\" \"Lara Croft: Tomb Raider,\" and \"Maleficent.\" Beyond her acting career, she is acclaimed for her humanitarian work as a Special Envoy for the United Nations High Commissioner for Refugees (UNHCR), advocating for refugees' rights and global humanitarian issues. Jolie's impact extends beyond entertainment, making her a prominent figure in both Hollywood and humanitarian efforts worldwide.",
				ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ad/Angelina_Jolie_2_June_2014_%28cropped%29.jpg/640px-Angelina_Jolie_2_June_2014_%28cropped%29.jpg"
			};
		}
		private void SeedMovieActors()
		{
            Actor1Movie1 = new MovieActor()
            {
                ActorId = Actor1.Id,
                MovieId = Movie1.Id
            };
			Actor2Movie1 = new MovieActor()
			{
				ActorId = 2,
				MovieId = 1
			};
			Actor3Movie2 = new MovieActor()
			{
				ActorId = 3,
				MovieId = 2
			};
			Actor4Movie2 = new MovieActor()
			{
				ActorId = 4,
				MovieId = 2
			};
			Actor5Movie3 = new MovieActor()
			{
				ActorId = 5,
				MovieId = 3
			};
			Actor6Movie3 = new MovieActor()
			{
				ActorId = 6,
				MovieId = 3
			};
			Actor1Movie4 = new MovieActor()
			{
				ActorId = Actor1.Id,
				MovieId = Movie4.Id
			};
			Actor6Movie5 = new MovieActor()
			{
				ActorId = 6,
				MovieId = 5
			};
		}
	}
}
