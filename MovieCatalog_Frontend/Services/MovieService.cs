using MovieCatalog_Frontend.Models;
using System;
using System.Net.Http.Json;

namespace MovieCatalog_Frontend.Services
{
    public class MovieService
    {
        private readonly HttpClient? _httpClient;
        private readonly string _baseUrl = "http://localhost:5289/api/Movies";  // my already existing backend URL

        // constructor
        public MovieService(HttpClient _httpClient) // dependency injection
        {
            this._httpClient = _httpClient;
        }

        // Get all movies from backend
        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Movie>>(_baseUrl); // fetch data from backend
            return result ?? new List<Movie>(); // "??" - null coalescing opeator - If result is not null, return result; otherwise, return a new empty List<Movie>
        }

        // Get by top-rated movies, default is 1
        public async Task<List<Movie>> GetTopRatedMovieAsync(int count = 1)
        {
            return await _httpClient.GetFromJsonAsync<List<Movie>>($"{_baseUrl}/top-rated?count={count}") ?? new List<Movie>();

        }

        // Get movie rating
        public async Task<List<Movie>> GetByRated(double rate_provide)
        {
            return await _httpClient.GetFromJsonAsync<List<Movie>>($"{_baseUrl}/rating?rate_provide={rate_provide}") ?? new List<Movie>();
        }

        // Get all movies in descending order by year
        public async Task<List<Movie>> GetMovieByDescendingOrder()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Movie>>($"{_baseUrl}/deccending order by year");
            return result ?? new List<Movie>();
        }

        // Get movie by genre
        public async Task<List<Movie>> GetMovieByGenre(string genre)
        {
            return await _httpClient.GetFromJsonAsync<List<Movie>>($"{_baseUrl}/genre={genre}") ?? new List<Movie>();
        }

        // Get movie by Id, title, and genre
        public async Task<List<Movie>> GetMovieByIdTitleGenre(int id_selected)
        {
            return await _httpClient.GetFromJsonAsync<List<Movie>>($"{_baseUrl}/id/title/genre/{id_selected}") ?? new List<Movie>();
        }


        // Create a new movie (POST)        
        /*         
            - The `newMovie` object must be sent in the **body** of the request - not in the URL.
            - WRONG: .PostAsJsonAsync($"{_baseUrl}/create new movie/{newMovie}") - would place the entire object in the URL (invalid route).
            - CORRECT: .PostAsJsonAsync($"{_baseUrl}/create new movie", newMovie) - sends the object as JSON in the request BODY.
            - This matches the backend controller signature:
            - [HttpPost("create new movie")] public ActionResult CreateMovie(Movie newMovie)
        */
        public async Task<Movie?> CreateMovieAsync(Movie newMovie)  // "Task<Movie?>" - This endpoint only return the CREATED movie object, not a list
        {
            var createMovieResponse = await _httpClient.PostAsJsonAsync($"{_baseUrl}/create new movie", newMovie);
            return await createMovieResponse.Content.ReadFromJsonAsync<Movie>();
        }

        
        // Update movie (PUT)
        /*
            - This method sends both the Movie ID (in the URL) and the updated Movie data (in the request body) to match the backend endpoint structure:
            - Method Signature: "public ActionResult UpdateMovie(int id, Movie updateMovie)":

            - The "id" goes in the URL, and "updatedMovie" goes in the BODY
         */
        public async Task<Movie?> UpdateMovieAsync(int id_movie, Movie updatedMovie)    // "Task<Movie?>" - This endpoint only return the UPDATED movie object, not a list
        {
            // Send PUT request with ID in URL and updated movie data in the body
            var updateMovieResponse = await _httpClient.PutAsJsonAsync($"{_baseUrl}/update_movie/{id_movie}", updatedMovie);

            // Deserialize and return the updated movie from the response (if available)
            return await updateMovieResponse.Content.ReadFromJsonAsync<Movie>();
        }


        // Delete Movie (DELETE)
        /*
            - The backend returns 204 No Content on success, so there's nothing to deserialize.
            - We only need to check if the request was successful (StatusCode 204 or 200).
            - If the movie doesn’t exist, backend returns 404 (Not Found).
         */
        public async Task<bool> DeleteMovieAsync(int id_movie)
        {
            var deleteMovieResponse = await _httpClient.DeleteAsync($"{_baseUrl}/delete_movie/{id_movie}");
            
            if (deleteMovieResponse.IsSuccessStatusCode)
            {
                return true; // Successfully deleted (204 No Content)
            }
            
            return false;   // Something went wrong (e.g., not found or server error)
        }

    }
}
