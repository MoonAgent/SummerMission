using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControl710 : MonoBehaviour
{
    public List<DragBehavior> CharLis;
    public List<Transform> SLandLis1;
    public List<Transform> SLandLis2;
    public List<Transform> SBoatLis;


    public List<GameObject> LandLis1 = new List<GameObject>();
    public List<GameObject> LandLis2 = new List<GameObject>();
    public List<GameObject> BoatLis = new List<GameObject>();



    void Start()
    {
        InitGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 v3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D c2d = Physics2D.OverlapPoint(v3);
            if (c2d != null && c2d.name == "Button")
            {
                KaiChuan();
            }
        }
    }

    public void InitGame()
    {
        for (int i = 0; i < CharLis.Count; i++)
        {
            CharLis[i].transform.SetParent(SLandLis1[i]);
            CharLis[i].transform.localPosition = Vector2.zero;
            CharLis[i].belongPlace = PlaceName.LLand;
            CharLis[i].mainControl = this;
            LandLis1.Add(CharLis[i].gameObject);
        }
    }

    public void IntoSomePlace(DragBehavior _db)
    {
        LandLis1.Remove(_db.gameObject);
        LandLis2.Remove(_db.gameObject);
        BoatLis.Remove(_db.gameObject);

        if (_db.belongPlace == PlaceName.LLand)
        {
            LandLis1.Add(_db.gameObject);
        }
        else if (_db.belongPlace == PlaceName.RLand)
        {
            LandLis2.Add(_db.gameObject);
        }
        else if (_db.belongPlace == PlaceName.Boat)
        {
            BoatLis.Add(_db.gameObject);
        }
    }

    public void KaiChuan()
    {
        print("开船");
    }
}

public enum PlaceName
{
    LLand,
    RLand,
    Boat
}
