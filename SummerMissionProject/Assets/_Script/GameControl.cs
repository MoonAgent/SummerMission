using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public GameObject m_cubeObj;
    public float m_heightVal;
    public Slider m_slider;
    public Text m_text;

    void Start()
    {
        ChangeHeight();
    }

    private void ChangeHeight(float t_heigt = 1f)
    {
        m_heightVal = t_heigt;
        m_cubeObj.transform.localScale = new Vector3(m_heightVal, m_heightVal, m_heightVal);
    }

    void Update()
    {
        m_text.text = m_slider.value.ToString();
        ChangeHeight(m_slider.value);
    }
}
