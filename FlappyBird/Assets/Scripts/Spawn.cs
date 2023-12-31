using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public List<GameObject> prefabsList;
    public GameObject myPrefab;
    private float timeRemaining = 0;
    public float minRespawn = 0.8f;
    public float maxRespawn = 1.2f;
    public GameManager gameManager;
    void Awake(){
        gameManager = GetComponentInParent<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = 0;
        prefabsList = new List<GameObject>();
        for (int i = 0; i <15; i++){
            GameObject ins = Instantiate(myPrefab, transform);
            ins.SetActive(false);
            prefabsList.Add(ins);
        }
    }
    void OnEnable(){
        foreach (var i in prefabsList) {
            i.SetActive(false);
        }
        timeRemaining = 0;
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
                timeRemaining = UnityEngine.Random.Range(minRespawn, maxRespawn);
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
