using web.DatabaseModel;
public interface ITransactionService{

    public List<TransactionViewModel>GetAllTransactions();
    public TransactionViewModel GetTransactionById(int id);
}