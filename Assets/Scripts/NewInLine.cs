using System;
using UnityEngine;
using TMPro;
using System.Collections;

namespace Multipliers
{
    public class NewInLine : MonoBehaviour
    {
        private Movement _movement;
        private Victory _victory;
        [SerializeField] SaveManagerGameScene _saveManagerGameScene;

        [HideInInspector] public bool CollisionWithSomethingOtherThanBack = false;

        [HideInInspector] public GameObject LastTouched;

        private void Awake()
        {
            _movement = GetComponent<Movement>();
            _victory = GetComponent<Victory>();
        }

        private void OnEnable()
        {
            AddBeginDrag.OnBeginDrag += RecalculationOnBeginDrag;
            MultiplierCollider.OnEndDrag += RecalculationOnEndDrag;
        }

        private void OnDestroy()
        {
            AddBeginDrag.OnBeginDrag -= RecalculationOnBeginDrag;
            MultiplierCollider.OnEndDrag -= RecalculationOnEndDrag;
        }

        public void RecalculationOnEndDrag(GameObject multiplier, GameObject panel)
        {
            if (multiplier.GetComponent<TextMeshProUGUI>().text != "")
            {
                switch (panel.name)
                {
                    case "Back":
                        StartCoroutine(CollisionWithBack(multiplier, multiplier.GetComponent<AddBeginDrag>().Original.transform.parent.gameObject));
                        break;
                    case "Reserve":
                        CollisionWithSomethingOtherThanBack = true;

                        for (int i = 0; i < panel.transform.childCount; i++)
                        {
                            var mTMP = panel.transform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>();
                            if (mTMP.text == "")
                            {
                                mTMP.SetText(multiplier.GetComponent<TextMeshProUGUI>().text);
                                break;
                            }
                            if (i == panel.transform.childCount - 1)
                            {
                                RecalculationOnEndDrag(multiplier, multiplier.GetComponent<AddBeginDrag>().Original.transform.parent.gameObject);
                            }
                        }

                        multiplier.GetComponent<TextMeshProUGUI>().SetText("");
                        multiplier.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                        break;
                    case "FirstPanel":
                        CollisionWithSomethingOtherThanBack = true;                        

                        for (int i = 0; i < 6; i++)
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
                            if (i == 5)
                            {
                                RecalculationOnEndDrag(multiplier, multiplier.GetComponent<AddBeginDrag>().Original.transform.parent.gameObject);
                            }
                        }

                        Recalculation(panel);
                        multiplier.GetComponent<TextMeshProUGUI>().SetText("");
                        multiplier.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                        break;
                    case "SecondPanel":
                        CollisionWithSomethingOtherThanBack = true;

                        for (int i = 0; i < 6; i++)
                        {
                            var mTMP = panel.transform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>();
                            if (mTMP.text == "")
                            {
                                mTMP.SetText(multiplier.GetComponent<TextMeshProUGUI>().text);
                                if (i != 0)
                                {
                                    panel.transform.GetChild(i + 5).gameObject.SetActive(true);
                                }
                                break;
                            }
                            if (i == 5)
                            {
                                RecalculationOnEndDrag(multiplier, multiplier.GetComponent<AddBeginDrag>().Original.transform.parent.gameObject);
                            }
                        }

                        Recalculation(panel);
                        multiplier.GetComponent<TextMeshProUGUI>().SetText("");
                        multiplier.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                        break;
                    case "ThirdPanel":
                        CollisionWithSomethingOtherThanBack = true;

                        for (int i = 0; i < 6; i++)
                        {
                            var mTMP = panel.transform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>();
                            if (mTMP.text == "")
                            {
                                mTMP.SetText(multiplier.GetComponent<TextMeshProUGUI>().text);
                                if (i != 0)
                                {
                                    panel.transform.GetChild(i + 5).gameObject.SetActive(true);
                                }
                                break;
                            }
                            if (i == 5)
                            {
                                RecalculationOnEndDrag(multiplier, multiplier.GetComponent<AddBeginDrag>().Original.transform.parent.gameObject);
                            }
                        }

                        Recalculation(panel);
                        multiplier.GetComponent<TextMeshProUGUI>().SetText("");
                        multiplier.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                        break;
                }

                _saveManagerGameScene.Save();
            }
            else
            {
                multiplier.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                CollisionWithSomethingOtherThanBack = false;
            }

            SecondaryInformation.IsContinuation = false;
        }

        private void RecalculationOnBeginDrag(GameObject multiplier)
        {
            LastTouched = multiplier;

            if (multiplier.GetComponent<TextMeshProUGUI>().text != "")
            {
                if (multiplier.transform.parent.name != "ReserveClones")
                {
                    switch (multiplier.name)
                    {
                        case "Multiplier6 (1)":
                            multiplier.GetComponent<AddBeginDrag>().Original.transform.parent
                                .GetChild(multiplier.transform.GetSiblingIndex() + 5)
                                .gameObject.SetActive(false);
                            break;
                        default:
                            _movement.Coroutine(multiplier);
                            break;
                    }
                    Recalculation(multiplier.GetComponent<AddBeginDrag>().Original.transform.parent.gameObject);
                }                
            }
        }

        public void Recalculation(GameObject panel)
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

            _victory.CheckVictory();
        }

        private IEnumerator CollisionWithBack(GameObject multiplier, GameObject panel)
        {
            yield return new WaitForEndOfFrame();
            if (!CollisionWithSomethingOtherThanBack)
            {
                RecalculationOnEndDrag(multiplier, panel);
            }
            CollisionWithSomethingOtherThanBack = false;
        }        
    }
}