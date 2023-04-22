using UnityEngine;
using Object = UnityEngine.Object;
using System;

namespace Tools
{
    public abstract class Instancer<InstanceObjectType> : FastCut where InstanceObjectType : FastCut
    {
        private static InstanceObjectType CachedInstance;
        public static InstanceObjectType Instance
        {
            get
            {
                return CachedInstance;
            }
        }
        public static void SetInstance()
        {
            InstanceObjectType[] AllInstances = FindObjectsOfType<InstanceObjectType>();
            if(AllInstances.Length > 1)
            {
                for (int i = 1; i < AllInstances.Length; i++)
                {
                    Destroy(AllInstances[i]);
                }
            }
            CachedInstance = AllInstances[0];
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
namespace Tools.п
{

}


