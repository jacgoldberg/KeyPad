using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    public KeypadBackground Background;
    private List<int> buttonsEntered;
    private Combination combination;
    
    void Start()
    {
        combination = new Combination();
        ResetButtonEntrys();

    }
    public void RegisterButtonClick(int buttonValue)
    {
        buttonsEntered.Add(buttonValue);
        print(String.Join(", ", buttonsEntered));
    }

    public void TryToUnlock()
    {
        if (IsCorrectCombination())
            Unlock();
        else
        {
            FailToUnlock();
        }
        ResetButtonEntrys();
    }

    private void ResetButtonEntrys()
    {
        buttonsEntered = new List<int>();
    }

    private bool IsCorrectCombination()
    {
        if(HaveNoButtonsBeenClicked())
            return false;
        if (HaveWrongNumberOfButtons())
            return false;
        return CheckCombination();

    }

    private bool HaveWrongNumberOfButtons()
    {
        if (buttonsEntered.Count == combination.GetCombinationLength())
            return false;
        return true;
    }


    private bool HaveNoButtonsBeenClicked()
    {
        if(buttonsEntered.Count == 0)
            return true;
        return false;
    }

    private bool CheckCombination()
    {
        for(int i = 0; i < buttonsEntered.Count; i++)
        {
            if (IsCorrectButton(i) == false)
                return false;
        }
        return true;
    }
    private bool IsCorrectButton(int i)
    {
        if (isWrongEntry(i))
            return false;
        return true;
    }
    private bool isWrongEntry(int i)
    {
        if (buttonsEntered[i] == combination.GetCombinationDigit(i))
            return false;
        return true;
    }

    private IEnumerator ResetBackgroundColor()
    {
        yield return new WaitForSeconds(0.25f);

        Background.ChangeToDefaultColor();
    }
    private void Unlock()
    {
        Background.HideUnlockButton();
        Background.ChangeToSuccessColor();
    }
    private void FailToUnlock()
    {
        Background.ChangeToFailedColor();
        StartCoroutine(ResetBackgroundColor());
    }

}
