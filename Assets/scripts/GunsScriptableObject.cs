using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

// Variable that has multiple options
public enum guntype
{
    grenadelauncher,
    pistol,
    melee
}
// ----------------------------------

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
    public int Range = 200;
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
   
}
// ------------------------------------------------------

// Custom GUI for the scriptable object Variables
[CustomEditor(typeof(GunsScriptableObject))]
class gundataui : Editor
{
    // with override we do not use unity editor gui and we make our own gui
    public override void OnInspectorGUI()
    {
        // telling the Custom gui what class to find so we can show the variables of it
        var myScript = target as GunsScriptableObject;

        // custom gui variables for out class
        myScript.Name = EditorGUILayout.TextField("Gun Name: ", myScript.Name);
        myScript.NormalDamage = EditorGUILayout.IntSlider("Damage: ", myScript.NormalDamage, 1, 50);
        
       // the   variables ui shown in inspector
        myScript.Type = (guntype)EditorGUILayout.EnumPopup(myScript.Type);
        if (myScript.Type != guntype.melee)
        {
            if (myScript.Type == guntype.grenadelauncher)
            {
                // variables that ONLY the rpg can have
                myScript.explosionRange = EditorGUILayout.Slider("Explosion range: ", myScript.explosionRange, 1.0f, 10.0f);
                myScript.uppowerexplosion = EditorGUILayout.Slider("explosion up power mutlplyer", myScript.uppowerexplosion, 0f, 100f);
                myScript.powerofexplosion = EditorGUILayout.Slider("general power of explosion", myScript.powerofexplosion, 0f, 10000f);
                myScript.playersexplosionforce = EditorGUILayout.Slider("players explosion force", myScript.playersexplosionforce, 1.0f, 100000f);
                myScript.playersupforce = EditorGUILayout.Slider("players expolosion up power", myScript.playersupforce, 0f, 100f);
                myScript.maxammo = EditorGUILayout.IntSlider("Max ammo: ", myScript.maxammo, 1, 500);
            }
            else
            {
                // variables that the grenade launcher CAN NOT have
                myScript.Range = EditorGUILayout.IntSlider("Gun range: ", myScript.Range, 10, 500);
                myScript.impactforce = EditorGUILayout.IntSlider("Impact force: ", myScript.impactforce, 1, 10000);
            }

            // variables that all weapons EXCEPT Melee can have
            
            myScript.Reloadtime = EditorGUILayout.Slider("Gun reload time: ", myScript.Reloadtime, 1.0f , 5.0f);
            myScript.firerate = EditorGUILayout.Slider("Gun fire rate: ", myScript.firerate, 0.1f, 100.0f);
            myScript.maxammo = EditorGUILayout.IntSlider("Max ammo: ", myScript.maxammo, 1, 500);
            myScript.hoverText = EditorGUILayout.TextField("On hover text: ", myScript.hoverText);
            myScript.hoverVisibleDistance = EditorGUILayout.Slider("Over text visible distance: ", myScript.hoverVisibleDistance, 1.0f, 5.0f);
            myScript.weaponPrefab = EditorGUILayout.ObjectField("Weapon prefab: ", myScript.weaponPrefab, typeof(GameObject), false);
            
        }
    }    
}