
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class optionsEffects : MonoBehaviour
{
    public GameObject activitecameraop;
    public bool stophighlight;
    
    public void Selected()
    {
    
        gameObject.GetComponent<Animator>().enabled = true;

       
          
        if (EventSystem.current.alreadySelecting != gameObject)
        {

            stophighlight = false;
            EventSystem.current.SetSelectedGameObject(gameObject);
        }

        if (EventSystem.current.currentSelectedGameObject == gameObject)
        {
        
        
         stophighlight = true;
         gameObject.GetComponent<Animator>().SetTrigger("Pressed");
        gameObject.GetComponent<Animator>().SetBool("isonmouse", true);
        }

         if(EventSystem.current.currentSelectedGameObject != gameObject.CompareTag("Cameraoptions"))
         {
            activitecameraop.SetActive(false);
         }
        else 
         activitecameraop.SetActive(true);
           
                
            
           


    }
    public void highlighted()
    {
       

            if (EventSystem.current.currentSelectedGameObject != gameObject&& (stophighlight != true))
            {
            gameObject.GetComponent<Animator>().SetTrigger("Highlighted");
            }
  
    }

    public void unhighlighted()
    {
       
        if (EventSystem.current.currentSelectedGameObject != gameObject&& (stophighlight   != true))
        {
         gameObject.GetComponent<Animator>().SetTrigger("Normal");
        }
        
    }
    public void unSelected()
    {
 
       stophighlight = false;   
        gameObject.GetComponent<Animator>().SetTrigger("Normal");
        if (EventSystem.current.currentSelectedGameObject != null )
        {
            gameObject.GetComponent<Animator>().SetBool("isonmouse", false);
        }
     
    }
     

  
}
