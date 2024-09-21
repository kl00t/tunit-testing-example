namespace ExampleLibrary.Tests;

public class ExampleTests
{
    private Example _example;

    [Before(Test)]
    public void BeforeHook(TestContext context)
    {
        Console.WriteLine("BeforeHook");
        _example = new Example();
    }

    [Before(Class)]
    public static void BeforeClass(ClassHookContext context)
    {
        Console.WriteLine("BeforeClass");
    }

    [Test]
    [Retry(3)]
    public async Task ExampleTest1()
    {
        var sum = _example.Add(6, 9);

        await Assert.That(sum).IsEqualTo(15);
    }

    [Test]
    [DependsOn(nameof(ExampleTest1))]
    public async Task ExampleTest2()
    {
        var sum = _example.Add(1, 1);

        await Assert.That(sum).IsEqualTo(2);
    }
}
