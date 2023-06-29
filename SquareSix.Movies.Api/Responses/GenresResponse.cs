namespace SquareSix.Movies.Api.Responses
{
    public class GenresResponse
    {
        public Genre[] Genres { get; set; }
    }

    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
