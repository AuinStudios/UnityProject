using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Variable that has multiple options
public enum EnemyType
{
    LongRange,
    ShortRange,
    NoRange
}
// This is the scriptable object Base variables
[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy/EnemyProperties", order = 1)]
public class EnemyData : ScriptableObject
    {
        public string Name;
        public float Health;
        public EnemyType Type;

        public bool isBoss = false;
        public int NormalDamage;
        public int CriticalDamage;

        public int Range;
        public float ReloadTime = 5.0f;
        public float ProjectileSpeed = 3000.0f;
        public Object ProjectilePrefab;
    }

