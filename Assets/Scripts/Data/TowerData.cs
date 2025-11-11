using UnityEngine;

[CreateAssetMenu(fileName = "NewTowerData", menuName = "Tower Defense/Tower Data")]
public class TowerData : ScriptableObject
{
    public string towerName = "New Tower";
    public GameObject towerPrefab;
    public int cost = 50;
    public float damage = 10f;
    public float range = 3f;
    public float attackSpeed = 1f; // Attacks per second

    public enum SpecialAbilityType
    {
        None,
        Slow,
        AoE,
        Knockback
    }
    public SpecialAbilityType specialAbility = SpecialAbilityType.None;

    // Validation (optional, can be done in editor script or runtime)
    void OnValidate()
    {
        if (cost <= 0) cost = 1;
        if (damage <= 0) damage = 0.1f;
        if (range <= 0) range = 0.1f;
        if (attackSpeed <= 0) attackSpeed = 0.1f;
    }
}
