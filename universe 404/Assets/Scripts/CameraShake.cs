using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public static CameraShake Instance;
    // Start is called before the first frame update

    private void Start()
    {
        Instance = this;
    }
  
    public void canShake(float ShakeRange,float ShakeTime)
    {
        StopAllCoroutines();
        StartCoroutine(Shake(ShakeRange ,ShakeTime));
    }
    public void canHorShake(float ShakeRange, float ShakeTime)
    {
        StopAllCoroutines();
        StartCoroutine(HorShake(ShakeRange, ShakeTime));
    }
    public IEnumerator Shake(float ShakeRange,float ShakeTime)
    {
        Vector3 currentPos = transform.position;
        
        while (ShakeTime >= 0)
        {
            if(ShakeTime <= 0)
            {
                break;
            }
            ShakeTime -= Time.deltaTime;
            Vector3 pos = transform.position;
            pos.x += Random.Range(-ShakeRange, ShakeRange);
            pos.y += Random.Range(-ShakeRange, ShakeRange);
            transform.position = pos;

            yield return null;
        }
        transform.position = currentPos;
    }

    public IEnumerator HorShake(float ShakeRange, float ShakeTime)
    {
        Vector3 currentPos = transform.position;

        while (ShakeTime >= 0)
        {
            if (ShakeTime <= 0)
            {
                break;
            }
            ShakeTime -= 0.002f;
            Vector3 pos = transform.position;
            pos.x += Random.Range(-ShakeRange, ShakeRange);
            pos.y += Random.Range(-ShakeRange * 0.5f, ShakeRange * 0.5f);
            transform.position = pos;

            yield return null;
        }
        transform.position = currentPos;
    }
}
