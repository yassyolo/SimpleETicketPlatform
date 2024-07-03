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
        public SeedData()
        {
            SeedCinemas();
            SeedMovies();
            SeedProducers();
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
                CinemaId = 1,
                ProducerId = 1,
                MovieCategory = MovieCategory.Drama,
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
                CinemaId = 1,
                ProducerId = 2,
                MovieCategory = MovieCategory.Romance,
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
                ProducerId = 3,
                MovieCategory = MovieCategory.Action,
                Price = 14.99m,
                PhotoURL = "https://m.media-amazon.com/images/M/MV5BYjY2NzUxNjgtNjJhNy00NTA4LTlmNzItYzQ4MDdjNWYxZjkwXkEyXkFqcGdeQXVyMTEwMTY3NDI@._V1_FMjpg_UX1000_.jpg",
                StartDate = DateTime.Today.AddDays(20),
                EndDate = DateTime.Today.AddDays(70)
            };
        }
    }
}
