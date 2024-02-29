//using MediatR;
//using WebApplication9WebApi.Models.DB;

//namespace WebApplication9WebApi.Handlers.CommandHandlers;

//public sealed record PostPersonaCommand() : IRequest<IResult>;

//public sealed class PersonaCommandHandler :
//    IRequestHandler<PostPersonaCommand, IResult>
//{
//    private readonly ILogger<PersonaCommandHandler> _logger;

//    private readonly FormazioneDbContext _dbContext;

//    private readonly HttpClient _httpClient;

//    public PersonaCommandHandler(ILogger<PersonaCommandHandler> logger, FormazioneDbContext dbContext, HttpClient httpClient)
//    {
//        _logger = logger;
//        _dbContext = dbContext;
//        _httpClient = httpClient;
//    }

//    public async Task<IResult> Handle(PostPersonaCommand request, CancellationToken cancellationToken)
//    {
//        return Results.Ok();
//    }
//}