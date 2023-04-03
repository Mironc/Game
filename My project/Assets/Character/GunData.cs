using UnityEngine;

[CreateAssetMenu]public class GunData : ScriptableObject
{
    public Mesh Model;
    public Transform BulletPlace;
    public TypeShoot typeShoot;
    public float BulletDamageMax;
    public float BulletDamageMin;
    public int MaxBullet;
    public int CurrentBullet;
    public float SpeedShooting;

    public float ReloadTime;
    public float RecoilOnRun;
    public float Recoil;
    public enum TypeShoot
    {
        Automatic,
        SemiAutomatic,
        Single
    }
    [HideInInspector]public float LastTimeFired;
}
