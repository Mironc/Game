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
namespace Tools.Timer
{
    struct Timer
    {
        
    }
}
namespace Tools.serialize
{
    using System.Runtime.Serialization.Formatters.Binary;
    using System.IO;
    public sealed class serialize : FastCut
    {
        
        public object LoadData(string DataName)
        {
            if(File.Exists(Application.persistentDataPath + "/" + DataName + ".dat"))
            {
                BinaryFormatter Formatter = new BinaryFormatter();
                FileStream DataHandler = File.Open(Application.persistentDataPath + "/" + DataName + ".dat",FileMode.Open);
                object data = Formatter.Deserialize(DataHandler);
                DataHandler.Close();
                return data;
            }
            else return null;
        }
        public void SaveData(string DataName,object Data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream Handler = File.Open(Application.persistentDataPath + "/" + DataName + ".dat", FileMode.OpenOrCreate);
            formatter.Serialize(Handler,Data);
            Handler.Close();
        }
    }
}


