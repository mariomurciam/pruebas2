using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public GameObject bird;
    public GameObject myPrefab;
    public GameObject back1;
    public GameObject back2;
    public GameObject floor1;
    public GameObject floor2;
    public List<GameObject> prefabsList;
    public float timeSpawn = 1.00f;
    private float timeRemaining;
    private bool die = false;
    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> prefabsList = new List<GameObject>();
        for (int i = 0; i <10; i++){
            GameObject ins = Instantiate(myPrefab, new Vector3((13.30f+(i*4)), UnityEngine.Random.Range(-2.00f, 2.00f), 0), Quaternion.identity);
            //ins.SetActive(false);
            //ins.GetComponent<PipelinesMov>().RandomPoint();
            prefabsList.Add(ins);
        }
        timeRemaining = timeSpawn;
    }

    // Update is called once per frame
    void Update()
    { 
        if(bird.GetComponent<BirdMov>().getDie() == true && die == false){
            Die();
        }

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }else{
            //GameObject ins = Instantiate(myPrefab, new Vector3(6.30f, UnityEngine.Random.Range(-1.6f, 0.2f), 0), Quaternion.identity);
            timeRemaining = timeSpawn;
            //Destroy(ins, 10.00f);
        }
        
    }

    void Die(){
        die = true;
        back1.GetComponent<BackMov>().Stop();
        back2.GetComponent<BackMov>().Stop();
        floor1.GetComponent<BackMov>().Stop();
        floor2.GetComponent<BackMov>().Stop();
        Debug.Log("OKKKKKKKK");
        foreach (var i in prefabsList) {
            i.GetComponent<PipelinesMov>().Stop();
            Debug.Log("OK");
        }
    }

    

}
