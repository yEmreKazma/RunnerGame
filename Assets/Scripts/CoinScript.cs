using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private Vector3 rotateVector = new Vector3(-1, 0, 0);
    public float rotateSpeed;
    void Start()
    {
        
    }

    
    void Update()
    {
        RotateCoin();
    }

    private void RotateCoin()
    {
        transform.Rotate(rotateVector * rotateSpeed * Time.deltaTime);  
    }
}
