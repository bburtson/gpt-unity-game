using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayGenerator : MonoBehaviour
{
    public List<GameObject> hallwayPrefabs; // Assign your hallway prefabs in the Inspector
    public int numberOfHallways = 10; // Adjust the number of hallways to generate
    public Vector3 hallwaySize = new Vector3(10, 3, 10); // Set the size of a single hallway segment

    private List<GameObject> generatedHallways;

    private void Start()
    {
        generatedHallways = new List<GameObject>();
        GenerateRandomHallways();
    }

    private void GenerateRandomHallways()
    {
        Vector3 currentPosition = Vector3.zero;

        for (int i = 0; i < numberOfHallways; i++)
        {
            // Pick a random hallway prefab
            int randomIndex = Random.Range(0, hallwayPrefabs.Count);
            GameObject randomHallwayPrefab = hallwayPrefabs[randomIndex];

            // Instantiate the hallway at the current position and rotation
            GameObject hallwayInstance = Instantiate(randomHallwayPrefab, currentPosition, Quaternion.identity);
            generatedHallways.Add(hallwayInstance);

            // Move the position forward for the next hallway segment
            currentPosition += hallwaySize;
        }
    }
}