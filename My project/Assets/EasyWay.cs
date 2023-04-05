using System.Collections;
using System.Collections.Generic;

namespace EasyWay
{
    using UnityEngine;
    public abstract class InstanceBeh<TObj> : MonoBehaviour where TObj : MonoBehaviour
    {
        public static TObj Instance;
        public static void SetInstance()
        {
           Instance = Instance != null ? Instance : FindObjectOfType<TObj>();
        }
    }
    public abstract class InstanceCache<TCache> : MonoCache where TCache : MonoCache
    {
        public static TCache Instance;
        public static void SetInstance()
        {
            Instance = Instance != null ? Instance : FindObjectOfType<TCache>();
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
