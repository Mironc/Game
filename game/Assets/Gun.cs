using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using System;
using UnityEngine;

[CreateAssetMenu()]
public class GunConstruct : ScriptableObject
{
    public int MaxCountOfBullet;
    public int CountOfBullets;
    public float ReloadTime;
    public IShoot Shoot;
    public ShootType TypeofShoot;
    public Recoil TypeofRecoil;
    public enum ShootType
    {
        SemiAuto,
        Auto,
        Single
    }

    public void DecreaseCountOfBullet()
    {
        CountOfBullets--;
        CountOfBullets = Mathf.Clamp(this.CountOfBullets, 0, this.MaxCountOfBullet);
    }

    [Serializable]
    struct AutoShoot : IShoot
    {
        public float DelayShoot { get; set; }
        public float DelayShootTimer { get; set; }
        public float BulletSpeed { get; set; }
        public void Fire(GameObject Bullet, Transform BulletPlace, Recoil rec)
        {
            rec.AddRecoil();
            Instantiate(Bullet);
            this.DelayShootTimer = 0f;
        }
    }
    public interface IShoot
    {
        public float DelayShoot { get; set; }
        public float DelayShootTimer { get; set; }
        public float BulletSpeed { get; set; }
        public void Fire(GameObject Bullet, Transform BulletPlace, Recoil rec);
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
            if (this.TimeOfShot < this.RecoilDownPattern.keys[this.RecoilDownPattern.length].time)
                /* CurrentRecoil = CharacterController.Instance.MovementProperties.Walk ? 
                new Vector2(Random.Range(this.RangeOfRandom.x, this.RangeOfRandom.y), RecoilDownPattern.Evaluate(this.TimeOfShot)) * this.RecoilInRun * this.RecoilPower :
                new Vector2(Random.Range(this.RangeOfRandom.x, this.RangeOfRandom.y), ) * this.RecoilPower;  */
                this.CurrentRecoil = new Vector2(Random.Range(this.RangeOfRandom.x, this.RangeOfRandom.y), RecoilDownPattern.Evaluate(this.TimeOfShot))
                * (CharacterController.Instance.MovementProperties.Walk ? this.RecoilInRun * this.RecoilPower : this.RecoilPower);
            this.ResetRecoilTimer = 0;
        }
        public void RecoverRecoil()
        {

            CurrentRecoil = Vector2.Lerp(CurrentRecoil, Vector2.zero, this.ResetRecoilTimer);
            this.ResetRecoilTimer += Time.deltaTime * this.RecurrentSpeed;
        }
    }
}