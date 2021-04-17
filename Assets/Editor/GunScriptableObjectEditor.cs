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
        gunsScriptable.NormalDamage = EditorGUILayout.IntSlider("Damage: ", gunsScriptable.NormalDamage, 1, 50);

        GUILine();

        // the variables ui shown in inspector
        gunsScriptable.Type = (guntype)EditorGUILayout.EnumPopup(gunsScriptable.Type);
        if (gunsScriptable.Type == guntype.melee)
        {
            gunsScriptable.meeeleaddforce = EditorGUILayout.Slider("meeeleforce", gunsScriptable.meeeleaddforce, 0f, 2000000f);
            gunsScriptable.upforcemeele = EditorGUILayout.Slider("meeeleupforce", gunsScriptable.upforcemeele, 0f, 200000f);
        }

        GUILine();

        if (gunsScriptable.Type == guntype.auto)
        {
            gunsScriptable.firerate = EditorGUILayout.Slider("Gun fire rate: ", gunsScriptable.firerate, 7f, 100.0f);
        }
        if (gunsScriptable.Type != guntype.melee)
        {
            if (gunsScriptable.Type == guntype.grenadelauncher)
            {
                // variables that ONLY the grenadelauncher can have

                gunsScriptable.explosionRange = EditorGUILayout.Slider("Explosion range: ", gunsScriptable.explosionRange, 1.0f, 10.0f);
                gunsScriptable.uppowerexplosion = EditorGUILayout.Slider("explosion up power mutlplyer", gunsScriptable.uppowerexplosion, 0f, 100f);
                gunsScriptable.powerofexplosion = EditorGUILayout.Slider("general power of explosion", gunsScriptable.powerofexplosion, 0f, 10000f);
                gunsScriptable.playersexplosionforce = EditorGUILayout.Slider("players explosion force", gunsScriptable.playersexplosionforce, 1.0f, 100000f);
                gunsScriptable.playersupforce = EditorGUILayout.Slider("players expolosion up power", gunsScriptable.playersupforce, 0f, 100f);
            }
            else
            {
                // variables that the grenade launcher CAN NOT have

                gunsScriptable.bulletforce = EditorGUILayout.Slider("bulletforce", gunsScriptable.bulletforce, 0f, 400000f);
            }

            // variables that all weapons EXCEPT Melee can have
            gunsScriptable.Range = EditorGUILayout.Slider("range", gunsScriptable.Range, 1.0f, 1000.0f);
            gunsScriptable.Reloadtime = EditorGUILayout.Slider("Gun reload time: ", gunsScriptable.Reloadtime, 1.0f , 5.0f);
            gunsScriptable.firerate = EditorGUILayout.Slider("Gun fire rate: ", gunsScriptable.firerate, 0.1f, 100.0f);
            gunsScriptable.maxammo = EditorGUILayout.IntSlider("Max ammo: ", gunsScriptable.maxammo, 1, 500000);

            gunsScriptable.hoverText = EditorGUILayout.TextField("On hover text: ", gunsScriptable.hoverText);
            gunsScriptable.hoverVisibleDistance = EditorGUILayout.Slider("Over text visible distance: ", gunsScriptable.hoverVisibleDistance, 1.0f, 5.0f);
            gunsScriptable.weaponPrefab = EditorGUILayout.ObjectField("Weapon prefab: ", gunsScriptable.weaponPrefab, typeof(GameObject), false);

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