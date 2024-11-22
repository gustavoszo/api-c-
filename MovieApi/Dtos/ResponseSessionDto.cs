namespace MovieApi.Dtos
{
    public class ResponseSessionDto
    {

        public ResponseRoomDto Room { get; set; }
        public ResponseMovieDto Movie;
        public DateTime Time { get; set; }
    }
}
