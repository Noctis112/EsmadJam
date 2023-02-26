using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWritter : MonoBehaviour
{
    // The Text UI element to apply the typewriter effect to
    [SerializeField] TextMeshProUGUI Text;

    // The speed at which to display each character
    [SerializeField] float typingSpeed = 0.05f;

    // The text to display with the typewriter effect
    string displayText;

    // The coroutine that handles the typewriter effect
    private Coroutine typingCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        // Set the text to an empty string initially
        Text.text = "";

        displayText = "Hey, dear workers!" + "\n" + "" + "\n" + "As you all know, our company has managed to achieve great results over the past few months. However, I believe there is always room for improvement : )" +
    "\n" + "That’s why I have established new rules to prioritize our company’s progress." + "\n" + "1.    Breaks between work are STRICTLY prohibited" + "\n" + "2.    Work time will change from 8 to 14 hours daily (you can sleep here if you want!)" +
    "\n" + "3.    No more subsidy or extra-hours bonus (don’t worry, totally legal)" + "\n" + "All these are necessary to our success, so we can grow together!" + "\n" +
    "And never forget: we can always hire someone else for your job!" + "\n" + "" + "\n" + "Yours trully," + "\n" + "Liam Turd";

        // Start the coroutine to display the text with the typewriter effect
        typingCoroutine = StartCoroutine(TypeText());


    }

    // Update is called once per frame
    void Update()
    {
        // Check if the coroutine has finished and the full text has been displayed
        if (typingCoroutine != null && Text.text == displayText)
        {
            // Stop the coroutine so it doesn't keep running unnecessarily
            StopCoroutine(typingCoroutine);

            // Set the coroutine reference to null so it can be restarted if necessary
            typingCoroutine = null;
        }
    }

    // Coroutine that displays the text with a typewriter effect
    IEnumerator TypeText()
    {
        // Iterate through each character in the displayText string
        for (int i = 0; i < displayText.Length; i++)
        {
            // Add the current character to the text element
            Text.text += displayText[i];

            // Wait for a short period of time before displaying the next character
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
