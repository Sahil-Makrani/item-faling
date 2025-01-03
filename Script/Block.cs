using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Block : MonoBehaviour
{
    void Update()
    {
       if(gameObject.transform.position.y < -6)
       {
            Destroy(gameObject);
       }
    }
}
