using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public GameObject m_cubeObj;
    public GameObject m_lightObj;
    public float m_heightVal;
    public Slider m_slider;
    public Text m_text;
    public float m_rotation;

    void Start()
    {
        ChangeHeight();
    }

    private void ChangeHeight(float t_heigt = 1f)
    {
        m_heightVal = t_heigt;
        m_cubeObj.transform.localScale = new Vector3(1f, m_heightVal, 1f);
    }

    private void ChangeRotation(float t_rotation= 360)
    {
        m_rotation = t_rotation;
        m_lightObj.transform.localRotation = Quaternion.Euler(180f, m_rotation ,180f);
    }
    void Update()
    {
        m_text.text = m_slider.value.ToString();
        ChangeHeight(m_slider.value);
        ChangeRotation(m_slider.value * 27);
    }
}
