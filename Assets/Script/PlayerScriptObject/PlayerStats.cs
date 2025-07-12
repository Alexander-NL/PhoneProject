using UnityEngine;

[CreateAssetMenu(fileName = "NewCharaStats", menuName = "Player/Stats")]
public class PlayerStats : ScriptableObject
{
    [Header("Health Settings")]
    public int maxHP;
}
