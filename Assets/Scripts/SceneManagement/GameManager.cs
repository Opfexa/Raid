using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> raiders;
    
    // Start is called before the first frame update
    void Start()
    {
        Spawner();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Spawner()
    {
        StartCoroutine(SpawnerCountDown());
    }
    private void Spawn()
    {
        int randomNumber = Random.Range(0,1);
        int randomNumberX = Random.Range(-10,11);
        Instantiate(raiders[randomNumber], new Vector3(randomNumberX,0,15),Quaternion.identity);
        
    }
    IEnumerator SpawnerCountDown()
    {
        yield return new WaitForSeconds(3);
        Spawner();
        Spawn();
        
    }
}
