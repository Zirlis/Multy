using System;
using UnityEngine;
using TMPro;

namespace Multipliers
{
    public class NewInLine : MonoBehaviour
    {
        private LevelGenerator LevelGenerator;
        private Movement Movement;
        private void Start()
        {
            LevelGenerator = GetComponent<LevelGenerator>();
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
                        RecalculationOnEndDrag(multiplier, multiplier.GetComponent<AddBeginDrag>().Original.transform.parent.gameObject);
                        break;

                    default:
                        for (int i = 0; i < panel.transform.childCount; i++)
                        {

                            var mTMP = panel.transform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>();
                            var text = mTMP.text;
                            if (text == "")
                            {
                                mTMP.SetText(multiplier.GetComponent<TextMeshProUGUI>().text);
                                if(i != 0)
                                {
                                    panel.transform.GetChild(i + 5).gameObject.SetActive(true);
                                }
                                break;
                            }
                            if (i == panel.transform.childCount - 1)
                            {
                                RecalculationOnEndDrag(multiplier, multiplier.GetComponent<AddBeginDrag>().Original.transform.parent.gameObject);
                            }
                        }

                        Recalculation(panel);
                        multiplier.GetComponent<TextMeshProUGUI>().SetText("");
                        multiplier.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                        break;   
                }

                var siblingIndex = multiplier.transform.GetSiblingIndex();
                if (siblingIndex != 0)
                {
                    multiplier.GetComponent<AddBeginDrag>().Original.transform.parent.GetChild(siblingIndex + 5).gameObject.SetActive(true);
                }

                //сейв
            }

            multiplier.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }

        private void RecalculationOnBeginDrag(GameObject multiplier)
        {
            switch (multiplier.name)
            {
                case "Multiplier6 (1)":
                    LevelGenerator.FirstMultiplication56.SetActive(false);
                    break;
                default:
                    Movement.Coroutine(multiplier);
                    break;
            }
            Recalculation(multiplier.GetComponent<AddBeginDrag>().Original.transform.parent.gameObject);
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
    }
}