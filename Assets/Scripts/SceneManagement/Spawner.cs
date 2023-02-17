using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> raiders;
    [SerializeField] private List<GameObject> pooledObjects;
    [SerializeField] private int sizeOfWave;
    [SerializeField] private GameObject enemiesParent;
    [SerializeField] private int powerOfWave;
    [SerializeField] Transform spawnArea;
    [SerializeField] internal float speed;
    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject temporary;
        for (int i = 0; i < sizeOfWave; i++)
        {
            int randomNumber = Random.Range(0,3);
            int randomNumberX = Random.Range(-10,11);
            temporary = Instantiate(raiders[randomNumber],new Vector3(randomNumberX,0,spawnArea.position.z), new Quaternion(0,180,0,0));
            temporary.SetActive(false);
            temporary.transform.SetParent(enemiesParent.transform);
            temporary.AddComponent<EnemyUnit>();
            if(randomNumber < 2)
            {
                temporary.AddComponent<EnemyAnimations>();
            }
            temporary.AddComponent<EnemyAttackScript>();
            pooledObjects.Add(temporary);
        }
        Spawn(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(speed > 1)
        speed -= 0.03f * Time.deltaTime;
    }
    private void Spawn(int nextEnemyIndex)
    {
        if(nextEnemyIndex <= pooledObjects.Count - 1)
        {
            Debug.Log(nextEnemyIndex);
            StartCoroutine(SpawnerCountDown(nextEnemyIndex,speed));
        }
        
    }
    
    IEnumerator SpawnerCountDown(int number, float speed)
    {
        yield return new WaitForSeconds(speed);
        pooledObjects[number].SetActive(true);
        Spawn(number+1);
    }
}
