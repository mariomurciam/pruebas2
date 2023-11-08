using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public List<GameObject> prefabsList;
    public GameObject myPrefab;
    private float timeRemaining;
    public GameManager gameManager;
    void Awake(){
        gameManager = GetComponentInParent<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = 0;
        prefabsList = new List<GameObject>();
        for (int i = 0; i <15; i++){//(13.30f+(i*4))
            GameObject ins = Instantiate(myPrefab, transform);
            //Debug.Log(transform.position);
            ins.SetActive(false);
            //ins.GetComponent<PipelinesMov>().RandomPoint();
            prefabsList.Add(ins);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.getDie() == false){
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }else{
                StartPipe();
                timeRemaining = UnityEngine.Random.Range(0.80f, 1.00f);
            }
        }
    }

    void StartPipe(){
        foreach (var i in prefabsList) {
            if(i.activeInHierarchy == false){
                i.SetActive(true);
                break;
            }
        }
    }

    
}
