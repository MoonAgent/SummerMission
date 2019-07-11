using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragBehavior : MonoBehaviour,IDragHandler,IEndDragHandler
{
    public ObjType type;
    public GameObject triggerObj;
    public PlaceName belongPlace;
    public MainControl710 mainControl;

    void Start()
    {
        triggerObj = null;
    }
    
    void Update()
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        //print(eventData.position);
        Vector3 v3 = Camera.main.ScreenToWorldPoint(eventData.position);
        this.transform.position = new Vector3(v3.x, v3.y, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "land" || collision.tag == "boat" || collision.tag == "land2")
        {
            triggerObj = collision.gameObject;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (triggerObj == null)
            return;

        if (triggerObj.tag == "boat")
        {
            if (mainControl.isLeft)
            {
                if (belongPlace == PlaceName.LLand || belongPlace == PlaceName.Boat)
                    SetSeat(PlaceName.Boat);
                else
                    ReturnOrignPlace();
            }
            else if (!mainControl.isLeft)
            {
                if (belongPlace == PlaceName.RLand || belongPlace == PlaceName.Boat)
                    SetSeat(PlaceName.Boat);
                else
                    ReturnOrignPlace();
            }

        }
        else if (triggerObj.tag == "land")
        {
            if (mainControl.isLeft)
            {
                if (belongPlace == PlaceName.Boat)
                    SetSeat(PlaceName.LLand);
                else
                    ReturnOrignPlace();
            }
            else
                ReturnOrignPlace();

            if (belongPlace == PlaceName.LLand)
                SetSeat(PlaceName.LLand);
        }
        else if (triggerObj.tag == "land2")
        {
            if (!mainControl.isLeft)
            {
                if (belongPlace == PlaceName.Boat)
                    SetSeat(PlaceName.RLand);
                else
                    ReturnOrignPlace();
            }
            else
                ReturnOrignPlace();

            if (belongPlace == PlaceName.RLand)
                SetSeat(PlaceName.RLand);
        }
    }

    private void SetSeat(PlaceName _PN)
    {
        if (triggerObj.transform.childCount == 0)
        {
            belongPlace = _PN;
            this.transform.SetParent(triggerObj.transform);
            this.transform.localPosition = Vector2.zero;
        }
        else if (triggerObj.transform.childCount == 1)
        {
            GameObject _obj = triggerObj.transform.GetChild(0).gameObject;
            Transform _tp = this.transform.parent;
            PlaceName _pn = this.belongPlace;

            transform.parent = _obj.transform.parent.transform;
            _obj.transform.parent = _tp;
            belongPlace = _obj.GetComponent<DragBehavior>().belongPlace;
            _obj.GetComponent<DragBehavior>().belongPlace = _pn;

            this.transform.localPosition = Vector2.zero;
            _obj.transform.localPosition = Vector2.zero;
            mainControl.IntoSomePlace(_obj.GetComponent<DragBehavior>());
        }
        mainControl.IntoSomePlace(this);
    }

    private void ReturnOrignPlace()
    {
        this.transform.localPosition = Vector2.zero;
    }
}
