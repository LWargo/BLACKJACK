using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    public Button playBtn;
    public Scene blackjack;
    // Start is called before the first frame update
    void Start()
    {
        playBtn.onClick.AddListener( () => playGame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playGame(){
        Debug.Log("loading blackjack!");
        SceneManager.LoadScene("blackjack" , LoadSceneMode.Single);
    }
}
