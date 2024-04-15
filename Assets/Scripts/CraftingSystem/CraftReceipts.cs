using System;
using System.Linq;
using UnityEngine;

namespace CraftingSystem
{
    [CreateAssetMenu]
    public class CraftReceipts : ScriptableObject
    {
        [Serializable]
        public class Receipt
        {
            public ResourceType Type1;
            public ResourceType Type2;
            public ResourceType Type3;
            public GameObject Result;
        }


        [SerializeField] private GameObject _default;
        [SerializeField] private Receipt[] _receipts;

        public GameObject GetObjectByReceipt(ResourceType r1, ResourceType r2, ResourceType r3)
        {
            var el = _receipts.FirstOrDefault(r => r.Type1 == r1 && r.Type2 == r2 && r.Type3 == r3);
            return el == null ? _default : el.Result;
        }
    }
    
    
}