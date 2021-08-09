using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hit : MonoBehaviour
{
    private int k =2 ;
    public Image[] image;
    private void OnCollisionEnter(Collision collision)
    {
        
        if (k >= 0)
        {
            image[k].gameObject.SetActive(false);
        }
        k--;
        if (k < 0)
        {

        }
        
    }
}
