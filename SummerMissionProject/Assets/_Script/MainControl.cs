using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MainControl : MonoBehaviour
{
    public Transform m_parent;
    public GameObject m_cubePrefab;
    public float m_step;
    public int m_cubeNum;
    public List<GameObject> m_cubeLis;
    public List<Text> m_int;

    void Start()
    {
        CreateCube();
    }

    public void CreateCube()
    {
        for (int i = 0; i < m_cubeNum; i++)
        {
            GameObject _obj = Instantiate(m_cubePrefab, m_parent);
            _obj.transform.localPosition = new Vector3(i * m_step, 0f, 0f);
            if (m_cubeLis == null)
                m_cubeLis = new List<GameObject>();
            m_cubeLis.Add(_obj);
        }
    }

    //改变两个cube位置
    public bool ChangePostionFor2(int _i1, int _i2)
    {
        Vector3 _tempV31 = m_cubeLis[_i1].transform.localPosition;
        Vector3 _tempV32 = m_cubeLis[_i2].transform.localPosition;
        //m_cubeLis[_i1].transform.localPosition = m_cubeLis[_i2].transform.localPosition;
        //m_cubeLis[_i2].transform.localPosition = _tempV3;
        m_cubeLis[_i1].transform.DOLocalRotate(new Vector3(0f, 360f, 0f), 0.5f, RotateMode.FastBeyond360);
        m_cubeLis[_i2].transform.DOLocalRotate(new Vector3(0f, -360f, 0f), 0.5f, RotateMode.FastBeyond360);
        m_cubeLis[_i1].transform.DOLocalMove(_tempV32, 0.5f);
        m_cubeLis[_i2].transform.DOLocalMove(_tempV31, 0.5f);
        return true;
    }

    public void SortCubeLis()
    {
        //StartCoroutine(ieSortCubeLis());
        StartCoroutine("ieSortCubeLis");
    }

    IEnumerator ieSortCubeLis()
    {
        for (int i = 0; i < m_cubeLis.Count - 1; i++)
        {
            for (int j = 0; j < m_cubeLis.Count - 1 - i; j++)
            {
                if (m_cubeLis[j].GetComponent<GameControl>().m_slider.value >
                   m_cubeLis[j + 1].GetComponent<GameControl>().m_slider.value)
                {
                    GameObject _tObj = m_cubeLis[j];
                    m_cubeLis[j] = m_cubeLis[j + 1];
                    m_cubeLis[j + 1] = _tObj;
                    ChangePostionFor2(j, j + 1);
                    yield return new WaitForSeconds(0.6f);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
