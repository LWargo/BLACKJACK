using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{

    public Button dealbutt;
    public Button hitbutt;
    public Button staybutt;
    public Button betbutt;
    public action_script PS;
    public action_script DS;

    // Start is called before the first frame update
    void Start()
    {
        dealbutt.onClick.AddListener( () => dealFunc() );
        hitbutt.onClick.AddListener( () => hitFunc() );
        staybutt.onClick.AddListener( () => stayFunc() );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void dealFunc(){
        Debug.Log("Dealing Cards");
        PS.startHand();
    }
    private void hitFunc(){
        Debug.Log("Hitting you with a CARD");
    }
    private void stayFunc(){
        Debug.Log("Bro thinks he has a good hand; staying");
    }
}
