using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintainAspectRatio : MonoBehaviour
{
    // Oraný korumak istediðiniz geniþlik ve yükseklik oraný
    private float targetAspect = 16.0f / 9.0f;

    void Start()
    {
        AdjustCamera();
    }

    void Update()
    {
        AdjustCamera();
    }

    void AdjustCamera()
    {
        // Mevcut pencere boyutlarý
        float windowAspect = (float)Screen.width / (float)Screen.height;

        // Oraný korumak için scale faktörü
        float scaleHeight = windowAspect / targetAspect;

        Camera camera = GetComponent<Camera>();

        // Eðer pencere oraný hedef oranýndan küçükse
        if (scaleHeight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            camera.rect = rect;
        }
        else // Eðer pencere oraný hedef oranýndan büyükse
        {
            float scaleWidth = 1.0f / scaleHeight;

            Rect rect = camera.rect;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
    }
}
