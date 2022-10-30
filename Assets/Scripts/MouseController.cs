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

        //���콺�� UI ���� ���� �ʴٸ�
        if (EventSystem.current.IsPointerOverGameObject() == false)
        {
            //�Ÿ��� 3.5 �̻����� �ָ� Selector �Ⱥ��̰�
            if (Vector2.Distance(selectPos, transform.parent.position) > 3.5)
            {
                sprite.color = new Color(0, 0, 0, 0);
            }
            //�Ÿ��� 1.5 �̻����� �ָ� Selector ����������
            else if (Vector2.Distance(selectPos, transform.parent.position) > 1.5)
            {
                transform.position = selectPos;
                sprite.color = Color.red;
            }
            //�Ÿ��� ������
            else
            {
                transform.position = selectPos;
                sprite.color = Color.white;
                //���콺 ��Ŭ�� �� ray�� ������Ʈ Ȯ�� �� ���ӿ�����Ʈ�� ������ ó��
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

                    if (hit.collider != null && hit.collider.name != "Object")
                    {
                        // raycast hit this gameobject
                        Debug.Log(hit.collider.name);
                    }
                    //ray�� Object Ÿ�ϸ��� ������ Ȯ�� �� ó��
                    else
                    {
                        //tileMap.SetTile(selectPosInt, changeTile);
                        Instantiate(changeObject, selectPosInt, Quaternion.identity);
                    }
                }
                //��Ŭ��
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
                        Debug.Log("�ش� ������ ������Ʈ�� �������� �ʽ��ϴ�.");
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
