namespace BET.Services.Repositories
{
    public class TransactionEventArgs : EventArgs
    {
        public bool Cancel { get; set; } = false;
    }
}
