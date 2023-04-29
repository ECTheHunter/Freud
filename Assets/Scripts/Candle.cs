using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{
    public bool isonfire;
    public GameObject light;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void DestroyLight()
    {
        Destroy(light);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
