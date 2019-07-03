using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class New : MonoBehaviour
{
    public GameObject m_sphereObj;
    public float m_radiusVal;
    public Slider m_slider;
    public Text m_text;

    void Start()
    {
        ChangeRadius();
    }

    private void ChangeRadius(float t_radius = 1f)
    {
        m_radiusVal = t_radius;
        m_sphereObj.transform.localScale = new Vector3(m_radiusVal, m_radiusVal, m_radiusVal);
    }

    void Update()
    {
        m_text.text = m_slider.value.ToString();
        ChangeRadius(m_slider.value);
    }
}
