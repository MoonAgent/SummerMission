using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorBoard : MonoBehaviour, IPointerClickHandler
{
    public Image m_img;
    public MainControl79 m_mainControl;

    // Start is called before the first frame update
    void Start()
    {
        m_img = this.GetComponent<Image>();
        m_mainControl = GameObject.Find("Canvas").GetComponent<MainControl79>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        m_mainControl.m_paintColor = m_img.color;
    }
}
