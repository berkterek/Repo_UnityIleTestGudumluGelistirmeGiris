using UnityEngine;
using UnityTddBeginner.Abstracts.ScriptableObjects;

namespace UnityTddBeginner.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Enemy Stats",menuName = "Terek Gaming/Stats/Enemy Stats")]
    public class EnemyStats : Stats, IEnemyStats
    {
    }
}