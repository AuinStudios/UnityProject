using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;






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
        if (myScript.Type == guntype.melee)
            {
                myScript.meeeleaddforce = EditorGUILayout.Slider("meeeleforce", myScript.meeeleaddforce, 0f, 2000000f);
            myScript.upforcemeele = EditorGUILayout.Slider("meeeleupforce", myScript.upforcemeele, 0f, 200000f);
        }

        if(myScript.Type == guntype.auto)
        {
            myScript.firerate = EditorGUILayout.Slider("Gun fire rate: ", myScript.firerate, 7f, 100.0f);
        }
        if (myScript.Type != guntype.melee)
        
            
        {
            if (myScript.Type == guntype.grenadelauncher)
            {
                // variables that ONLY the grenadelauncher can have
                
                myScript.explosionRange = EditorGUILayout.Slider("Explosion range: ", myScript.explosionRange, 1.0f, 10.0f);
                myScript.uppowerexplosion = EditorGUILayout.Slider("explosion up power mutlplyer", myScript.uppowerexplosion, 0f, 100f);
                myScript.powerofexplosion = EditorGUILayout.Slider("general power of explosion", myScript.powerofexplosion, 0f, 10000f);
                myScript.playersexplosionforce = EditorGUILayout.Slider("players explosion force", myScript.playersexplosionforce, 1.0f, 100000f);
                myScript.playersupforce = EditorGUILayout.Slider("players expolosion up power", myScript.playersupforce, 0f, 100f);
                
                
            }
            else
            {
                // variables that the grenade launcher CAN NOT have

                myScript.bulletforce = EditorGUILayout.Slider("bulletforce", myScript.bulletforce, 0f, 400000f);
            }

            // variables that all weapons EXCEPT Melee can have
            myScript.Range = EditorGUILayout.Slider("range", myScript.Range, 1.0f, 1000.0f);
            myScript.Reloadtime = EditorGUILayout.Slider("Gun reload time: ", myScript.Reloadtime, 1.0f , 5.0f);
            myScript.firerate = EditorGUILayout.Slider("Gun fire rate: ", myScript.firerate, 0.1f, 100.0f);
            myScript.maxammo = EditorGUILayout.IntSlider("Max ammo: ", myScript.maxammo, 1, 500000);
            myScript.hoverText = EditorGUILayout.TextField("On hover text: ", myScript.hoverText);
            myScript.hoverVisibleDistance = EditorGUILayout.Slider("Over text visible distance: ", myScript.hoverVisibleDistance, 1.0f, 5.0f);
            myScript.weaponPrefab = EditorGUILayout.ObjectField("Weapon prefab: ", myScript.weaponPrefab, typeof(GameObject), false);
            


        }
    }   
}