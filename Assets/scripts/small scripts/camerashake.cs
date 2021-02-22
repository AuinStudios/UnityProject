using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerashake : MonoBehaviour
{

    
      
    public IEnumerator Shake(float time, float magtinude)
    {
  Vector3 originalpos = transform.localPosition;
        float eleasped = 0.0f;
        while ( eleasped < time)
        {
            float x = Random.Range(-1f, 1f) * magtinude;
            float y = Random.Range(-1f, 1f) * magtinude;

            transform.localPosition = new Vector3(x, y, originalpos.z);

            eleasped += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalpos;
    }


    
}
