using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceStat : MonoBehaviour
{
    [SerializeField]
    float maxHp = 100.0f;
    float curHp;
    float height = 1.0f;
    [SerializeField]
    GameObject dropItem;
    [SerializeField]
    Image hpBar;

    public void Damaging(float damage)
    {
        if (curHp > damage)
        {
            curHp -= damage;

            hpBar.transform.parent.gameObject.SetActive(true);
            hpBar.fillAmount = curHp / maxHp;
            Vector3 targetPos = new Vector3(transform.position.x, transform.position.y + height, 0);
            hpBar.transform.parent.GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(targetPos);
        }
        else if (curHp > 0)
        {
            curHp = 0;
        }
        else
        {
            Debug.Log("hp가 음수입니다.");
        }
        if (curHp == 0)
        {
            Destroy(gameObject);
            Instantiate(dropItem, transform.position, Quaternion.identity);
            hpBar.transform.parent.gameObject.SetActive(false);
        }
    }

    public void Hit(float scale)
    {
        Damaging(scale);
    }

    // Start is called before the first frame update
    void Start()
    {
        curHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
