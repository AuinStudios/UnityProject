
using UnityEngine;

public class TimeSlowmaybetimestop : MonoBehaviour
{

    public float slowdownfactor = 0.05f;
    public float slowdownlength = 2f;

    private void Update()
    {
        // fixes the   game looking like its laging
        Time.timeScale += (1f / slowdownlength) * Time.unscaledDeltaTime;

        // clamps the time so it does make it go faster
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    public void time()
    {//  variable to optimize slow down tie
        Time.timeScale = slowdownfactor;
        // slows down time
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }

}
