using Microsoft.AspNetCore.Mvc;
using web.DatabaseModel;
using web.Service;

namespace web.Controllers;

[ApiController]
[Route("/api/transactions")]

public class TransactionController : ControllerBase
{
    private readonly ILogger<TransactionController> _logger;
    private readonly ITransactionService transactionService;

    public TransactionController(ILogger<TransactionController> logger, ITransactionService transactionService)
    {
        _logger = logger;
        this.transactionService = transactionService;

    }


    [HttpGet(Name = "GetTransactions")]

    public List<TransactionViewModel> GetAll()
    {
        return transactionService.GetAllTransactions();;
    }

    [HttpGet("{id}", Name = "GetTransaction")]
    public TransactionViewModel Get(int id)
    {
        return transactionService.GetTransactionById(id);
    }
}