using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyWay;

public abstract class MonoCache : FastCut, IUpdate, ILateUpdate, IFixedUpdate
{
    private void OnEnable()
    {
        Add();

    }
    protected virtual void OnEnable_()
    { }
    protected virtual void OnDisable_()
    { }
    private void OnDisable()
    {
        Remove();
    }
    private void Add()
    {
        Updater.Instance.AddFixedUpdate(this);
        Updater.Instance.AddLateUpdate(this);
        Updater.Instance.AddUpdate(this);
    }
    private void Remove()
    {
        Updater.Instance.DelFixedUpdate(this);
        Updater.Instance.DelLateUpdate(this);
        Updater.Instance.DelUpdate(this);
    }
    public virtual void Tick() { }
    public void RunTick() => Tick();
    public virtual void LateTick() { }
    public void RunLateTick() => LateTick();

    public virtual void FixedTick() { }
    public void RunFixedTick() => FixedTick();

}
