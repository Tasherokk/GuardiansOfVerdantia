using UnityEngine;
using System.Collections.Generic;

public class TowerPlacement : MonoBehaviour
{
    public List<TowerData> availableTowers; // Assign in Inspector
    private TowerData _selectedTowerData;
    private int _selectedTowerIndex = 0;

    private void Start()
    {
        if (availableTowers != null && availableTowers.Count > 0)
        {
            _selectedTowerData = availableTowers[_selectedTowerIndex];
            Debug.Log($"Selected Tower: {_selectedTowerData.towerName}");
        }
        else
        {
            Debug.LogError("No available towers assigned to TowerPlacement.", this);
            enabled = false;
        }
    }

    private void Update()
    {
        // Cycle through available towers with 'Q' key (for MVP)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _selectedTowerIndex = (_selectedTowerIndex + 1) % availableTowers.Count;
            _selectedTowerData = availableTowers[_selectedTowerIndex];
            Debug.Log($"Selected Tower: {_selectedTowerData.towerName}");
        }

        // Place tower with left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("TowerSpot"))
            {
                PlaceTower(hit.collider.gameObject);
            }
        }
    }

    private void PlaceTower(GameObject spot)
    {
        if (_selectedTowerData == null)
        {
            Debug.LogError("No tower selected for placement.", this);
            return;
        }

        // Check if spot is already occupied
        if (spot.transform.childCount > 0)
        {
            Debug.Log("Spot already occupied.");
            return;
        }

        // Check mana
        if (GameManager.Instance != null && GameManager.Instance.TrySpendMana(_selectedTowerData.cost))
        {
            GameObject newTower = Instantiate(_selectedTowerData.towerPrefab, spot.transform.position, Quaternion.identity, spot.transform);
            Tower towerComponent = newTower.GetComponent<Tower>();
            if (towerComponent != null)
            {
                towerComponent.towerData = _selectedTowerData;
            }
            Debug.Log($"Placed {_selectedTowerData.towerName} for {_selectedTowerData.cost} mana.");
        }
        else
        {
            Debug.Log("Not enough mana to place tower.");
        }
    }
}