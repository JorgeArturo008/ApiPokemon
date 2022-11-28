using m = ApiPokemon.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using ApiPokemon.Models;
using System.Net;

namespace ApiPokemon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            string apiResponse = "";
            m.PokemonList results = null;
            m.PokemonTypeList results1 = null;
            
            List<PokemonDetalle> listaDetalles = new List<PokemonDetalle>();

            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync("https://pokeapi.co/api/v2/pokemon?limit=151"))
                {
                   apiResponse = await response.Content.ReadAsStringAsync();
                   results = JsonConvert.DeserializeObject<m.PokemonList>(apiResponse);
                   
                }
            }

            foreach (var item in results.results)
            {

                using (var httpClient2 = new HttpClient())
                {
                    string respuestaDetalle = ApiRequest(item.url);
                        PokemonDetalle detalle = JsonConvert.DeserializeObject<PokemonDetalle>(respuestaDetalle);
                        listaDetalles.Add(detalle);

                    
                }
            }

           
            
            ViewBag.PokemonList = results;
            ViewBag.ListaDetalles = listaDetalles;


            return View();
        }

        private string ApiRequest(string url)
        {
            WebRequest request = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new m.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}