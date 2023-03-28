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
            switch (panel.name)
            {
                case "FirstPlane":
                    if (LevelGenerator.FirstMultiplier1.text != "")
                    {
                        if (LevelGenerator.FirstMultiplier2.text != "")
                        {
                            if (LevelGenerator.FirstMultiplier3.text != "")
                            {
                                if (LevelGenerator.FirstMultiplier4.text != "")
                                {
                                    if (LevelGenerator.FirstMultiplier5.text != "")
                                    {
                                        if (LevelGenerator.FirstMultiplier6.text != "")
                                        {
                                            RecalculationOnEndDrag(multiplier, multiplier.GetComponent<AddBeginDrag>().Original.transform.parent.gameObject);
                                        }
                                        else
                                        {
                                            LevelGenerator.FirstMultiplier6.SetText($"{multiplier.GetComponent<TextMeshProUGUI>().text}");
                                        }
                                    }
                                    else
                                    {
                                        LevelGenerator.FirstMultiplier5.SetText($"{multiplier.GetComponent<TextMeshProUGUI>().text}");
                                    }
                                }
                                else
                                {
                                    LevelGenerator.FirstMultiplier4.SetText($"{multiplier.GetComponent<TextMeshProUGUI>().text}");
                                }
                            }
                            else
                            {
                                LevelGenerator.FirstMultiplier3.SetText($"{multiplier.GetComponent<TextMeshProUGUI>().text}");
                            }
                        }
                        else
                        {
                            LevelGenerator.FirstMultiplier2.SetText($"{multiplier.GetComponent<TextMeshProUGUI>().text}");
                        }
                    }
                    else
                    {
                        LevelGenerator.FirstMultiplier1.SetText($"{multiplier.GetComponent<TextMeshProUGUI>().text}");
                    }
                    Recalculation(panel.name);
                    multiplier.GetComponent<TextMeshProUGUI>().SetText("");
                    multiplier.transform.position = multiplier.GetComponent<AddBeginDrag>().Original.transform.position;
                    break;
                case "SecondPlane":
                    if (LevelGenerator.SecondMultiplier1.text != "")
                    {
                        if (LevelGenerator.SecondMultiplier2.text != "")
                        {
                            if (LevelGenerator.SecondMultiplier3.text != "")
                            {
                                if (LevelGenerator.SecondMultiplier4.text != "")
                                {
                                    if (LevelGenerator.SecondMultiplier5.text != "")
                                    {
                                        if (LevelGenerator.SecondMultiplier6.text != "")
                                        {
                                            RecalculationOnEndDrag(multiplier, multiplier.GetComponent<AddBeginDrag>().Original.transform.parent.gameObject);
                                        }
                                        else
                                        {
                                            LevelGenerator.SecondMultiplier6.SetText($"{multiplier.GetComponent<TextMeshProUGUI>().text}");
                                        }
                                    }
                                    else
                                    {
                                        LevelGenerator.SecondMultiplier5.SetText($"{multiplier.GetComponent<TextMeshProUGUI>().text}");
                                    }
                                }
                                else
                                {
                                    LevelGenerator.SecondMultiplier4.SetText($"{multiplier.GetComponent<TextMeshProUGUI>().text}");
                                }
                            }
                            else
                            {
                                LevelGenerator.SecondMultiplier3.SetText($"{multiplier.GetComponent<TextMeshProUGUI>().text}");
                            }
                        }
                        else
                        {
                            LevelGenerator.SecondMultiplier2.SetText($"{multiplier.GetComponent<TextMeshProUGUI>().text}");
                        }
                    }
                    else
                    {
                        LevelGenerator.SecondMultiplier1.SetText($"{multiplier.GetComponent<TextMeshProUGUI>().text}");
                    }
                    Recalculation(panel.name);
                    multiplier.GetComponent<TextMeshProUGUI>().SetText("");
                    multiplier.transform.position = multiplier.GetComponent<AddBeginDrag>().Original.transform.position;                    
                    break;
                case "ThirdPlane":
                    if (LevelGenerator.ThirdMultiplier1.text != "")
                    {
                        if (LevelGenerator.ThirdMultiplier2.text != "")
                        {
                            if (LevelGenerator.ThirdMultiplier3.text != "")
                            {
                                if (LevelGenerator.ThirdMultiplier4.text != "")
                                {
                                    if (LevelGenerator.ThirdMultiplier5.text != "")
                                    {
                                        if (LevelGenerator.ThirdMultiplier6.text != "")
                                        {
                                            RecalculationOnEndDrag(multiplier, multiplier.GetComponent<AddBeginDrag>().Original.transform.parent.gameObject);
                                        }
                                        else
                                        {
                                            LevelGenerator.ThirdMultiplier6.SetText($"{multiplier.GetComponent<TextMeshProUGUI>().text}");
                                        }
                                    }
                                    else
                                    {
                                        LevelGenerator.ThirdMultiplier5.SetText($"{multiplier.GetComponent<TextMeshProUGUI>().text}");
                                    }
                                }
                                else
                                {
                                    LevelGenerator.ThirdMultiplier4.SetText($"{multiplier.GetComponent<TextMeshProUGUI>().text}");
                                }
                            }
                            else
                            {
                                LevelGenerator.ThirdMultiplier3.SetText($"{multiplier.GetComponent<TextMeshProUGUI>().text}");
                            }
                        }
                        else
                        {
                            LevelGenerator.ThirdMultiplier2.SetText($"{multiplier.GetComponent<TextMeshProUGUI>().text}");
                        }
                    }
                    else
                    {
                        LevelGenerator.ThirdMultiplier1.SetText($"{multiplier.GetComponent<TextMeshProUGUI>().text}");
                    }
                    Recalculation(panel.name);
                    multiplier.GetComponent<TextMeshProUGUI>().SetText("");
                    multiplier.transform.position = multiplier.GetComponent<AddBeginDrag>().Original.transform.position;
                    break;
                case "Reserve":
                    if (LevelGenerator.ReservMultiplier1.text != "")
                    {
                        if (LevelGenerator.ReservMultiplier2.text != "")
                        {
                            if (LevelGenerator.ReservMultiplier3.text != "")
                            {
                                if (LevelGenerator.ReservMultiplier4.text != "")
                                {
                                    if (LevelGenerator.ReservMultiplier5.text != "")
                                    {
                                        if (LevelGenerator.ReservMultiplier6.text != "")
                                        {
                                            if (LevelGenerator.ReservMultiplier7.text != "")
                                            {
                                                if (LevelGenerator.ReservMultiplier8.text != "")
                                                {
                                                    if (LevelGenerator.ReservMultiplier9.text != "")
                                                    {
                                                        if (LevelGenerator.ReservMultiplier10.text != "")
                                                        {
                                                            RecalculationOnEndDrag(multiplier, multiplier.GetComponent<AddBeginDrag>().Original.transform.parent.gameObject);
                                                        }
                                                        else
                                                        {
                                                            LevelGenerator.ReservMultiplier10.SetText($"{multiplier.GetComponent<TextMeshProUGUI>().text}");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        LevelGenerator.ReservMultiplier9.SetText($"{multiplier.GetComponent<TextMeshProUGUI>().text}");
                                                    }
                                                }
                                                else
                                                {
                                                    LevelGenerator.ReservMultiplier8.SetText($"{multiplier.GetComponent<TextMeshProUGUI>().text}");
                                                }
                                            }
                                            else
                                            {
                                                LevelGenerator.ReservMultiplier7.SetText($"{multiplier.GetComponent<TextMeshProUGUI>().text}");
                                            }
                                        }
                                        else
                                        {
                                            LevelGenerator.ReservMultiplier6.SetText($"{multiplier.GetComponent<TextMeshProUGUI>().text}");
                                        }
                                    }
                                    else
                                    {
                                        LevelGenerator.ReservMultiplier5.SetText($"{multiplier.GetComponent<TextMeshProUGUI>().text}");
                                    }
                                }
                                else
                                {
                                    LevelGenerator.ReservMultiplier4.SetText($"{multiplier.GetComponent<TextMeshProUGUI>().text}");
                                }
                            }
                            else
                            {
                                LevelGenerator.ReservMultiplier3.SetText($"{multiplier.GetComponent<TextMeshProUGUI>().text}");
                            }
                        }
                        else
                        {
                            LevelGenerator.ReservMultiplier2.SetText($"{multiplier.GetComponent<TextMeshProUGUI>().text}");
                        }
                    }
                    else
                    {
                        LevelGenerator.ReservMultiplier1.SetText($"{multiplier.GetComponent<TextMeshProUGUI>().text}");
                    }
                    multiplier.GetComponent<TextMeshProUGUI>().SetText("");
                    multiplier.transform.position = multiplier.GetComponent<AddBeginDrag>().Original.transform.position;
                    break;
                case "Back":
                    RecalculationOnEndDrag(multiplier, multiplier.GetComponent<AddBeginDrag>().Original.transform.parent.gameObject);
                    break;
            }

            //сейв
        }

        private void RecalculationOnBeginDrag(GameObject multiplier)
        {
            switch (multiplier.name)
            {
                case "Multiplier6 (1)":
                    LevelGenerator.FirstMultiplication56.SetActive(false);
                    break;
                default:
                    Movement.MovementOnLine(multiplier);
                    break;
            }
            Recalculation(multiplier.GetComponent<AddBeginDrag>().Original.transform.parent.name);
        }

        private void Recalculation(string panelName)
        {
            switch (panelName)
            {
                case "FirstPlaneClones":
                    int firstComposition = 1;
                    if (LevelGenerator.FirstMultiplier1.text != "")
                    {
                        firstComposition *= Int32.Parse(LevelGenerator.FirstMultiplier1.text);
                        if (LevelGenerator.FirstMultiplier2.text != "")
                        {
                            firstComposition *= Int32.Parse(LevelGenerator.FirstMultiplier2.text);
                            if (LevelGenerator.FirstMultiplier3.text != "")
                            {
                                firstComposition *= Int32.Parse(LevelGenerator.FirstMultiplier3.text);
                                if (LevelGenerator.FirstMultiplier4.text != "")
                                {
                                    firstComposition *= Int32.Parse(LevelGenerator.FirstMultiplier4.text);
                                    if (LevelGenerator.FirstMultiplier5.text != "")
                                    {
                                        firstComposition *= Int32.Parse(LevelGenerator.FirstMultiplier5.text);
                                        if (LevelGenerator.FirstMultiplier6.text != "")
                                        {
                                            firstComposition *= Int32.Parse(LevelGenerator.FirstMultiplier6.text);
                                        }
                                    }
                                }
                            }
                        }
                        LevelGenerator.FirstCompositionLeft.SetText($"{firstComposition}");
                        //сверить лево и право
                    }                    
                    else
                    {
                        LevelGenerator.FirstCompositionLeft.SetText("");
                    }
                    break;
                case "SecondPlaneClones":
                    int secondComposition = 1;
                    if (LevelGenerator.SecondMultiplier1.text != "")
                    {
                        secondComposition *= Int32.Parse(LevelGenerator.SecondMultiplier1.text);
                        if (LevelGenerator.SecondMultiplier2.text != "")
                        {
                            secondComposition *= Int32.Parse(LevelGenerator.SecondMultiplier2.text);
                            if (LevelGenerator.SecondMultiplier3.text != "")
                            {
                                secondComposition *= Int32.Parse(LevelGenerator.SecondMultiplier3.text);
                                if (LevelGenerator.SecondMultiplier4.text != "")
                                {
                                    secondComposition *= Int32.Parse(LevelGenerator.SecondMultiplier4.text);
                                    if (LevelGenerator.SecondMultiplier5.text != "")
                                    {
                                        secondComposition *= Int32.Parse(LevelGenerator.SecondMultiplier5.text);
                                        if (LevelGenerator.SecondMultiplier6.text != "")
                                        {
                                            secondComposition *= Int32.Parse(LevelGenerator.SecondMultiplier6.text);
                                        }
                                    }
                                }
                            }
                        }
                        LevelGenerator.SecondCompositionLeft.SetText($"{secondComposition}");
                        //сверить лево и право
                    }
                    else
                    {
                        LevelGenerator.SecondCompositionLeft.SetText("");
                    }
                    break;
                case "ThirdPlaneClones":
                    int thirdComposition = 1;
                    if (LevelGenerator.ThirdMultiplier1.text != "")
                    {
                        thirdComposition *= Int32.Parse(LevelGenerator.ThirdMultiplier1.text);
                        if (LevelGenerator.ThirdMultiplier2.text != "")
                        {
                            thirdComposition *= Int32.Parse(LevelGenerator.ThirdMultiplier2.text);
                            if (LevelGenerator.ThirdMultiplier3.text != "")
                            {
                                thirdComposition *= Int32.Parse(LevelGenerator.ThirdMultiplier3.text);
                                if (LevelGenerator.ThirdMultiplier4.text != "")
                                {
                                    thirdComposition *= Int32.Parse(LevelGenerator.ThirdMultiplier4.text);
                                    if (LevelGenerator.ThirdMultiplier5.text != "")
                                    {
                                        thirdComposition *= Int32.Parse(LevelGenerator.ThirdMultiplier5.text);
                                        if (LevelGenerator.ThirdMultiplier6.text != "")
                                        {
                                            thirdComposition *= Int32.Parse(LevelGenerator.ThirdMultiplier6.text);
                                        }
                                    }
                                }
                            }
                        }
                        LevelGenerator.ThirdCompositionLeft.SetText($"{thirdComposition}");
                        //сверить лево и право
                    }
                    else
                    {
                        LevelGenerator.ThirdCompositionLeft.SetText("");
                    }
                    break;
            }
        }
    }
}