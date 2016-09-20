using UnityEngine;
using System.Collections;

public class DustRemover : MonoBehaviour
{
    public float fadeDelay = 0.1f;

    SpriteRenderer sr;
    WaitForSeconds m_waitforseconds;

    bool m_interacted = false;

    void OnMouseEnter ()
    {
        if (!m_interacted)
        {
            Debug.Log("Mouse enter dust");
            m_interacted = true;
            DustInitialize.DirtNumber();
            Destroy(gameObject);
        }
    }

    void Start ()
    {
        sr = GetComponent<SpriteRenderer>();
        m_waitforseconds = new WaitForSeconds(fadeDelay);
        StartCoroutine(FadeDust());
    }

    IEnumerator FadeDust()
    {
        yield return m_waitforseconds;

        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            sr.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }
}
