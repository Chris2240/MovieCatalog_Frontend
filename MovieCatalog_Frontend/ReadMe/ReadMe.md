# MovieCatalog Frontend – Blazor WebAssembly UI (API Integration)

## Description
This project provides the user interface (UI) for the MovieCatalog_Frntend application.
It integrates with the **MovieCatalog Web API** (backend) which need to running as well to display, create, edit, and delete movies.

## Contents
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
- [Features](#features)
- [Implementation details](#implementation-details)
	- [Backend Integration](#backend-integration)
	- [Home Page](#home-page-impl)
	- [All Movies](#all-movies-impl)
	- [Top Rated Movie(s)](#top-rated-movies-impl)
	- [Rated Movie](#rated-movie-impl)
	- [Descending order by year](#descending-order-by-year-impl)
	- [Genre Movie(s)List](#genre-movie-list-impl)
	- [Displaying Id, Title and Genre](#displaying-id-title-genre-impl)
	- [Create New Page](#create-new-page-impl)
	- [Update Movie](#update-movie-impl)
	- [Delete Movie](#delete-movie-impl)
- [Summary](#summary)
- [API Documentation](#api-documentation)
- [License](#license)

## Technologies Used
This Blazor UI application is built using the following technologies:

* Blazor WebAssembly (.NET 8)
* C#
* Razor Components
* HTML5
* CSS3
* HttpClient (for API communication)
* System.Net.Http.Json (JSON serialization/deserialization)
* Asynchronous Programming (async/await)
* Dependency Injection (Service)
* Service Layer Pattern (MovieService)

<a id="getting-started"></a>
## Getting Started
To get started with the MovieCatalog Frontend, follow these steps:

1. Clone the repository:
	
	* clone the project from the github repository(the link was provided into this path),
	* then open the gitBash using right click (if you have already generally installed the git bush into your PC)
   
	```bash
   git clone https://github.com/Chris2240/MovieCatalog_Frontend.git (whatever the link is copied)
   cd MovieCatalog_Frontend
	```

2. Install dependencies:

	The project uses .NET 8.
	
	In Visual Studio in the PowerShell terminal run:
	```bash
	dotnet restore
	```

3. Run the application (there is a two options):

* Using Visual Studio:
   - Open the solution in Visual Studio.
   - Make sure the "http" is selected then press F5 or click on the "Start" button to run the application.

* Using PowerShell in Visual Studio:

   To run the application from PowerShell terminal you **NEED** to go to other **MovieCatalog_Frontend** folder where the **.csproject** file is contained and from there the following command it will work:
   
	```bash
	cd MovieCatalog_Frontend
	dotnet run
	```
Now you are able to open the browser using **Blazor UI** with the following path: `http://localhost:5269` to check and test all Http endpoints ;)

<a id="features"></a>
## Features

* ### Home Page:

	This page is introduce the user to the MovieCatalog_Frontend application with a welcome message and brief description.

	<img src="./Screenshots_Readme/Screenshot 1.jpg" width="70%"/>
	<br/><br/>

* ### All Movies Page:

	<img src="./Screenshots_Readme/Screenshot 2.jpg" width="70%"/>
	<br/><br/>

* ### Top rated Movie(s):

	This page displays the top-rated movie(s) fetched from the Web API provided by number of movies via user input.

	<img src="./Screenshots_Readme/Screenshot 4.jpg" width="70%"/>
	<br/><br/>

	<img src="./Screenshots_Readme/Screenshot 5.jpg" width="70%"/>
	<br/><br/>

* ### Rated Movie:

	This page displays the movie depending on rate providing via user.

	<img src="./Screenshots_Readme/Screenshot 6.jpg" width="70%"/>
	<br/><br/>

	<img src="./Screenshots_Readme/Screenshot 7.jpg" width="70%"/>
	<br/><br/>

* ### Descending order by Year:

	This page displaying the movies list in descending order by year.

	<img src="./Screenshots_Readme/Screenshot 8.jpg" width="70%"/>
	<br/><br/>

* ### Genre Movie(s) List:

	This page displays the movies depending on what user "genre" enters.

	<img src="./Screenshots_Readme/Screenshot 9.jpg" width="70%"/>
	<br/><br/>

	<img src="./Screenshots_Readme/Screenshot 10.jpg" width="70%"/>
	<br/><br/>

* ### Displaying Id, Title and Genre:

	This page displays the movie id, title and genre only, via user "Id" enter. 

	<img src="./Screenshots_Readme/Screenshot 11.jpg" width="70%"/>
	<br/><br/>

	<img src="./Screenshots_Readme/Screenshot 12.jpg" width="70%"/>
	<br/><br/>

	<img src="./Screenshots_Readme/Screenshot 13.jpg" width="70%"/>
	<br/><br/>

* ### Create a new page:

	This page allowed the user to create a new page.

	<img src="./Screenshots_Readme/Screenshot 14.jpg" width="70%"/>
	<br/><br/>

	<img src="./Screenshots_Readme/Screenshot 15.jpg" width="70%"/>
	<br/><br/>

	<img src="./Screenshots_Readme/Screenshot 16.jpg" width="70%"/>
	<br/><br/>

	Then at **All Movies** page the new movie is displayed as expected:

	<img src="./Screenshots_Readme/Screenshot 17.jpg" width="70%"/>
	<br/><br/>

* ### Update Movie:

	This page allows the user to update an existing movie by entering its "Id".

	<img src="./Screenshots_Readme/Screenshot 18.jpg" width="70%"/>
	<br/><br/>

	<img src="./Screenshots_Readme/Screenshot 19.jpg" width="70%"/>
	<br/><br/>

	<img src="./Screenshots_Readme/Screenshot 20.jpg" width="70%"/>
	<br/><br/>

	<img src="./Screenshots_Readme/Screenshot 21.jpg" width="70%"/>
	<br/><br/>

	<img src="./Screenshots_Readme/Screenshot 22.jpg" width="70%"/>
	<br/><br/>

	Then you can see the updated movie at **All Movies** page as expected:

	<img src="./Screenshots_Readme/Screenshot 23.jpg" width="70%"/>
	<br/><br/>

* ### Delete Movie:

	This page allows the user to delete an existing movie by pressing the "Delete" button.

	<img src="./Screenshots_Readme/Screenshot 24.jpg" width="70%"/>
	<br/><br/>

	<img src="./Screenshots_Readme/Screenshot 25.jpg" width="70%"/>
	<br/><br/>
	
	Then you can see that the movie is deleted at **All Movies** page as expected:

	<img src="./Screenshots_Readme/Screenshot 26.jpg" width="70%"/>
	<br/><br/>

<a id="implementation-details"></a>
## Implementation details

<a id="backend-integration"></a>
* ### Backend Integration:

	Uses HttpClient to send and receive JSON data from the Web API.

	At **MovieServices.cs:**
	
	```csharp
	public class MovieService
    {
        private readonly HttpClient? _httpClient;
        private readonly string _baseUrl = "http://localhost:5289/api/Movies";  // my already existing backend URL

        // constructor
        public MovieService(HttpClient _httpClient) // dependency injection
        {
            this._httpClient = _httpClient;
        }
		
		// All CRUD operations here as async methods which are integrated with backend API from MovieCatalog project
	}
	```

	Then I have to provide this registration at the **Program.cs**:

	```csharp
	using Microsoft.AspNetCore.Components.Web;
	using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
	using MovieCatalog_Frontend.Services;

	namespace MovieCatalog_Frontend
	{
		public class Program
		{
			public static async Task Main(string[] args)
			{
				var builder = WebAssemblyHostBuilder.CreateDefault(args);
				builder.RootComponents.Add<App>("#app");
				builder.RootComponents.Add<HeadOutlet>("head::after");

				builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

				// Register my MovieService
				builder.Services.AddScoped<MovieService>();

				await builder.Build().RunAsync();
			}
		}
	}
	```

<a id="home-page-impl"></a>
* ### Home Page:
	In this app as you can see I provide the side bar navigation menu to access different sections of the application. In this case I wanted show how I achived it using the CSS and Blazor components. Also I added some styling to make the UI more appealing:
	
	At **app.css:**
	
	```css
	/* Sidebar styling */
	#sidebar {
		width: 220px;
		background-color: #2d2d2d;
		color: white;
		padding: 1rem;
		height: 100vh;
		position: fixed;
		top: 0;
		left: 0;
	/*    overflow-y: auto;*/
	}

	#layout {
		display: flex;  /* in this case this deleting bottom side bar to the left or right */
	}

	#main-content {
		margin-left: 240px; /* offset for sidebar width + padding */
		padding: 1rem;
		width: calc(100% - 240px);
	}

	/* normalize/remove default spacing that affects page layout */
	html, body {
		margin-left: 5px;
		padding: 0;
	}


	/* Custom styling for the page title and table */
	.page_title {
		text-align: center;
		margin-bottom: 100px;
	}

	table {
		margin-left: auto;
		margin-right: auto;
	}

	table, th, td {
		border: 1px solid;
		border-collapse: collapse;
	}

	th, td {
		padding: 10px;
		width: auto;
	}

	tr {
		text-align: center;
	}

	/* creating button nav-link */
	
	.nav-link {
		width: fit-content;
		font-size: 0.8rem;
		padding: 10px;
		border: 2px solid white;
		border-radius: 6px;
		text-decoration: none;
		cursor: pointer;
		background-color: blue;
		color: white;
		display: block;         /* this makes the link available margin */
		margin-bottom: 5px;
	}

	/* New page(green), Update(orange) and Delete(red) nav-links*/
	.nav-link-green {
		width: fit-content;
		font-size: 0.8rem;
		padding: 10px;
		border: 2px solid white;
		border-radius: 6px;
		text-decoration: none;
		cursor: pointer;
		background-color: green;
		color: sandybrown;
		display: block; /* this makes the link available to do a margin */
		margin-bottom: 5px;
	}

	.nav-link-orange {
		width: fit-content;
		font-size: 0.8rem;
		padding: 10px;
		border: 2px solid white;
		border-radius: 6px;
		text-decoration: none;
		cursor: pointer;
		background-color: orange;
		color: white;
		display: block;
		margin-bottom: 5px;
	}

	.nav-link-red {
		width: fit-content;
		font-size: 0.8rem;
		padding: 10px;
		border: 2px solid white;
		border-radius: 6px;
		text-decoration: none;
		cursor: pointer;
		background-color: red;
		color: white;
		display: block;
		margin-bottom: 5px;
	}


	/* create movie content */
	.movie-grid-div {
		display: grid;
		grid-template-columns: auto 1fr; /* label & input make within a column */
		align-items: center; /* vertically centers labels and inputs */
		gap: 5px 10px; /* row gap | column gap */
		padding: 10px;
		margin-top: 30px;
		max-width: 300px; /* optional, keeps layout compact */
	}

	.movie-grid-div label {
		text-align: center; /* aligns labels neatly */

	}

	.movie-grid-div button {
		margin-top: 30px;

	}
	```
	
	At **Home.razor:**

	```razor
	@page "/"

	<PageTitle>Home</PageTitle>

	<h1>Hello, User ;)</h1>

	<p style="font-size: 25px;">Welcome to the Frontend <strong><em>Movie Catalog Application</em></strong>.</p>
	<p> Select what you want to view using "Backend ASP.Net Core Web API": </p>
	```
	
	At **Sidebar.razor:**

	```razor
	@* Shared/Sidebar.razor *@

	<nav id="sidebar">
		<h3>Movie Catalog Frontend</h3>

		<ul>
			<li><NavLink class="nav-link" href="/">Home</NavLink></li>
			<li><NavLink class="nav-link" href="/all-movies">All Movies</NavLink></li>
			<li><NavLink class="nav-link" href="/top-rated">Top Rated Movie(s)</NavLink></li>
			<li><NavLink class="nav-link" href="/rated">Rated Movie</NavLink></li>
			<li><NavLink class="nav-link" href="/yearDescendingOrder">Descending order by year</NavLink></li>
			<li><NavLink class="nav-link" href="/genre">Genre Movie(s) List</NavLink></li>
			<li><NavLink class="nav-link" href="/IdTitleGenre">Displaying Id, Title and Genre only</NavLink></li>
			<li><NavLink class="nav-link-green" href="/createNewPage">Create a new page</NavLink></li>
			<li><NavLink class="nav-link-orange" href="/update-movie">Update Movie</NavLink></li>
			<li><NavLink class="nav-link-red" href="/delete-movie">Delete Movie</NavLink></li>
		</ul>
	</nav>

	
	@code {

	}
	```

<a id="all-movies-impl"></a>
* ### All Movies:
	That was my first page where I wanted to retrieve data for first time and I had encountered this specific issue. That was happening because of the “CORS” (Cross-Origin Resource Sharing). It’s a browser security feature that controls how web pages can request resources (like APIs, images, or data) from a different origin (domain, port, or protocol) than the one the page was loaded from. In my case it was blocking access to this API in frontend calls. To solve this issue I have to add unblocking code to the **Program.cs** file in the *“MovieCatalog”* backend version.

	<img src="./Screenshots_Readme/Screenshot 3.jpg" width="60%"/>
	<br/><br/>

	In the MovieCatalog (backend) project in the **Program.cs** I have to allow requests from my Blazor client origin to access this API in backend calls as follows:

	```csharp
	// some code above 

	// Register EF Core with InMemory database
            builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("MovieCatalogDb"));  // Use InMemory "MovieCatalogDb" while app is running
	
	// CORS: allow requests from your Blazor client origin to access this API in frontend calls
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowBlazorClient", policy =>
                {
                    policy.WithOrigins("http://localhost:5269")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                    // .AllowCredentials(); // enable only if you need cookies/credentials
                });
            });
	```
	Then Enable the **CORS** also in **Progarm.cs** at backend version:

	```csharp
	// some code above

	app.UseHttpsRedirection();

	// Enable CORS BEFORE authorization and before mapping controllers
            app.UseCors("AllowBlazorClient");
	```

	Then I could finaly see the **All Movies** in my Frontend project as expected:

	<img src="./Screenshots_Readme/Screenshot 2.jpg" width="60%"/>
	<br/><br/>

	The code for this is at following files:
	
	At **MovieServices.cs:**

	```csharp
	// Get all movies from backend
       public async Task<List<Movie>> GetAllMoviesAsync()
       {
           var result = await _httpClient.GetFromJsonAsync<List<Movie>>(_baseUrl); // fetch data from backend
           return result ?? new List<Movie>(); // "??" - null coalescing opeator - If result is not null, return result; otherwise, return a new empty List<Movie>
       }
	```
	
	At **AllMovies.razor:**
	
	```razor
	@page "/all-movies"

	@inject MovieService MovieService

	<PageTitle>All Movies</PageTitle>

	@* <nav id="back-to-home">
		<NavLink class="nav-link" href="/">Back to Home</NavLink>
	</nav> *@

	<h1 class="page_title">Movie Catalog List:</h1>


	@if (movies == null)
	{
		<p>Loading movies...</p>
	}

	else if(!movies.Any())
	{
		<p>No movies found.</p>
	}
	else
	{
		<table>
			<thead>
				<tr>
					<th>Id</th>
					<th>Title</th>
					<th>Genre</th>
					<th>Year</th>
					<th>Rating</th>
				</tr>
			</thead>
			<tbody>
		
				@foreach(var movie in movies)
				{
					<tr>
						<td>@movie.Id</td>
						<td>@movie.Title</td>
						<td>@movie.Genre</td>
						<td>@movie.Year</td>
						<td>@movie.Rating</td>
					</tr>
				}
			</tbody>
		</table>
	}


	@code {

		// Field to hold the list of movies
		private List<Movie>? movies;

		// OnInitializedAsync method to fetch movies when the component initializes
		protected override async Task OnInitializedAsync()
		{
			// Fetch all movies using the MovieService injected service
			movies = await MovieService.GetAllMoviesAsync();
		}

	}

	```

<a id="top-rated-movies-impl"></a>
* ### Top Rated Movie(s):
	The code for this page is at following files:

	At **MovieServices.cs:**
	```csharp
	// Get by top-rated movies, default is 1
        public async Task<List<Movie>> GetTopRatedMovieAsync(int count = 1)
        {
            return await _httpClient.GetFromJsonAsync<List<Movie>>($"{_baseUrl}/top-rated?count={count}") ?? new List<Movie>();

        }
	```

	At **TopRated.razor:**
	
	```razor
	@page "/top-rated"

	@inject MovieService MovieService

	<PageTitle>Top Rated Movie(s)</PageTitle>

	<h1 class="page_title"> Displaying Top Rated Movie(s): </h1>

	<div>
		<label>Please provide the number of movies to display as top rated from our database: </label>
		<input type="text" placeholder="1" min="0" style="width: 30px" @bind="topRatedInput"/>
		<br /><br />
		<button @onclick="GetTopRatedMovie" class="nav-link">Check</button>
	</div>

	<br>

	@if(!string.IsNullOrEmpty(errorMessage))
	{
		<p style="color: red;">@errorMessage</p>
	}

	@if(movies == null)
	{
		<p>No data yet. Please select a number and click "Check".</p>
	}
	else if(!movies.Any())
	{
		<p>No movies found.</p>
	}
	else
	{
		<table>
			<thead>
				<tr>
					<th>Id</th>
					<th>Title</th>
					<th>Genre</th>
					<th>Year</th>
					<th>Rating</th>
				</tr>
			</thead>
			<tbody>
				@foreach(var movie in movies)
				{
					<tr>
						<td>@movie.Id</td>
						<td>@movie.Title</td>
						<td>@movie.Genre</td>
						<td>@movie.Year</td>
						<td>@movie.Rating</td>
					</tr>
				}
			</tbody>
		</table>
	}



	@code {
		private List<Movie>? movies;    // List of top rated movies
	
		private string? topRatedInput; // If user provide the string instead of integer number
		private int topRated;   // Number of top rated movies to fetch
		private string? errorMessage;   // Error message for invalid input

		private async Task GetTopRatedMovie()
		{
			// Try to parse the user input to an integer
			if (int.TryParse(topRatedInput, out topRated))  // tries to convert the string (e.g. "1") into an integer; if successful, stores the output value in "topRated" variable
			{
				errorMessage = null;    // Clear previous error message if any exists
				movies = await MovieService.GetTopRatedMovieAsync(topRated);    // Fetch top rated movies from the service
			}
			else
			{
				errorMessage = "Please provide a valid number.";    //	Set error message for invalid input
				movies = null;
			}
		}
	}
	```

<a id="rated-movie-impl"></a>
* ### Rated Movie:
	The code for this page is at following files:

	At **MovieServices.cs:**
	```csharp
	// Get movie rating
        public async Task<List<Movie>> GetByRated(double rate_provide)
        {
            return await _httpClient.GetFromJsonAsync<List<Movie>>($"{_baseUrl}/rating?rate_provide={rate_provide}") ?? new List<Movie>();
        }
	```

	At **Rated.razor:**
	
	```razor
	@page "/rated"
	@inject MovieService MovieService

	<PageTitle>Rated Movies</PageTitle>

	<h1 class="page_title"> Displaying Rated Movie: </h1>

	<div>
		<label>Please provide the "movie rate" to see the movie:</label>
		<input type="number" placeholder="8.5" style="width: 40px" @bind="rate"/>
		<br /><br />
		<button class="nav-link" @onclick="GetByRatedAsync">Check</button>
	</div>

	<br />

	@if(movie == null)
	{
		<p>Please select the rating number to display the movie.</p>
	}
	else if(!movie.Any())
	{
		<p>No movie found.</p>
	}
	else
	{
		<table>
			<thead>
				<tr>
					<th>Id</th>
					<th>Title</th>
					<th>Genre</th>
					<th>Year</th>
					<th>Rating</th>
				</tr>
			</thead>
			<tbody>
				@foreach(var m in movie)
				{
					<tr>
						<td>@m.Id</td>
						<td>@m.Title</td>
						<td>@m.Genre</td>
						<td>@m.Year</td>
						<td>@m.Rating</td>
					</tr>
				}
			</tbody>
		</table>
	}

	@code {
		private List<Movie>? movie;
		private double rate;

		private async Task GetByRatedAsync()
		{
			movie = await MovieService.GetByRated(rate);
		} 
	}

	```

<a id="descending-order-by-year-impl"></a>
* ### Descending order by year:
	The code for this page is at following files:

	At **MovieServices.cs:**
	```csharp
	// Get all movies in descending order by year
        public async Task<List<Movie>> GetMovieByDescendingOrder()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Movie>>($"{_baseUrl}/descending-order-by-year");
            return result ?? new List<Movie>();
        }
	```

	At **YearDescendingOrder.razor:**
	
	```razor
	@page "/yearDescendingOrder"
	@inject MovieService MovieService

	<PageTitle>Movies by Year Descending Order</PageTitle>

	<h1 class="page_title">Displaying movies list in descending order by year:</h1>

	@if (movies == null)
	{
		<p>Loading...</p>
	}
	else if (!movies.Any())
	{
		<p>There is no movie in database.</p>
	}
	else
	{
		<table>
			<thead>
				<tr>
					<th>Id</th>
					<th>Title</th>
					<th>Genre</th>
					<th>Year</th>
					<th>Rating</th>
				</tr>
			</thead>
			<tbody>
				@foreach(var m in movies)
				{
					<tr>
						<td>@m.Id</td>
						<td>@m.Title</td>
						<td>@m.Genre</td>
						<td>@m.Year</td>
						<td>@m.Rating</td>
					</tr>
				}
			</tbody>
		</table>
	}

	@code {
		private List<Movie>? movies;

		protected override async Task OnInitializedAsync()
		{
			movies = await MovieService.GetMovieByDescendingOrder();
		}
	}
	```

<a id="genre-movie-list-impl"></a>
* ### Genre Movie(s)List:
	The code for this page is at following files:

	At **MovieServices.cs:**
	```csharp
	// Get movie by genre
        public async Task<List<Movie>> GetMovieByGenre(string genre)
        {
            return await _httpClient.GetFromJsonAsync<List<Movie>>($"{_baseUrl}/genre/{genre}") ?? new List<Movie>();
        }
	```

	At **Genre.razor:**
	
	In this page I have also added error handling for HttpRequestException in case if the backend API is not reachable issues occur. I understand that this is not a good practice to catch the exceptions in the UI layer , but for simplicity I have implemented it here. In a real-world application, it would be better to handle such exceptions in the service layer and return error messages or status codes to the UI.
	
	```razor
	@page "/genre"
	@inject MovieService MovieService

	<PageTitle>Genre Movies</PageTitle>

	<h1 class="page_title">Displaying Movies by "Genre":</h1>

	<div>
		<label>Please enter "genre" of movie to display below:</label>
		<input type="text" placeholder="e.g. comedy" style="width: 80px" @bind="genreInput" />
		<br /><br />
		<button class="nav-link" @onclick="GetMovieByGenreAsync">Check</button>
	</div>

	<br />

	@if(movie == null)
	{
		<p>Please enter the "genre" to display movie(s) below:</p>
	}
	else if (!movie.Any())
	{
		<p>No movie found.</p>
	}
	else
	{
		<table>
			<thead>
				<tr>
					<th>Id</th>
					<th>Title</th>
					<th>Genre</th>
					<th>Year</th>
					<th>Rating</th>
				</tr>
			</thead>
			<tbody>
				@foreach(var m in movie)
				{
					<tr>
						<td>@m.Id</td>
						<td>@m.Title</td>
						<td>@m.Genre</td>
						<td>@m.Year</td>
						<td>@m.Rating</td>
					</tr>
				}
			</tbody>
		</table>
	}

	@code {

		private List<Movie>? movie;
		private string? genre;
		private string? genreInput;
		private string? error; // To hold error message

		private async Task GetMovieByGenreAsync()
		{
			try
			{
				genre = genreInput ?? string.Empty; // Assign input or empty string
				movie = await MovieService.GetMovieByGenre(genre);  // Fetch movies by genre
				error = null;   // Clear previous error message if any
			}
			catch (HttpRequestException ex)
			{
				error = ex.Message; // Set error message
				movie = new List<Movie>();	// Set movie to empty list on error
			}
		}
	
	}
	```

<a id="displaying-id-title-genre-impl"></a>
* ### Displaying Id, Title and Genre:
	The code for this page is at following files:

	At **MovieService:**
	```csharp
	// Get movie by Id, title, and genre with error BadRequest handling in frontend

        public async Task<(List<Movie> Movies, string? ErrorMessage)> GetMovieByIdTitleGenre(int id_selected)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/id/title/genre/{id_selected}");  // Send GET request

                if (response.IsSuccessStatusCode)
                {
                    var movies = await response.Content.ReadFromJsonAsync<List<Movie>>();   // Deserialize (convert JSON to object) in successful response
                    return (movies ?? new List<Movie>(), null); // return movie or empty list
                }
                else
                {
                    // Read the "backend BadRequest" message
                    var errorMessage = await response.Content.ReadAsStringAsync();  // Read error (BadRequest) message from response
                    return (new List<Movie>(), errorMessage);   // return empty list with error message
                }
            }
            catch (Exception ex)
            {
                return (new List<Movie>(), ex.Message); // return empty list with exception message
            }
        }
	```

	At **IdTitleGenre.razor:**
	```razor
	@page "/IdTitleGenre"
	@inject MovieService MovieService

	<PageTitle>IdTitleGenre</PageTitle>

	<h1 class="page_title">Displaying Id, Title and Genre:</h1>

	<div>
		<label>Please enter the "Id" to display Id, Title and Genre of movie:</label>
		<input type="number" placeholder="e.g. 2" style="width: 50px" @bind="inputUser"/>
		<br /><br />
		<button class="nav-link" @onclick="GetIdTitleGenreByIdAsync">Check</button>
	</div>

	@if(movie == null)
	{
		<p>Please enter "Id" </p>
	}
	else if (movie.Count() <= 0)
	{
		<p>No movie found.</p>
	}
	else
	{
		<table>
			<thead>
				<tr>
					<th>Id</th>
					<th>Title</th>
					<th>Genre</th>
				</tr>
			</thead>
			<tbody>
				@foreach(var m in movie)
				{
					<tr>
						<td>@m.Id</td>
						<td>@m.Title</td>
						<td>@m.Genre</td>
					</tr>
				}
			</tbody>
		</table>
	}
	@if (!string.IsNullOrEmpty(badRequest))  // Display BadRequest message if exists
	{
		<p style="color: red">@badRequest</p>
	}


	@code {
		
		// Enhanced version with error handling including BadRequest (400) handling after updating MovieService.cs method "GetMovieByIdTitleGenre"
		private List<Movie>? movie;
		private int inputUser;
		private string? badRequest; // to hold BadRequest message

		private async Task GetIdTitleGenreByIdAsync()
		{
			var result = await MovieService.GetMovieByIdTitleGenre(inputUser);

			movie = result.Movies;  // set movie list - the "Movies" is from MovieService.cs "GetMovieByIdTitleGenre" method return type.
			badRequest = result.ErrorMessage; // set error message to display in UI
		}	
	}

	```

<a id="create-new-page-impl"></a>
* ### Create New Page:
	The code for this page is at following files:

	I have to modify the **HttpPost** backend endpoint to return the validations with **BadRequest** for incase if user would enter:
	
	* negative number, 
	* already existing one
	
	At **MoviesController.cs** (backend):
	
	```csharp
	// POST: api/Movies
        // Create new Movie - Upgraded version (with validation)
        [HttpPost("create-new-movie")]
        public ActionResult CreateMovie(Movie newMovie)
        {
            // Ensure Id is non-negative and not equal to 0.
            if (newMovie.Id <= 0)
            {
                return BadRequest("Invalid Id. Id must be greater and not equal to 0.");
            }

            // Check if a movie with this Id already exists
            if (_dbContext.Movies.Any(m => m.Id == newMovie.Id))
            {
                return BadRequest($"The movie with Id: '{newMovie.Id}' already exists.");
            }

            // Save new movie to the database
            _dbContext.Movies.Add(newMovie);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetAllMovies), new { id = newMovie.Id }, newMovie);
        }
	```

	Then at **MovieServices.cs:** (frontend)
	
	```csharp
	// Create a new movie (POST) - corrected version with error handling
        public async Task<(Movie? existMovie, string? error)> CreateMovieAsync(Movie newMovie) // tuple return type
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/create-new-movie", newMovie);

                if (response.IsSuccessStatusCode)
                {
                    var existMovie = await response.Content.ReadFromJsonAsync<Movie>(); // Deserialize created movie (convert JSON to object)
                    return (existMovie, null); // return created movie with no error
                }
                else
                {
                    // Read the "backend BadRequest" message
                    var errorMessage = await response.Content.ReadAsStringAsync();  // Read error (BadRequest) message from response
                    return (null, errorMessage);   // return null movie with error message
                }
            }
            catch(Exception ex)
            {
                return (null, ex.Message); // return null movie with exception message
            }
        }
	```

	At **CreateNewPage.razor:**
	
	```razor
	@page "/createNewPage"
	@inject MovieService MovieService

	<PageTitle>New Page</PageTitle>

	<h1 class="page_title">Creating "New Page"</h1>

	<p>Please fill the following fields to create a new page:</p>

	<div class="movie-grid-div">
		<label for="id">Id: </label>
		<input type="number" name="id" required style="width: 50px" @bind="id" />

		<label for="title">Title:</label>
		<input type="text" name="title" style="width: 100px" @bind="title" />

		<label for="genre">Genre:</label>
		<input type="text" name="genre" style="width: 100px" @bind="genre" />

		<label for="year">Year:</label>
		<input type="number" name="year" style="width: 50px" @bind="year" />

		<label for="rating">Rating:</label>
		<input type="number" name="rating" style="width: 50px" @bind="rating" />

		<button class="nav-link-green" @onclick="CreateNewMovieAsync">Create</button>
	</div>

	@if (!string.IsNullOrEmpty(badRequest))
	{
		<p style="color: red">@badRequest</p>
	}
	else if (createdMovie != null)
	{
		<p>The new movie with Id: <strong>'@createdMovie?.Id'</strong> has been created successfully and added to the movie list.</p>
	}



	@code {
		private int id;
		private string? title;
		private string? genre;
		private int year;
		private double rating;

		private Movie? createdMovie;    // The newly created movie
		private string? badRequest;

		private async Task CreateNewMovieAsync()
		{
			// Create a new Movie object with the provided details
			var newMovie = new Movie
			{
				Id = id,
				Title = string.IsNullOrWhiteSpace(title) ? "'No Title entered'" : title,
				Genre = string.IsNullOrWhiteSpace(genre) ? "'No Genre entered'" : genre,
				Year = year,
				Rating = rating,
			};


			// Call the service to create the new movie
			var result = await MovieService.CreateMovieAsync(newMovie); // Assuming CreateMovieAsync returns an object with existMovie and error properties
			createdMovie = result.existMovie; // If the movie already exists, this will be set
			badRequest = result.error; // If there was a bad request error, this will be set

			// Reset fields ONLY if there was no error
			if(badRequest == null)	// No error occurred
			{
				id = 0;
				title = string.Empty;
				genre = string.Empty;
				year = 0;
				rating = 0;
			}
			
			// Ensure the "id" is non-negative
			else if (id < 0)
			{
				id = 0;
			}

		}
	}
	```

<a id="update-movie-impl"></a>
* ### Update Movie:
	The code for this page is at following files:

	After checking frontend I encounter the issue that I not allowed to enter empty strings in **Title** and **Genre** or **0** in **Year** and **Rating** fields. All I had to do was modify the backend **HttpPut** endpoint at **MoviesController.cs**(for enter empty strings) and **Movie.cs** model (to allow except 0).

	At **MoviesController.cs** (backend):
	
	```csharp
	// PUT: api/Movies/{id}
        // Update Movie
        [HttpPut("update_movie/{id}")]
        public ActionResult UpdateMovie(int id, Movie updateMovie)
        {
            var existingMovie = _dbContext.Movies.Find(id);

            // if movie not exist return not found
            if (existingMovie == null)
            {
                return NotFound();
            }

            // Only update fields if they are provided (not default/null/empty)
            if (!string.IsNullOrWhiteSpace(updateMovie.Title) && updateMovie.Title != "string" || updateMovie.Title == string.Empty) // Accept only a non-empty, non-whitespace and non-default "string" title or empty string(null)
                existingMovie.Title = updateMovie.Title;

            if (!string.IsNullOrWhiteSpace(updateMovie.Genre) && updateMovie.Genre != "string" || updateMovie.Genre == string.Empty)
                existingMovie.Genre = updateMovie.Genre;

            // For Year and Rating, we check if is not negative if so we set to 0 otherwise update into provided value
            if (updateMovie.Year <= 0)
            {
                existingMovie.Year = 0;
            }
            else if (updateMovie.Year != default)   // default(int) is 0
            {
                existingMovie.Year = updateMovie.Year;
            }

            if (updateMovie.Rating <= 0)
            {
                existingMovie.Rating = 0;
            }
            else if (updateMovie.Rating != default)	  // default(double) is 0.0
            {
                existingMovie.Rating = updateMovie.Rating;
            }

            _dbContext.SaveChanges();
            return Ok(existingMovie);
        }
	```

	At **Movie.cs** (backend):
	
	```csharp
	namespace MovieCatalog.Models
	{
		public class Movie
		{
			// Properties of the Movie class
			public int Id { get; set; }
			public string Title { get; set; } = "";
			public string Genre { get; set; } = "";
			public int? Year { get; set; }	// Changed to nullable int to allow 0 value
			public double? Rating { get; set; }	// Changed to nullable double to allow 0.0 value
		}
	}

	```

	At **MovieServices.cs:** (frontend)
	
	```csharp
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
	```

	At **UpdateMovie.razor:**
	
	```razor
	@page "/update-movie"
	@inject MovieService MovieService

	<h1 class="page_title">Movie To Update:</h1>

	<div id="movie-grid">
		<label>Please enter the <strong>"Id"</strong> of the movie which you want to update:</label>
		<input type="number" placeholder="e.g. 1" style="width: 70px" required @bind="userInput" />
		<br /><br />
		<button class="nav-link" @onclick="CheckMovie">Check</button>
	</div>

	@if (existingMovie != null)
	{
		<EditForm Model="@existingMovie" OnValidSubmit="UpdateAndSubmit">	@* Bind the form to "existingMovie" and handle submission *@
			<DataAnnotationsValidator /> @* Enable validation based on data annotations (Data annotations are validation rules applied to the properties of your model(Movie.cs)). *@

			<div class="movie-grid-div">

				<label for="id">Id: </label>
				<input type="number" id="id" @bind="existingMovie.Id" readonly />

				<label for="title">Title: </label>
				<input type="text" id="title" @bind="existingMovie.Title" />

				<label for="genre">Genre: </label>
				<input type="text" id="genre" @bind="existingMovie.Genre" />

				<label for="year">Year: </label>
				<input type="number" id="year" @bind="existingMovie.Year" />

				<label for="rating">Rating: </label>
				<input type="number" id="rating" step="0.1" @bind="existingMovie.Rating" />

				<button type="submit" class="nav-link-orange">Save Changes</button>
				<br /><br />			

			</div>

		</EditForm>
	}

	@if (!string.IsNullOrWhiteSpace(messageSuccess))
	{
		<p style="color: green">@messageSuccess</p>
	}

	@if (!string.IsNullOrWhiteSpace(messageNegat))
	{
		<p style="color: red">@messageNegat</p>
	}

	@code {
		private Movie? existingMovie;
		private int userInput;

		private string? messageSuccess;
		private string? messageNegat;

		private async Task CheckMovie()
		{
			// clear previous messages if any exists
			messageSuccess = null;
			messageNegat = null;

			// validate user input
			if (userInput <= 0)
			{
				messageNegat = "Invalid Id. Please enter the 'id' greater than 0.";
				existingMovie = null;
				userInput = 0;
				return; // exit the method if input is invalid and prevents adding other remaining messages which are left in this method
			}

			/*
				IMPORTANT NOTE:

				* This fetching solution is only provided because this project has only a few movies in database.

				* In a real-world application, I would typically have an implemented a new method in the backend e.g. (GetMovieById(int id))
				  to prevent fetching all movies from the database just to find one movie by its id.

				* Then integrate this method in "MovieService.cs" in frontend(as others methods from backend), then call that service in razor file to fetch a movie by "id".

			*/

			// fetch all movies and check if movie with given "id" exists
			var movies = await MovieService.GetAllMoviesAsync();
			existingMovie = movies.FirstOrDefault(m => m.Id == userInput);

			// set negative message if movie not found
			if (existingMovie == null)
			{
				messageNegat = $"Movie with id {userInput} not found.";
				userInput = 0;
			}
		}

		private async Task UpdateAndSubmit()
		{
			if (existingMovie != null)
			{
				await MovieService.UpdateMovieAsync(existingMovie.Id, existingMovie);   // Call the service to update the movie

				messageSuccess = $"The movie of id: '{existingMovie.Id}' is updated successfully.";

				// hide the "EditForm" content but keep the success message visible
				existingMovie = null;
				userInput = 0;
				return;
			}
		}
	}
	```

<a id="delete-movie-impl"></a>
* ### Delete Movie:
	The code for this page is at following files:

	At **MovieServices.cs:**
	
	```csharp
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
	```

	At **DeleteMovie.razor:**
	
	```razor
	@page "/delete-movie"
	@inject MovieService MovieService

	<PageTitle>Delete Movie</PageTitle>

	<h1 class="page_title">Delete Movie:</h1>

	<p>Please select the <strong>"Movie"</strong> which you want to delete:</p>
	<br />
	<br />

	@if(allMovies == null)
	{
		<p>Loading...</p>
	}
	else if (!allMovies.Any())
	{
		<p>No movie found.</p>
	}
	else
	{
		<table>
			<thead>
				<tr>
					<td>Id</td>
					<td>Title</td>
					<td>Genre</td>
					<td>Year</td>
					<td>Rating</td>
					<td>Delete</td>
				</tr>
			</thead>
			<tbody>
				@foreach (var m in allMovies)
				{
					<tr>
						<td>@m.Id</td>
						<td>@m.Title</td>
						<td>@m.Genre</td>
						<td>@m.Year</td>
						<td>@m.Rating</td>
						<td>
							<button class="nav-link-red" @onclick="() => DeleteMovie(m.Id)">Delete</button>	@* lambda expression added because it allows passing parameters to the method *@
						</td>
					</tr>
				}
			</tbody>
		</table>
	}

	@code {
		private List<Movie>? allMovies; // List to hold all movies

		// OnInitializedAsync method to fetch movies when the component initializes
		protected override async Task OnInitializedAsync()
		{
			allMovies = await MovieService.GetAllMoviesAsync();
		}

		// delete the movie
		private async Task DeleteMovie(int id)
		{
			bool deleted = await MovieService.DeleteMovieAsync(id);

			if (deleted)
			{
				// Refresh the movie list after deletion
				allMovies = await MovieService.GetAllMoviesAsync();
			}
		}
	}

	```

<a id="summary"></a>
## Summary
This project is an educational full-stack movie catalog application built with ASP.NET Core Web API and Blazor WebAssembly. It provides an interface for managing movies, including adding, editing, viewing, and deleting entries. The project focuses on understanding HTTP communication, UI state handling, and backend integration. It serves as a learning exercise for exploring the fundamentals of .NET development.

<a id="api-documentation"></a>
## API Documentation
The MovieCatalog_Frntend application interacts with the MovieCatalog Web API. For more information about the API endpoints and usage, please refer to the [API Documentation](https://github.com/your-username/MovieCatalog).

<a id="license"></a>
## License
This project is created for educational and learning purposes only.