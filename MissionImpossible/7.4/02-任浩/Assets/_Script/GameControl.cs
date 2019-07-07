using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameControl : MonoBehaviour
{
    public GameObject m_cubeObj;
    public Slider m_slider;
    public Text m_text;
    public float m_initValue;

    void Start()
    {
        m_initValue = (int)Random.Range(m_slider.minValue, m_slider.maxValue);
        m_slider.value = m_initValue;
        ChangeHeight(m_initValue);
    }

    public void ChangeHeight(float _value = -100f)
    {
        m_text.text = m_slider.value.ToString();
        if ((_value + 100f) < Mathf.Epsilon)
        {
            //m_cubeObj.transform.localScale = new Vector3(1f, m_slider.value, 1f);
            m_cubeObj.transform.DOScaleY(m_slider.value, 0.3f).SetEase(Ease.OutBounce);
        }
        else
        {
            //m_cubeObj.transform.localScale = new Vector3(1f, _value, 1f);
            m_cubeObj.transform.DOScaleY(_value, 0.3f).SetEase(Ease.OutBounce);
        }
    }

    void Update()
    {
    }
}
