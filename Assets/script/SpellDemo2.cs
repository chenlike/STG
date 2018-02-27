using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Utils;


public class SpellDemo2 : SpellCard
{

    GameObject[] _tem = new GameObject[6];
    BulletShooter _bltShooter;

    Vector3 rotateVec = new Vector3(-0.2f, 0.3f, 0);




    /// <summary>
    ///  five loop
    /// </summary>
    /// <param name="mainVector">主要向量</param>
    /// <param name="isEmpty">是否调用CreateArcDanmuEmpty</param>
    /// <param name="idx">tem</param>
    /// <param name="pushLength">前推距离</param>
    /// <param name="startAngle">起始角度</param>
    /// <param name="endAngle">结束角度</param>
    /// <param name="angleStep">stop</param>
    /// <param name="speed">飞行速度</param>
    /// <param name="cardsDivideAngle">每4张符卡随着时间推移的分散速度</param>
    /// <returns></returns>
    List<List<GameObject>> Five(Vector3 mainVector,bool isEmpty = true,int idx=0,float pushLength = 0.5f, float startAngle=161f,float endAngle=268f,float angleStep=72f,float speed=0f,float cardsDivideAngle = 2.5f)
    {
        List<List<GameObject>> all = new List<List<GameObject>>();
        //内圈
        for (int i = 0; i < 5; i++)
        {
            List<GameObject> list;// = new List<GameObject>();
            if(isEmpty)
            {
                list = Danmu.CircleDanmu.CreateArcDanmuEmpty(
                _tem[idx], //template
                MathUtils.RotationMatrix(mainVector, angleStep * i),//vector
                startAngle - angleStep * i, //startAngle
                endAngle - angleStep * i,//endAngle
                40, //num
                speed);//speed
            }
            else
            {
                list = Danmu.CircleDanmu.CreateArcDanmu(
                _tem[idx], //template
                MathUtils.RotationMatrix(mainVector, angleStep * i),//vector
                startAngle - angleStep * i, //startAngle
                endAngle - angleStep * i,//endAngle
                40, //num
                speed);//speed
            }

            Utils.DanmuUtils.PushObjLength(list, pushLength);
            for (int j = 0; j < list.Count-3; j += 4)
            {

                //0 1 2 3         4 5 6 7           8 9 10 11     12 13 14 15   16 17 18 19
                //20 21 22 23  24 25 26 27  28 29 30 31  32 33 34 35  36 37 38 39
                for (int k = 0; k < 4; k++)
                {
                    DanmuUtils.ChangeFocus(list[j +k], MathUtils.RotationMatrix(rotateVec, 72 * i));
                }
                float angle = (list[j+1].transform.eulerAngles.z + list[j + 2].transform.eulerAngles.z)/2;
                //每4张符卡随着时间推移的分散速度
                for (int k = 0; k < 4; k++)
                {
                   DanmuUtils.ChangeFaceAngle(list[j + k], angle + cardsDivideAngle * k);
                }
            }
            all.Add(list);
           
        }
        return all;
    }

    
    void TestStart(GameObject obj)
    {


        _bltShooter.Shoot(Five(rotateVec,speed:0f));
        _bltShooter.Shoot(Five(
                mainVector: new Vector3(0,0.7f,0),
                idx:1,
                pushLength: 0.48f,
                startAngle: 92f,
                endAngle: 267f,
                angleStep: 72,
                speed:0f,
                cardsDivideAngle:1.8f
            )
            );

            _bltShooter.Shoot(Five(
                isEmpty:false,
                mainVector: new Vector3(0,-0.73f, 0),
                idx: 2,
                pushLength: 0.75f,
                startAngle: 100.5f,
                endAngle: 259.53f,
                angleStep: 72,
                speed: 0f,
                cardsDivideAngle: 5f
            ));         
         
         

    }
    public override void Prepare()
    {
        InitRes();
        _bltShooter = CreateEmptyBulletShooter();
        _bltShooter.startEvent += TestStart;

    }

    public override void Spell()
    {
        _bltShooter.SetEnable();
    }

    public override void StopSpell()
    {

    }







    void InitRes()
    {
        _tem[0] = PublicObj.Template.GetTemplate("redCard");
        _tem[1] = PublicObj.Template.GetTemplate("pupCard");
        _tem[2] = PublicObj.Template.GetTemplate("blueCard");
        _tem[3] = PublicObj.Template.GetTemplate("lightGreenCard");
        _tem[4] = PublicObj.Template.GetTemplate("greenCard");
        _tem[5] = PublicObj.Template.GetTemplate("lightBlueCard");
    }
}
