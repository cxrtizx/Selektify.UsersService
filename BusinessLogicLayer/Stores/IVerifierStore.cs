namespace BusinessLogicLayer.Stores
{
    public interface IVerifierStore
    {
        void StoreVerifier(string state, string verifier);
        string? GetVerifier(string state);
    }
}
