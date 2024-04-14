using System;
using UnityEngine;

namespace Core
{
    public class Singleton<T> : MonoBehaviour where T: Singleton<T>
    {
        public static T Instance { get; private set; }
        public virtual void Awake()
        {
            if (Instance)
            {
                Destroy(this);
                return;
            }

            Instance = (T)this;
            DontDestroyOnLoad(this);
        }
    }
}