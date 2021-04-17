using UnityEngine;

public enum guntype
{// Variable that has multiple options
    grenadelauncher,
    pistol,
    melee,
    auto
}

// This is the scriptable object Base variables
[CreateAssetMenu(fileName = "GunScriptableobject", menuName = "Gun/Properties", order = 1)]
public class GunsScriptableObject : ScriptableObject
{
    public string Name;
    public guntype Type;
    //----------------------------- variables for gun
    public int NormalDamage;
    public int CriticalDamage;
    public float firerate;
    public float Range;
    public float Reloadtime;
    public int maxammo;
    public int currentammo;
    public int impactforce;
    public float nextimetofire;
    public Object weaponPrefab;
    public string hoverText;
    public float hoverVisibleDistance;
    public float explosionRange;
    public float uppowerexplosion;
    public float powerofexplosion;
    public float playersexplosionforce;
    public float playersupforce;
    public float grenades;
    public float meeeleaddforce;
    public float upforcemeele;
    public float bulletforce;
}

