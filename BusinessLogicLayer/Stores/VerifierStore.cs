using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Stores
{
    public class VerifierStore: IVerifierStore
    {
        private readonly ConcurrentDictionary<string, string> _store = [];

        public void StoreVerifier(string state, string verifier)
        {
            _store[state] = verifier;
        }
        public string? GetVerifier(string state)
        {
            if(_store.TryGetValue(state, out var verifier))
            {
                // _store.TryRemove(state, out _);
                return verifier;
            }

            return null;
        }
    }
}
