using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton, een enkele instantie van een object
    private static GameManager instance;
    public static GameManager Instance //Read-only property, zodat je de instantie van buitenaf niet kunt overschrijven
    {
        get { return instance; }
    }

    public int score = 0;

    private void Awake()
    {
        //Controleer of er niet al een dubbele versie van de singleton bestaat
        if (instance != null)
        {
            Debug.LogError("GameManager Instance is not null");
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
