
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum guntype
{// Variable that has multiple options
    grenadelauncher,
    pistol,
    melee
}
// This is the scriptable object Base variables
[CreateAssetMenu(fileName = "GunScriptableobject", menuName = "gun/propertys", order = 1)]
public class GunsScriptableObject : ScriptableObject
{



    public string Name = "weapon";
    public guntype Type = guntype.melee;
    //----------------------------- variables for gun
    public int NormalDamage = 5;
    public int CriticalDamage = 10;
    public float firerate = 1.0f;
    public float Range = 60f;
    public float Reloadtime = 4.0f;
    public int maxammo = 50;
    public int currentammo = 1;
    public int impactforce = 6000;
    public float nextimetofire = 1.0f;
    public Object weaponPrefab = null;
    public string hoverText = "Press E to pick up";
    public float hoverVisibleDistance = 4.0f;
    public float explosionRange = 5.0f;
    public float uppowerexplosion = 1.0f;
    public float powerofexplosion = 200f;
    public float playersexplosionforce = 400f;
    public float playersupforce = 0f;
    public float grenades = 5f;
    public float meeeleaddforce = 10000f;
    public float upforcemeele = 6000f;
    public float bulletforce = 10000f;

}

