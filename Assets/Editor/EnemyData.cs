using UnityEngine;
using UnityEditor;
using System.Collections;



// Custom GUI for the scriptable object Variables
[CustomEditor(typeof(EnemyData))]
class EnemyDataCustomGUI : Editor
{
    // with override we do not use unity editor gui and we make our own gui
    public override void OnInspectorGUI()
    {
        // telling the Custom gui what class to find so we can show the variables of it
        var myScript = target as EnemyData;

        // custom gui variables for out class
        myScript.Name = EditorGUILayout.TextField("Enemy Name: ", myScript.Name);
        myScript.Health = EditorGUILayout.Slider("Enemy Health: ", myScript.Health, 0, 100);
        myScript.NormalDamage = EditorGUILayout.IntSlider("Enemy Damage: ", myScript.NormalDamage, 1, 25);


        myScript.Type = (EnemyType)EditorGUILayout.EnumPopup( myScript.Type);
        if (myScript.Type != EnemyType.NoRange)
        {
            myScript.Range = EditorGUILayout.IntSlider("Enemy Range: ", myScript.Range, 10, 100);
            myScript.ReloadTime = EditorGUILayout.FloatField("Enemy Reload time: ", myScript.ReloadTime);
            myScript.ProjectilePrefab = EditorGUILayout.ObjectField(myScript.ProjectilePrefab, typeof(Object), true);
            myScript.ProjectileSpeed = EditorGUILayout.FloatField("Projectile speed: ", myScript.ProjectileSpeed);

        }

        myScript.isBoss = GUILayout.Toggle(myScript.isBoss, "IsBoss");
        if (myScript.isBoss == true)
        {
            myScript.CriticalDamage = EditorGUILayout.IntSlider("Critical Damage:", myScript.CriticalDamage, 25, 50);
        }
    }
}