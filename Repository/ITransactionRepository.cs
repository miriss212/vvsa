using web.DatabaseModel;

namespace web.Repository;
public interface ITransactionRepository{

    public List<Transaction>GetAllTransactions();
    public Transaction GetTransactionById(int id);

}