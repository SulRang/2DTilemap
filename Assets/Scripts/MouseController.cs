using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MouseController : MonoBehaviour
{
    SpriteRenderer sprite;
    Vector2 mousePos;

    [SerializeField]
    Tilemap tileMap;
    [SerializeField]
    TileBase changeTile;


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 selectPos = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));
        Vector3Int selectPosInt = new Vector3Int(((int)selectPos.x), (int)selectPos.y, 0);
        transform.position = selectPos;
        if(Vector2.Distance(transform.position, transform.parent.position) > 2.7)
        {
            sprite.color = Color.red;
        }
        else
        {
            sprite.color = Color.white;
            
            if (Input.GetMouseButtonDown(0))
            {
                tileMap.SetTile(selectPosInt, changeTile);
            }
            
            if (Input.GetMouseButtonDown(1))
            {
                try
                {
                    Debug.Log(tileMap.GetTile(selectPosInt).name);
                }
                catch (System.NullReferenceException)
                {
                    Debug.Log("해당 지점에 오브젝트가 존재하지 않습니다.");
                }
            }
        }

    }

    public Vector2 GetMousePos()
    {
        return mousePos;
    }



}
