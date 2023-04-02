using UnityEngine;

[CreateAssetMenu]public class GunData : ScriptableObject
{
    [SerializeField]private Mesh Model;
    public int MaxBullet;
    public int CurrentBullet;
    public float SpeedShooting;
    public float ReloadTime;
    public float RecoilOnRun;
    public float Recoil;
    enum TypeShoot
    {
        Automatic,
        SemiAutomatic,
        Single
    }
}
