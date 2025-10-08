using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using KFCMenu.Services;
using KFCMenu.Models;

namespace KFCMenu.Tests;
[TestFixture]
public class JsonServicesDataTests
{

    [Test]
    public void ReturnEmptyList()
    {
        var path = "Data/data.json";
        MainTest(new List<Dish>(), path);
    }

    public void MainTest(List<Dish> expectedDish, string path)
    {
        var jsonData = new JsonDataService(path);
        var realDishes = jsonData.LoadAsync().Result;
        ClassicAssert.AreEqual(expectedDish, realDishes);
    }
}

