using UnityEngine;
using UnityEditor;

// Custom GUI for the scriptable object Variables
[CustomEditor(typeof(EnemyData)), CanEditMultipleObjects]
public class EnemyDataEditor : Editor
{
    EnemyData enemy;

    private void OnEnable()
    {
        enemy = target as EnemyData;
    }

    // with override we do not use unity editor gui and we make our own gui
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        // custom gui variables for out class
        enemy.Name = EditorGUILayout.TextField("Enemy Name: ", enemy.Name);
        enemy.Health = EditorGUILayout.Slider("Enemy Health: ", enemy.Health, 0, 100);
        enemy.NormalDamage = EditorGUILayout.IntSlider("Enemy Damage: ", enemy.NormalDamage, 1, 25);

        GUILine();

        enemy.Type = (EnemyType)EditorGUILayout.EnumPopup( enemy.Type);
        if (enemy.Type != EnemyType.NoRange)
        {
            enemy.Range = EditorGUILayout.IntSlider("Enemy Range: ", enemy.Range, 10, 100);
            enemy.ReloadTime = EditorGUILayout.FloatField("Enemy Reload time: ", enemy.ReloadTime);
            enemy.ProjectilePrefab = EditorGUILayout.ObjectField("Enemy projectile prefab: ", enemy.ProjectilePrefab, typeof(Object), true);
            enemy.ProjectileSpeed = EditorGUILayout.FloatField("Projectile speed: ", enemy.ProjectileSpeed);
        }

        GUILine();

        enemy.isBoss = GUILayout.Toggle(enemy.isBoss, "IsBoss");
        if (enemy.isBoss == true)
        {
            enemy.CriticalDamage = EditorGUILayout.IntSlider("Critical Damage:", enemy.CriticalDamage, 25, 50);
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