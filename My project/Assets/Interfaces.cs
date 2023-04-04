using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IDamagable
{
    int Health{get;}
    void GetHealth(int Health,int Heal);
    void GetDamage(int Health,int Damage);
}
public interface ILateUpdate 
{
    void LateTick();    
}
public interface IFixedUpdate
{
    void FixedTick();
}
public interface IUpdate
{
    public void Tick();    
}
interface INeitralEntity : IDamagable 
{
    
}
interface IagressivableEntity : INeitralEntity
{
    
}
