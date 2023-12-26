using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MoveTest
{
    [Test]
    public void MoveTestSimplePasses()
    {
            GameObject playerObject = new GameObject();
            PlayerController playerController = playerObject.AddComponent<PlayerController>();
            Rigidbody2D rb = playerObject.AddComponent<Rigidbody2D>();
            Animator animator = playerObject.AddComponent<Animator>();

            playerController.speed = 8;
            playerController.animator = animator;

            playerController.Start();
            playerController.Update();
            playerController.FixedUpdate();

            Assert.AreEqual(playerController.rb, rb);
            Assert.IsNotNull(playerController.animator);
            Assert.AreEqual(playerController.speed, 8f);
    }
}
