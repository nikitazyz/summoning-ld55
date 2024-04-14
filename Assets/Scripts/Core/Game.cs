using ResourceManagement;
using UnityEngine;

namespace Core
{
    public class Game : Singleton<Game>
    {
        [SerializeField] private ResourceInfoManager _resourceInfoManager;
        private ResourceBank _resourceBank = new ResourceBank();

        public ResourceInfoManager ResourceInfoManager => _resourceInfoManager;
        public ResourceBank ResourceBank => _resourceBank;
    }
}