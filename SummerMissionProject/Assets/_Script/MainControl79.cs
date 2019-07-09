using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainControl79 : MonoBehaviour
{
    public GameObject m_pixPrefab;
    public Transform m_pixParent;
    public Vector2 m_pixSize;
    public float m_interval;

    public Button m_button1;

    public bool m_canPaint = false;
    public Color m_paintColor = Color.yellow;
    public List<Image> m_pixLis;

    void Start()
    {
        Init();
        CreateCanvas();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_canPaint = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            m_canPaint = false;
        }
    }

    private void CreateCanvas()
    {
        for (int i = 0; i < m_pixSize.x; i++)
        {
            for (int j = 0; j < m_pixSize.y; j++)
            {
                GameObject _t = Instantiate(m_pixPrefab, m_pixParent);
                _t.transform.localPosition = new Vector3(i * m_interval, j * m_interval);
                _t.name = "Pix" + i + "_" + j;
                _t.GetComponent<PixControl>().m_mainControl = this;

                if (m_pixLis == null)
                    m_pixLis = new List<Image>();
                m_pixLis.Add(_t.GetComponent<Image>());
            }
        }
    }

    private void Init()
    {
        //m_button1.onClick.AddListener(
        //    delegate
        //    {
        //        //函数
        //    });
        m_button1.onClick.AddListener(() =>
        { /*函数*/
            print("橡皮1");
        });
        m_button1.onClick.RemoveAllListeners();
        m_button1.onClick.AddListener(() =>
        { /*函数*/
            m_paintColor = Color.white;
        });
    }

    public void ClearPaint()
    {
        foreach (var item in m_pixLis)
        {
            item.color = Color.white;
        }
    }
}
    
