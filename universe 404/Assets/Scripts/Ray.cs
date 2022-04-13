using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Ray : MonoBehaviour
{
    public static Ray Instance;
    static UnityEngine.Ray ray;
    static RaycastHit hit;
    //
    public GameObject computeOutline;
    public GameObject erjiOutline;
    public GameObject nikeOutline;


    public GameObject pickup;
    public bool canPick = true;
    //
    public static bool isComputer;
    public static bool isErji;
    public static bool isNike;







    //��Ļ�ο����λ��
    public static Vector3 pos;
    
    // Start is called before the first frame update
    void Start()
    {
        canPick = true;
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RayItem();
    }
    public void RayItem()
    {


        //��������
        ray = Camera.main.ScreenPointToRay(pos);
        //������������ײ
        if(Physics.Raycast(ray,out hit, 10.0f))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            //
            //����
            if(hit.transform.name == "computer" && canPick)
            {
                computeOutline.SetActive(true);
                pickup.SetActive(true);
                Debug.Log("666");
            }
            else
            {
                computeOutline.SetActive(false);
                pickup.SetActive(false);
            }
            //����
            if (hit.transform.name == "����" && canPick)
            {
                erjiOutline.SetActive(true);
                pickup.SetActive(true);
                Debug.Log("ɨ�赽��");
            }
            else
            {
                erjiOutline.SetActive(false);
                pickup.SetActive(false);
            }
            //����Ь
            if (hit.transform.name == "�Ϳ�" && canPick)
            {
                nikeOutline.SetActive(true);
                pickup.SetActive(true);
            }
            else
            {
                nikeOutline.SetActive(false);
                pickup.SetActive(false);
            }




            //
            if (Input.GetKey(KeyCode.E))
            {
                if(hit.transform.name == "computer")
                {
                    isComputer = true;
                    canPick = false;
                }
                
                
                else if(hit.transform.name == "����")
                {
                    isErji = true;
                    canPick = false;

                }
                
                
                else if(hit.transform.name == "�Ϳ�")
                {
                    isNike = true;
                    canPick = false;

                }
              
            }
          
        }
        
    }
   
}
