using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoCache : MonoBehaviour
{
    public static List<MonoCache> Updates = new List<MonoCache>(100);
    public static List<MonoCache> LateUpdates = new List<MonoCache>(100);
    public static List<MonoCache> FixedUpdates = new List<MonoCache>(100);
    private void OnEnable() => Updates.Add(this);
    private void OnDisable() => Updates.Remove(this);
    private void OnDestroy() => Updates.Remove(this);
    private void Add()
    {

    }
    public void LateTick() => OnLateTick();
    public virtual void OnLateTick(){}
    public void FixedTick() => OnFixedTick();
    public virtual void OnFixedTick(){}
    public void Tick() => OnTick();
    public virtual void OnTick(){}
}
