using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{

    public GameObject[] charaterPrefabs;
    public Transform spawnPoint;
    

    
    void Start()
    {

        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        GameObject prefab = charaterPrefabs[selectedCharacter];
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);

    }

    
}
