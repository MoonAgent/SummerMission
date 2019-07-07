using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class randomcolor : MonoBehaviour
{



    float timer;

    // Use this for initialization

    void Start()

    {

    }

    // Update is called once per frame

    void Update()

    {

        //timer均匀减少

        timer -= Time.deltaTime;

        //如果timer小于等于零

        if (timer <= 0)

        {

            //给渲染器赋值

            this.gameObject.GetComponent<MeshRenderer>().material.color = RandomColor();

            //timer重置

            timer = 1;

        }

    }



    //Color类型的方法，返回一个color值

    public Color RandomColor()

    {

        //r、g、b分别随机从0-1之间取值

        float r = Random.Range(0f, 1f);

        float g = Random.Range(0f, 1f);

        float b = Random.Range(0f, 1f);

        //实例化一个color，并把r,g,b传进去

        Color color = new Color(r, g, b);

        //返回一个color值

        return color;

    }

}