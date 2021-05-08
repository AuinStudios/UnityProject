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
    public guntype type;
    //----------------------------- variables for gun

    // all
    public Animator animator;

    // Auto and pistol
    public float bulletForce;

    // Auto
    public float fireRate;

    // Grenade launcher
    public float explosionRange;
    public float upPowerExplosion;
    public float powerOfExplosion;
    public float playerExplosionForce;
    public float playerUpForce;

    // Melee
    public float meleeAddForce;
    public float upForceMelee;

    // All except Melee
    public int normalDamage;
    public int criticalDamage;
    public float range;
    public float reloadTime;
    public int maxAmmo;
    public int currentAmmo;
    public int impactForce;
    public float nextTimeToFire;
    public Object weaponPrefab;
    public Object bullet;
    public int bulletCount = 1;
    public string hoverText;
    public float hoverVisibleDistance;
    public float grenades;

    public bool canSpread = false;
    public float spreadAmount;
    public float bulletSpreadVariation;
}

