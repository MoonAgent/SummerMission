using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PixControl : MonoBehaviour
{
    public Image m_img;
    public MainControl79 m_mainControl;
    void Start()
    {
        //m_mainControl = GameObject.Find("Canvas").GetComponent<MainControl79>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PixImgClick()
    {
        if (m_mainControl.m_canPaint)
        {
            //m_img.color = new Color(0.5f, 0.4f, 0.3f);
            //m_img.color = new Color32(100, 25, 255, 255);
            m_img.color = m_mainControl.m_paintColor;
        }
    }
}
