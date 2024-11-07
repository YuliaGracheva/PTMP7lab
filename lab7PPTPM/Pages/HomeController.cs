using lab7PPTPM.Data;
using Microsoft.AspNetCore.Mvc;

public class TestController : Controller
{
    private readonly lab7PPTPMContext _context;
    private readonly ILogger<TestController> _logger;

    public TestController(lab7PPTPMContext context, ILogger<TestController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        try
        {
            var records = _context.Employee.ToList(); // Замените YourDbSet на ваш DbSet
            _logger.LogInformation("Запрос на получение записей выполнен успешно.");
            return View(records);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Ошибка получения записей: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }
}
