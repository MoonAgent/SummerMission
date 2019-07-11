using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainControl710 : MonoBehaviour
{
    public List<DragBehavior> CharLis;
    public List<Transform> SLandLis1;
    public List<Transform> SLandLis2;
    public List<Transform> SBoatLis;


    public List<GameObject> LandLis1 = new List<GameObject>();
    public List<GameObject> LandLis2 = new List<GameObject>();
    public List<GameObject> BoatLis = new List<GameObject>();

    public Transform boat;
    public List<Transform> shipPoints;
    public bool isLeft;


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
                KaiChuan(c2d.gameObject);
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
            IntoSomePlace(CharLis[i]);
        }

        boat.transform.position = shipPoints[0].transform.position;
        isLeft = true;
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

    public void KaiChuan(GameObject _btn)
    {
        //print("开船");
        if (!IsObjInPlace(ObjType.Farmer, PlaceName.Boat) || !IsKaichuan())
        {
            print("Error");
            return;
        }

        Vector3 v3;
        if (isLeft)
            v3 = shipPoints[1].transform.position;
        else
            v3 = shipPoints[0].transform.position;
        boat.transform.DOMove(v3, 1f).SetEase(Ease.Linear).
            OnStart(() => { _btn.SetActive(false); }).
            OnComplete(() =>
            {
                _btn.SetActive(true);
                isLeft = !isLeft;
                Landing();
            });
    }

    private bool IsKaichuan()
    {
        if (IsObjInPlace(ObjType.Wolf, PlaceName.LLand) && IsObjInPlace(ObjType.Sheep, PlaceName.LLand))
            return false;
        if (IsObjInPlace(ObjType.Wolf, PlaceName.RLand) && IsObjInPlace(ObjType.Sheep, PlaceName.RLand))
            return false;
        if (IsObjInPlace(ObjType.Cai, PlaceName.LLand) && IsObjInPlace(ObjType.Sheep, PlaceName.LLand))
            return false;
        if (IsObjInPlace(ObjType.Cai, PlaceName.RLand) && IsObjInPlace(ObjType.Sheep, PlaceName.RLand))
            return false;

        return true;
    }

    private bool IsObjInPlace(ObjType _type, PlaceName _place)
    {
        if (_place == PlaceName.Boat)
        {
            foreach (var item in BoatLis)
            {
                if (item.GetComponent<DragBehavior>().type == _type)
                    return true;
            }
            return false;
        }
        else if (_place == PlaceName.LLand)
        {
            foreach (var item in LandLis1)
            {
                if (item.GetComponent<DragBehavior>().type == _type)
                    return true;
            }
            return false;
        }
        else if (_place == PlaceName.RLand)
        {
            foreach (var item in LandLis2)
            {
                if (item.GetComponent<DragBehavior>().type == _type)
                    return true;
            }
            return false;
        }

        return false;
    }

    private void Landing()
    {
        if (BoatLis.Count > 0)
        {
            List<GameObject> _tBoatLis = new List<GameObject>();
            foreach (var item in BoatLis)
            {
                _tBoatLis.Add(item);
            }
            foreach (var item in _tBoatLis)
            {
                List<Transform> _tLis = new List<Transform>();
                if (isLeft)
                    _tLis = SLandLis1;
                else
                    _tLis = SLandLis2;
                foreach (var j in _tLis)
                {
                    if (j.childCount == 0)
                    {
                        item.transform.SetParent(j);
                        item.transform.localPosition = Vector2.zero;
                        DragBehavior db = item.GetComponent<DragBehavior>();
                        if (isLeft)
                            db.belongPlace = PlaceName.LLand;
                        else
                            db.belongPlace = PlaceName.RLand;
                        IntoSomePlace(db);
                        break;
                    }
                }
            }
        }
    }
}

public enum PlaceName
{
    LLand,
    RLand,
    Boat
}

public enum ObjType
{
    Farmer,
    Wolf,
    Sheep,
    Cai
}
