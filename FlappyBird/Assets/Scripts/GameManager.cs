using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject myPrefab;
    public List<GameObject> prefabsList;
    public float timeSpawn = 1.00f;
    private float timeRemaining;
    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> prefabsList = new List<GameObject>();
        for (int i = 0; i <10; i++){
            GameObject ins = Instantiate(myPrefab, new Vector3((6.30f+(i*2)), UnityEngine.Random.Range(-1.6f, 0.2f), 0), Quaternion.identity);
            //ins.SetActive(false);
            prefabsList.Add(ins);
        }
        timeRemaining = timeSpawn;
    }

    // Update is called once per frame
    void Update()
    { 
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }else{
            //GameObject ins = Instantiate(myPrefab, new Vector3(6.30f, UnityEngine.Random.Range(-1.6f, 0.2f), 0), Quaternion.identity);
            timeRemaining = timeSpawn;
            //Destroy(ins, 10.00f);
        }
        
    }
}
