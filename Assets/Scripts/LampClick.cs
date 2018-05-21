using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    public class LampClick : MonoBehaviour, IInputClickHandler
    {
        public GameObject toggleThis;

        public void OnInputClicked(InputClickedEventData eventData)
        {
            if (toggleThis != null)
            {
                if (!toggleThis.activeSelf)
                    toggleThis.SetActive(true);
                else
                    toggleThis.SetActive(false);
            }

            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }
    }
}