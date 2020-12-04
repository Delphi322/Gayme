using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{

    private MusicController theMC;

    public int newTrack;

    private bool switchOnStart;

    // Start is called before the first frame update
    void Start()
    {

        theMC = FindObjectOfType<MusicController>();

        if (switchOnStart)
        {
            theMC.SwitchTrack(newTrack);
            gameObject.SetActive(false);
        }
        else 
        {
            theMC.SwitchTrack(newTrack);
            gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            theMC.SwitchTrack(newTrack);
            gameObject.SetActive(false);
        }

    }

}
