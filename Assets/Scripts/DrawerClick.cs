using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    public class DrawerClick : MonoBehaviour, IInputClickHandler
    {
        public void OnInputClicked(InputClickedEventData eventData)
        {
            if (!gameObject.GetComponent<Animator>().GetBool("moveDrawer"))
                gameObject.GetComponent<Animator>().SetBool("moveDrawer", true);
            else
                gameObject.GetComponent<Animator>().SetBool("moveDrawer", false);

            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }
    }
}


