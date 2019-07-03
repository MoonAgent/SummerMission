using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControler : MonoBehaviour
{
    public AudioSource music;
    public Slider m_slider3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Con_Sound();
    }
    void Con_Sound()
    {
        if (m_slider3.value > 0.1)
            music.volume = m_slider3.value;
        else
            music.volume = 0.1f;
    }
}
