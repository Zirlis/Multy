using System;
using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

namespace Multipliers
{
    public class NewInLine : MonoBehaviour
    {
        private Movement Movement;

        private bool _collisionWithSomethingOtherThanBack = false;

        [Header("Compositions")]
        [SerializeField] private TextMeshProUGUI _firstCompositionRight;
        [SerializeField] private TextMeshProUGUI _firstCompositionLeft;
        [SerializeField] private TextMeshProUGUI _secondCompositionRight;
        [SerializeField] private TextMeshProUGUI _secondCompositionLeft;
        [SerializeField] private TextMeshProUGUI _thirdCompositionRight;
        [SerializeField] private TextMeshProUGUI _thirdCompositionLeft;

        [Header("VictoryPanel")]
        [SerializeField] private RectTransform _victoryPanel;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Image _randomImageOnVicroryPanel1;
        [SerializeField] private Image _randomImageOnVicroryPanel2;

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
                    case "Reserve":
                        _collisionWithSomethingOtherThanBack = true;

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
                    default:
                        _collisionWithSomethingOtherThanBack = true;                        

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

                        Recalculation(panel, multiplier);
                        multiplier.GetComponent<TextMeshProUGUI>().SetText("");
                        multiplier.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                        break;   
                }

                //сейв
            }
            else
            {
                multiplier.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                _collisionWithSomethingOtherThanBack = false;
            }
        }

        private void RecalculationOnBeginDrag(GameObject multiplier)
        {
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
                            Movement.Coroutine(multiplier);
                            break;
                    }
                    Recalculation(multiplier.GetComponent<AddBeginDrag>().Original.transform.parent.gameObject, multiplier);
                }                
            }
        }

        private void Recalculation(GameObject panel, GameObject multiplier)
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

            CheckVictory(multiplier);
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

        private void CheckVictory(GameObject multiplier)
        {
            bool first;
            bool second;
            bool third;

            if(_firstCompositionLeft.text == _firstCompositionRight.text)
            {
                //анимация первой панели
                first = true;
            }
            else
            {
                //анимация первой панели
                first = false;
            }
            if (_secondCompositionLeft.text == _secondCompositionRight.text)
            {
                //анимация второй панели
                second = true;
            }
            else
            {
                //анимация второй панели
                second = false;
            }
            if (_thirdCompositionLeft.text == _thirdCompositionRight.text)
            {
                //анимация третьей панели
                third = true;
            }
            else
            {
                //анимация третьей панели
                third = false;
            }
            
            if(first && second && third)
            {

            }
        }
    }
}