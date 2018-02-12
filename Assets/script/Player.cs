using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;
public class Player : MonoBehaviour {

    float KEYBOARD_SPEED = 0.0015f;
    float KEYBOARD_MOVE_LEN = 0.04f;

    void Start () {

    }
    // Update is called once per frame
    void FixedUpdate() {
        MoveByKeyBoard();
    }


    void OnTriggerEnter2D(Collider2D other)
    {


        
         if(other.tag == "EnemyBullet")
         {
             Destroy(other.gameObject);
             this.transform.position = new Vector3(0, -4, 0);
             var objs =GameObject.FindGameObjectsWithTag("EnemyBullet");
             GameObject.Find("Main Camera").GetComponent<SceneControl>().now = 0;
             foreach(GameObject a in objs)
             {
                 Destroy(a);
             }
         }
         


    }

    /// <summary>
    /// 键盘移动
    /// </summary>
    void MoveByKeyBoard()
    {

        Vector3 newPlayerPosition = transform.position;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            newPlayerPosition.y += KEYBOARD_MOVE_LEN;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            newPlayerPosition.y -= KEYBOARD_MOVE_LEN ;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newPlayerPosition.x -= KEYBOARD_MOVE_LEN ;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            newPlayerPosition.x += KEYBOARD_MOVE_LEN;
        }

        if(newPlayerPosition.x< -2.752 || newPlayerPosition.x > 2.752)
        {
            newPlayerPosition.x = transform.position.x;
        }
        if (newPlayerPosition.y < -4.958 || newPlayerPosition.y > 4.958)
        {
            newPlayerPosition.y = transform.position.y;
        }

        if (newPlayerPosition == transform.position) return;

        iTween.MoveTo(this.gameObject, newPlayerPosition, KEYBOARD_SPEED);
        
    }




}
