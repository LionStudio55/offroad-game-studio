using UnityEngine;

[CreateAssetMenu(fileName = "GunData", menuName = "ScriptableObjects/GunSelection_Gun")]
public class GunSelection_Gun : ScriptableObject
{
    public new string name = "";

    public int cost = 100;
    [Range(0, 1)]
    public float Damage = 1;
    [Range(0, 1)]
    public float  Firerate = 1;
    [Range(0, 1)]
    public float FireRange = 1;
    [Range(0, 1)]
    public float Magzine = 1;
    [Range(0, 1)]
    public float Ammo = 1;
    [Range(0, 1)]
    public float Force = 1;

}

