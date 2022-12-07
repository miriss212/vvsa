using web.DatabaseModel;
using web.Repository;

namespace web.Service;
public class TransactionService : ITransactionService{

    private readonly ITransactionRepository transactionRepository;
    


    public TransactionService(ITransactionRepository transactionRepository){
        this.transactionRepository = transactionRepository;
    }

    public List<TransactionViewModel> GetAllTransactions()
    {
        //return this.context.Transactions.ToList();
        var transactions = transactionRepository.GetAllTransactions();
        List<TransactionViewModel> transactionsVm = new List<TransactionViewModel>();
        
        foreach (var transaction in transactions)
        {   
            TransactionViewModel transactionVm = new TransactionViewModel();
            transactionVm.accountNumber = transaction.AccountNumber;
            transactionVm.BankCode = transaction.BankCode;
            transactionVm.FullName = transaction.User.Name;
            transactionVm.Amount = transaction.Amount;
            transactionVm.IssueDate = transaction.IssueDate;
            transactionVm.TransactionType = transaction.TransactionType.Name;
            transactionsVm.Add(transactionVm);
        }

        return transactionsVm;
    }
    public TransactionViewModel GetTransactionById(int id)
    {
        TransactionViewModel transactionsVm = new TransactionViewModel();
        var transaction = transactionRepository.GetTransactionById(id);

        transactionsVm.accountNumber = transaction.AccountNumber;
        transactionsVm.BankCode = transaction.BankCode;
        transactionsVm.FullName = transaction.User.Name;
        transactionsVm.Amount = transaction.Amount;
        transactionsVm.IssueDate = transaction.IssueDate;
        transactionsVm.TransactionType = transaction.TransactionType.Name;


        return transactionsVm;
    }

}