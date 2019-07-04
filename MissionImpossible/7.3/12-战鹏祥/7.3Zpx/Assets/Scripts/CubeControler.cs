using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeControler : MonoBehaviour
{
    public GameObject m_cube1;
    public GameObject m_cube2;
    public Text m_text;

    public Slider m_slider;
    public Slider m_slider2;
    // Start is called before the first frame update
    void Start()
    {
        ChangeCubeColor();
    }
    void ChangeCubeColor()
    {
        m_cube1.GetComponent<MeshRenderer>().material.color = new Vector4(m_slider.value, m_slider.value, m_slider.value, 1);
        if(m_slider2.value>=0&& m_slider2.value<=0.25)
        {
            m_cube2.GetComponent<MeshRenderer>().material.color = new Vector4(0, 0, m_slider2.value*4, 1);
            m_text.text = "Black<->Blue";
        }
        if(m_slider2.value > 0.25 && m_slider2.value <= 0.5)
        {
            m_cube2.GetComponent<MeshRenderer>().material.color = new Vector4(0,(m_slider2.value - 0.25f), 1-(m_slider2.value-0.25f) * 4, 1);
            m_text.text = "Blue<->Green";
        }
        if (m_slider2.value > 0.5 && m_slider2.value <= 0.75)
        {
            m_cube2.GetComponent<MeshRenderer>().material.color = new Vector4((m_slider2.value - 0.5f)*4, 1, 0, 1);
            m_text.text = "Green<->Yellow";
        }
        if (m_slider2.value > 0.75 && m_slider2.value <= 1)
        {
            m_cube2.GetComponent<MeshRenderer>().material.color = new Vector4(1, 1- (m_slider2.value - 0.75f)*4, 0, 1);
            m_text.text = "Yellow<->Red";
        }
    }
    // Update is called once per frame
    void Update()
    {
        ChangeCubeColor();
    }
}
