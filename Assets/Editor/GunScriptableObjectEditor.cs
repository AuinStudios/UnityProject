using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// ------------------------------------------------------

// Custom GUI for the scriptable object Variables
[CustomEditor(typeof(GunsScriptableObject)), CanEditMultipleObjects]
public class GunScriptableObjectEditor : Editor
{
    GunsScriptableObject gunsScriptable;

    private void OnEnable()
    { 
        gunsScriptable = target as GunsScriptableObject;
    }

    // with override we do not use unity editor gui and we make our own gui
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        // custom gui variables for out class
        gunsScriptable.Name = EditorGUILayout.TextField("Gun Name: ", gunsScriptable.Name);
        gunsScriptable.normalDamage = EditorGUILayout.IntSlider("Damage: ", gunsScriptable.normalDamage, 1, 50);

        GUILine();

        // the variables ui shown in inspector
        gunsScriptable.type = (guntype)EditorGUILayout.EnumPopup(gunsScriptable.type);

        GUILine();

        switch (gunsScriptable.type)
        {
            case guntype.auto:
                {
                    gunsScriptable.bulletForce = EditorGUILayout.Slider("bulletforce", gunsScriptable.bulletForce, 0f, 400000f);

                    break;
                }
            case guntype.grenadelauncher:
                {
                    gunsScriptable.explosionRange = EditorGUILayout.Slider("Explosion range: ", gunsScriptable.explosionRange, 1.0f, 10.0f);
                    gunsScriptable.upPowerExplosion = EditorGUILayout.Slider("explosion up power mutlplyer", gunsScriptable.upPowerExplosion, 0f, 100f);
                    gunsScriptable.powerOfExplosion = EditorGUILayout.Slider("general power of explosion", gunsScriptable.powerOfExplosion, 0f, 10000f);
                    gunsScriptable.playerExplosionForce = EditorGUILayout.Slider("players explosion force", gunsScriptable.playerExplosionForce, 1.0f, 2000f);
                    gunsScriptable.playerUpForce = EditorGUILayout.Slider("players expolosion up power", gunsScriptable.playerUpForce, 0f, 100f);

                    break;
                }
            case guntype.melee:
                {
                    gunsScriptable.meleeAddForce = EditorGUILayout.Slider("meleeForce", gunsScriptable.meleeAddForce, 0f, 2000000f);
                    gunsScriptable.upForceMelee = EditorGUILayout.Slider("meleeUpForce", gunsScriptable.upForceMelee, 0f, 200000f);

                    break;
                }
            case guntype.pistol:
                {
                    gunsScriptable.bulletForce = EditorGUILayout.Slider("bulletforce", gunsScriptable.bulletForce, 0f, 400000f);

                    break;
                }
            default:
                {
                    Debug.LogError("How did you end up in this case...");
                    break;
                }
        }

        if (gunsScriptable.type != guntype.melee)
        {
            gunsScriptable.range = EditorGUILayout.Slider("range", gunsScriptable.range, 1.0f, 1000.0f);
            gunsScriptable.reloadTime = EditorGUILayout.Slider("Gun reload time: ", gunsScriptable.reloadTime, 1.0f, 5.0f);
            gunsScriptable.fireRate = EditorGUILayout.Slider("Gun fire rate: ", gunsScriptable.fireRate, 0.1f, 100.0f);
            gunsScriptable.maxAmmo = EditorGUILayout.IntSlider("Max ammo: ", gunsScriptable.maxAmmo, 1, 500000);

            gunsScriptable.hoverText = EditorGUILayout.TextField("On hover text: ", gunsScriptable.hoverText);
            gunsScriptable.hoverVisibleDistance = EditorGUILayout.Slider("Over text visible distance: ", gunsScriptable.hoverVisibleDistance, 1.0f, 5.0f);
            gunsScriptable.weaponPrefab = EditorGUILayout.ObjectField("Weapon prefab: ", gunsScriptable.weaponPrefab, typeof(GameObject), false);
            
            gunsScriptable.bullet = EditorGUILayout.ObjectField("Bullet prefab: ", gunsScriptable.bullet, typeof(GameObject), false);

            if (gunsScriptable.type != guntype.pistol)
            {
                gunsScriptable.bulletCount = EditorGUILayout.IntSlider("Bullet count: ", gunsScriptable.bulletCount, 1, 30);

                if (gunsScriptable.bulletCount > 1)
                {
                    gunsScriptable.canSpread = EditorGUILayout.Toggle("Can spread bullets: ", gunsScriptable.canSpread);

                    if (gunsScriptable.canSpread == true)
                    {
                        gunsScriptable.spreadAmount = EditorGUILayout.Slider("Spread Amount: ", gunsScriptable.spreadAmount, 0.01f, 0.25f);
                        gunsScriptable.bulletSpreadVariation = EditorGUILayout.Slider("Bullet Spread Variation: ", gunsScriptable.bulletSpreadVariation, 1.0f, 1.5f);
                    }
                }
            }

            //gunsScriptable.animator = EditorGUILayout.ObjectField("Firing animation", gunsScriptable.animator, typeof(Animator), false) as Animator;
        }

        serializedObject.ApplyModifiedProperties();
    }

    void GUILine()
    {
        EditorGUILayout.Space(8);

        Rect rect = EditorGUILayout.GetControlRect(false, 1);

        rect.height = 1;

        EditorGUI.DrawRect(rect, new Color(0.5f, 0.5f, 0.5f, 1));
        EditorGUILayout.Space(6);
    }
}