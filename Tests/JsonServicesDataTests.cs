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
        var jsonTest = new JsonDataService();

    }

    public void MainTest(List<Dish> expectedDishes, List<Dish> realDishes)
    {
        var filePath = "";
    }
}

