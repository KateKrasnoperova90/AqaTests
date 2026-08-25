using FluentAssertions;
using FluentAssertions.Execution;
using AqaTest.DTO.OrderDataDTO;
using System.Text.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace AqaTest;

public class OrderJsonTests
{
    private OrderDTO order;

    [OneTimeSetUp]  
    public void Setup()
    {
       var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "OrderData.json");
       string json = File.ReadAllText(path);

       order = JsonSerializer.Deserialize<OrderDTO>(json);
    }

    [Test]
    public void Test1CheckOrder()
    {
        foreach (var item in order.Items)
        {
           TestContext.WriteLine($"{item.ProductId} | {item.Name} | {item.Category} | {item.Price.ToString()} | {item.Quantity.ToString()}");
        }

        order.Items.Should().NotBeNull();
        order.Items.Should().HaveCount(3);
    }

    [Test]
    public void Test2CheckSumOfItems()
    {
        var sum = order.Items.Select(item => item.Price * item.Quantity).Sum();
        TestContext.WriteLine($"Sum of items: {sum}");
        sum.Should().Be(order.Summary.ItemsTotal);
    }

    [Test]
    public void Test3CheckItemsElectronics()
    {
        var electronicsItems = order.Items.Where(item => item.Category == "Electronics").ToList();
        TestContext.WriteLine($"Electronics items count: {electronicsItems.Count}");

        using (new AssertionScope())
        {
            electronicsItems.Should().OnlyContain(item => item.Category == "Electronics");
            electronicsItems.Should().HaveCount(2);
        }
    }
}


