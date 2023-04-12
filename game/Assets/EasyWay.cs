using UnityEngine;
using Object = UnityEngine.Object;
using System;

namespace Tools
{
    public abstract class InstanceBeh<TObj> : MonoBehaviour where TObj : MonoBehaviour
    {
        private static TObj CachedInstance;
        public static TObj Instance
        {
            get
            {
                return CachedInstance;
            }
        }
        public static void SetInstance()
        {
            CachedInstance = CachedInstance != null ? CachedInstance : FindObjectOfType<TObj>();
            
        }
        private static void CheckInstance()
        {
            if (Instance == null) throw new NullReferenceException();
        }
    }
    public abstract class FastCut : MonoBehaviour
    {
        public T Get<T>() => GetComponent<T>();
        public T[] Gets<T>() => GetComponents<T>();
        public T Find<T>() where T : Object => FindObjectOfType<T>();
        public T[] Finds<T>() where T : Object => FindObjectsOfType<T>();
        public T GetChild<T>() => GetComponentInChildren<T>();
        public T[] GetsChild<T>() => GetComponentsInChildren<T>();
        public T GetParent<T>() => GetComponentInParent<T>();
        public T[] GetsParent<T>() => GetComponentsInParent<T>();
    }
}


