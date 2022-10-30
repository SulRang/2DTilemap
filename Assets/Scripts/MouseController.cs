using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;


public class MouseController : MonoBehaviour
{
    SpriteRenderer sprite;
    Vector2 mousePos;

    [SerializeField]
    Tilemap tileMap;
    [SerializeField]
    TileBase changeTile;
    [SerializeField]
    GameObject changeObject;

    GameObject equipment;

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

        //마우스가 UI 위에 있지 않다면
        if (EventSystem.current.IsPointerOverGameObject() == false)
        {
            //거리가 3.5 이상으로 멀면 Selector 안보이게
            if (Vector2.Distance(selectPos, transform.parent.position) > 3.5)
            {
                sprite.color = new Color(0, 0, 0, 0);
            }
            //거리가 1.5 이상으로 멀면 Selector 빨강색으로
            else if (Vector2.Distance(selectPos, transform.parent.position) > 1.5)
            {
                transform.position = selectPos;
                sprite.color = Color.red;
            }
            //거리가 가까우면
            else
            {
                transform.position = selectPos;
                sprite.color = Color.white;
                //마우스 좌클릭 시 ray로 오브젝트 확인 후 게임오브젝트가 있으면 처리
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

                    if (hit.collider != null && hit.collider.name != "Object")
                    {
                        // raycast hit this gameobject
                        Debug.Log(hit.collider.name);
                    }
                    //ray에 Object 타일맵이 나오면 확인 후 처리
                    else
                    {
                        //tileMap.SetTile(selectPosInt, changeTile);
                        Instantiate(changeObject, selectPosInt, Quaternion.identity);
                    }
                }
                //우클릭
                if (Input.GetMouseButtonDown(1))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit2D[] hitList = Physics2D.GetRayIntersectionAll(ray, Mathf.Infinity);

                    if (hitList.Length != 0)
                    {
                        foreach(RaycastHit2D hit in hitList)
                        {
                            // raycast hit this gameobject
                            Debug.Log(hit.collider.name);
                            if(hit.collider.tag == "Object")
                                hit.collider.GetComponent<ResourceStat>().Hit(20);
                        }
                    }
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
        else
        {
            sprite.color = new Color(0, 0, 0, 0);

        }

    }

    public Vector2 GetMousePos()
    {
        return mousePos;
    }



}
