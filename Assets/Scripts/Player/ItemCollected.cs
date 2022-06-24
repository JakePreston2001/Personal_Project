using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollected : MonoBehaviour
{
    [SerializeField] private Text objectCollected;
    private int objectNumber;

    private void Start()
    {
        objectNumber = 0;
    }

    public void increaseNum() 
    {
        objectNumber +=1;
    }

    private void Update()
    {
        objectCollected.text = "Number of Objects collected: " + objectNumber;
    }
}
