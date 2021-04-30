using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class TestSuite
{
    private GameManager gameManager;
    private ResourceManager resourceManager;
    private StatsManager statsManager;
    private InterfaceManager interfaceManager;

    //Unfinished
    [SetUp]
    public void Setup()
    {
        GameObject gameManagerGameObject = new GameObject();
        gameManagerGameObject.AddComponent<GameManager>();
        gameManagerGameObject.AddComponent<ResourceManager>();
        gameManagerGameObject.AddComponent<StatsManager>();
        gameManagerGameObject.AddComponent<InterfaceManager>();

        gameManager = gameManagerGameObject.GetComponent<GameManager>();
        resourceManager = gameManagerGameObject.GetComponent<ResourceManager>();
        statsManager = gameManagerGameObject.GetComponent<StatsManager>();
        interfaceManager = gameManagerGameObject.GetComponent<InterfaceManager>();
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(gameManager.gameObject);
        Object.Destroy(resourceManager.gameObject);
        Object.Destroy(statsManager.gameObject);
        Object.Destroy(interfaceManager.gameObject);
    }
    [UnityTest]
    public IEnumerator TestScenarioPopulationCount()
    {
        resourceManager.populateScenarios();

        Assert.Equals(resourceManager.GetScenarios().Count, 6);

        yield return null;
    }

}