using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

namespace MCasado.UI
{
    public class ModalWindow : MonoBehaviour
    {
        private static ModalWindow instance;

        [HideInInspector] public static TMP_InputField playerName;

        public static void Show(string dialogMessage, Action actionOnConfirm)
        {
            instance.storedActionOnConfirm = actionOnConfirm;
            instance.gameObject.SetActive(true);
        }

        private Action storedActionOnConfirm;
        public Text dialogText;

        void Awake()
        {
            instance = this;
            playerName = GetComponentInChildren<TMP_InputField>();
            gameObject.SetActive(false);
        }
        public void OnConfirmButton()
        {
            if (storedActionOnConfirm != null)
            {
                storedActionOnConfirm();
                storedActionOnConfirm = null;
                gameObject.SetActive(false);

            }
        }
        public void OnCancelButton()
        {
            storedActionOnConfirm = null;
            gameObject.SetActive(false);
        }
    }
}