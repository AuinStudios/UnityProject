using UnityEngine;
using UnityEditor;
using System.Collections;


// Variable that has multiple options
public enum EnemyType
{
    LongRange,
    ShortRange,
    NoRange
}
// ----------------------------------


// This is the scriptable object Base variables
[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy/EnemyProperties", order = 1)]
public class EnemyData : ScriptableObject
{
    public string Name;
    public int Health;
    public EnemyType Type;

    public bool isBoss = false;
    public int NormalDamage;
    public int CriticalDamage;

    public int Range ;
    public float ReloadTime = 5.0f;
    public float ProjectileSpeed = 5000.0f;
    public Object ProjectilePrefab;
}
// ------------------------------------------------------


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
        myScript.Health = EditorGUILayout.IntSlider("Enemy Health: ", myScript.Health, 5, 100);
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