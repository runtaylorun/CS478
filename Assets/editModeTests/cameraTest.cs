using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class cameraTest
{
    [Test]
    public void CameraIsInCorrectPosition()
    {
        Assert.AreEqual(new Vector3(0, 0, -10), Camera.main.transform.position);
    }

    [Test]
    public void CameraHasCorrectScale()
    {
        Assert.AreEqual(new Vector3(1, 1, 3), Camera.main.transform.localScale);
    }

    [Test]
    public void CameraIsOrthographic()
    {
        Assert.AreEqual(true, Camera.main.orthographic);
    }
}
