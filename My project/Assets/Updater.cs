using System;
using System.Collections.Generic;
using UnityEngine;
using EasyWay;

public class Updater : InstanceBeh<Updater>
{ 
    [SerializeField]private List<IUpdate> Updates = new List<IUpdate>(100);
    [SerializeField]private List<ILateUpdate> LateUpdates = new List<ILateUpdate>(100);
    [SerializeField]private List<IFixedUpdate> FixedUpdates = new List<IFixedUpdate>(100);
    private void OnEnable()
    {
        SetInstance();
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
        if(this.LateUpdates.Count == 0) throw new Exception("Count Update = 0");
        for (int i = 0; i < this.Updates.Count; i++)
        {
            this.Updates[i].Tick();
        }
    }
    private void LateUpdate()
    {
        if(this.LateUpdates.Count == 0) throw new Exception("Count LateUpdate = 0");
        for (int i = 0; i < this.LateUpdates.Count; i++)
        {
            this.LateUpdates[i].LateTick();
        }
    }
    private void FixedUpdate()
    {
        if(this.LateUpdates.Count == 0) throw new Exception("Count FixedUpdate = 0");
        for (int i = 0; i < this.FixedUpdates.Count; i++)
        {
            this.FixedUpdates[i].FixedTick();
        }
    }
}
