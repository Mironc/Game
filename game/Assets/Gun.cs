using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using System;
using UnityEngine;

[CreateAssetMenu()]
public class Gun : ScriptableObject
{
    public int MaxCountOfBullet;
    public int CountOfBullets;
    public float ReloadTime;
    public ShootType TypeofShoot;
    public Recoil TypeofRecoil;
    public float DelayAboutShoot;
    public float BulletSpeed;
    public Vector2 RangeOfRandom;
    public enum ShootType
    {
        SemiAuto, 
        Auto,
        Single
    }
    
    public void DecreaseCountOfBullet()
    {
        CountOfBullets--;
        CountOfBullets = Mathf.Clamp(this.CountOfBullets,0,this.MaxCountOfBullet);
    }
    
[Serializable]
public struct Recoil
    {
    public AnimationCurve RecoilDownPattern;
    public float TimeOfShot;
    public float RecoilPower;
    public float RecoilInRun;
    public float RecurrentSpeed;
    public int SeedofRecoil;
    public Vector2 RangeOfRandom;
    public Vector2 CurrentRecoil;
    public float ResetRecoilTimer;
    public void SetRandom()
    {
        Random.InitState(this.SeedofRecoil);
    }
    public void AddRecoil()
    {
        if(this.TimeOfShot < this.RecoilDownPattern.keys[this.RecoilDownPattern.length].time )
        /* CurrentRecoil = CharacterController.Instance.MovementProperties.Walk ? 
        new Vector2(Random.Range(this.RangeOfRandom.x, this.RangeOfRandom.y), RecoilDownPattern.Evaluate(this.TimeOfShot)) * this.RecoilInRun * this.RecoilPower :
        new Vector2(Random.Range(this.RangeOfRandom.x, this.RangeOfRandom.y), ) * this.RecoilPower;  */
        this.CurrentRecoil = new Vector2(Random.Range(this.RangeOfRandom.x, this.RangeOfRandom.y), RecoilDownPattern.Evaluate(this.TimeOfShot))
        * (CharacterController.Instance.MovementProperties.Walk ? this.RecoilInRun * this.RecoilPower : this.RecoilPower) ;
        this.ResetRecoilTimer = 0;
    }
    public void RecoverRecoil() 
    {
        
        CurrentRecoil = Vector2.Lerp(CurrentRecoil, Vector2.zero, this.ResetRecoilTimer);
        this.ResetRecoilTimer += Time.deltaTime * this.RecurrentSpeed;
    }
    }    
}