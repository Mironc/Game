using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Updater : MonoBehaviour
{
    private readonly List<IUpdate> Updates = new List<IUpdate>(100);
    private readonly List<ILateUpdate> LateUpdates = new List<ILateUpdate>(100);
    private readonly List<IFixedUpdate> FixedUpdates = new List<IFixedUpdate>(100);
    public static Updater Instance;
    private void Awake() 
    {
        Instance = Instance == null ? this : Instance;
    }
    public void AddUpdate(IUpdate Update)
    {
        Updates.Add(Update);
    }
    public void AddLateUpdate(ILateUpdate LateUpdate)
    {
       LateUpdates.Add(LateUpdate);
    }
    public void AddFixedUpdate(IFixedUpdate FixedUpdate)
    {
        FixedUpdates.Add(FixedUpdate);
    }
    public void DelUpdate(IUpdate Update)
    {
        Updates.Remove(Update);
    }
    public void DelLateUpdate(ILateUpdate LateUpdate)
    {
       LateUpdates.Remove(LateUpdate);
    }
    public void DelFixedUpdate(IFixedUpdate FixedUpdate)
    {
        FixedUpdates.Remove(FixedUpdate);
    }
    private void Update()
    {
        for (int i = 0; i < this.Updates.Count; i++)
        {
            this.Updates[i].Tick();
        }
    }
    private void LateUpdate()
    {
        for (int i = 0; i < this.LateUpdates.Count; i++)
        {
            this.LateUpdates[i].LateTick();
        }
    }
    private void FixedUpdate()
    {
        for (int i = 0; i < this.FixedUpdates.Count; i++)
        {
            this.FixedUpdates[i].FixedTick();
        }
    }
}
