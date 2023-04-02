using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IDamagable
{
    int Health{get;}
    void GetHealth(int Health,int Heal);
    void GetDamage(int Health,int Damage);
}
interface ILateupdate 
{
    void LateTick();    
}
interface IFixedUpdate
{
    void FixedTick();
}
interface IUpdate
{
    void Tick();    
}
interface INeitralEntity : IDamagable 
{
    
}
interface IagressivableEntity : INeitralEntity
{
    
}
