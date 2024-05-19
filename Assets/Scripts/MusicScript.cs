using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
public GameObject MusicObject;
    private AudioSource audioSrc1;
    public GameObject[] objs11;

    void Awake()
    {
        objs11 = GameObject.FindGameObjectsWithTag("Sound");
        if (objs11.Length == 0)
        {
            MusicObject = Instantiate(MusicObject);
            MusicObject.name = "MusicObject";
            DontDestroyOnLoad(MusicObject.gameObject);
        }
        else
        {
            MusicObject = GameObject.Find("MusicObject");
        }
    }
    void Start()
    {
        audioSrc1 = MusicObject.GetComponent<AudioSource>();
    }
}
