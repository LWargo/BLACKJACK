using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;



public class cards_script : MonoBehaviour
{
    public Sprite[] allCards;
    public int[] cardValues = new int[53];

    private int valueIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void assignValue(){
        int val = 0; //original valye
        for(int i = 0; i < allCards.Length; i++){ //go through all card
            val = i;
            val = val % 13; //divide by 13 bc 13 in a suite
            if(val == 10 || val == 0){ //if jack, queen, or king then always 10
                val = 10;
            }
            cardValues[i] = val++;
        }
        valueIndex++;
    }
    public void shuffle(){
        int tot = allCards.Length;
        for(int i = (tot  - 1); i ==0; i--){
            int ii = Mathf.FloorToInt(Random.Range(0f,1f) * (tot - 1)) + 1; //random val to swap with
            Sprite front = allCards[i]; //temp value for sprite
            allCards[i] = allCards[ii]; //swap value
            allCards[ii] = front; //assign temp
            int vali = cardValues[i]; //temp variable for value
            cardValues[i] = cardValues[ii]; //swap value
            cardValues[ii] = vali; //assign temp
        }
    }
}
