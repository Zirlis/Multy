using System;
using UnityEngine;
using TMPro;
using System.Collections;

namespace Multipliers
{
    public class NewInLine : MonoBehaviour
    {
        private Movement Movement;

        private bool _collisionWithSomethingOtherThanBack = false;

        private void Start()
        {
            Movement = GetComponent<Movement>();

            AddBeginDrag.OnBeginDrag += RecalculationOnBeginDrag;
            MultiplierCollider.OnEndDrag += RecalculationOnEndDrag;
        }

        private void RecalculationOnEndDrag(GameObject multiplier, GameObject panel)
        {
            if (multiplier.GetComponent<TextMeshProUGUI>().text != "")
            {
                switch (panel.name)
                {
                    case "Back":
                        StartCoroutine(CollisionWithBack(multiplier, multiplier.GetComponent<AddBeginDrag>().Original.transform.parent.gameObject));
                        break;

                    default:
                        _collisionWithSomethingOtherThanBack = true;                        

                        for (int i = 0; i < multiplier.transform.parent.childCount; i++)
                        {

                            var mTMP = panel.transform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>();
                            if (mTMP.text == "")
                            {
                                mTMP.SetText(multiplier.GetComponent<TextMeshProUGUI>().text);
                                if(i != 0)
                                {
                                    panel.transform.GetChild(i + 5).gameObject.SetActive(true);
                                }
                                break;
                            }
                            if (i == multiplier.transform.parent.childCount - 1)
                            {
                                RecalculationOnEndDrag(multiplier, multiplier.GetComponent<AddBeginDrag>().Original.transform.parent.gameObject);
                            }
                        }

                        Recalculation(panel);
                        multiplier.GetComponent<TextMeshProUGUI>().SetText("");
                        multiplier.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                        break;   
                }

                //сейв
            }
            else
            {
                multiplier.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            }
        }

        private void RecalculationOnBeginDrag(GameObject multiplier)
        {
            if (multiplier.GetComponent<TextMeshProUGUI>().text != "")
            {
                switch (multiplier.name)
                {
                    case "Multiplier6 (1)":
                        multiplier.GetComponent<AddBeginDrag>().Original.transform.parent.GetChild(multiplier.transform.GetSiblingIndex() + 5)
                            .gameObject.SetActive(false);
                        break;
                    default:
                        Movement.Coroutine(multiplier);
                        break;
                }
                Recalculation(multiplier.GetComponent<AddBeginDrag>().Original.transform.parent.gameObject);
            }
        }

        private void Recalculation(GameObject panel)
        {
            int composition = 1;

            for (int i = 0; i < 6; i++)
            {
                var text = panel.transform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().text;
                if (text != "")
                {
                    composition *= Int32.Parse(text);
                }
                else
                {
                    break;
                }
            }

            if(composition == 1)
            {
                panel.transform.GetChild(12).gameObject.GetComponent<TextMeshProUGUI>().SetText("");
            }
            else
            {
                panel.transform.GetChild(12).gameObject.GetComponent<TextMeshProUGUI>().SetText($"{composition}");
            }

            //if победка
        }

        private IEnumerator CollisionWithBack(GameObject multiplier, GameObject panel)
        {
            yield return new WaitForEndOfFrame();
            if (!_collisionWithSomethingOtherThanBack)
            {
                RecalculationOnEndDrag(multiplier, panel);
            }
            _collisionWithSomethingOtherThanBack = false;
        }
    }
}