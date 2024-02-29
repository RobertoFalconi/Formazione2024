using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WebApplication9.Models;

namespace WebApplication9.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly HttpClient _httpClient;
    private readonly IPersonaService<PersonaItaliaService> _personaItaliaService;
    private readonly IPersonaService<PersonaFranciaService> _personaFranciaService;

    public HomeController(ILogger<HomeController> logger, HttpClient httpClient, 
        IPersonaService<PersonaItaliaService> personaItaliaService, 
        IPersonaService<PersonaFranciaService> personaFranciaService)
    {
        _logger = logger;
        _httpClient = httpClient;
        _personaItaliaService = personaItaliaService;
        _personaFranciaService = personaFranciaService;
    }

    public async Task<IActionResult> Index()
    {

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> _ListPersone()
    {
        var url = "https://localhost:7256/api/Persona";
        var response = await _httpClient.GetAsync($"{url}");
        _ = response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();

        var persone = JsonConvert.DeserializeObject<List<PersonaViewModel>>(responseString);

        ViewBag.Count = persone?.Count;

        return PartialView(persone);
    }

    [HttpGet]
    public IActionResult _FormPersona()
    {
        //var persona = new PersonaViewModel();
        
        return PartialView();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
