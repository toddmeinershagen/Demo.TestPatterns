
using System;
using NUnit.Framework;

[TestFixture]
public class TestsWithAssumptions
{
    [Test]
    public void given_id_accurate_then_test_continues()
    {
        var id = GetId();
        Assume.That(id, Is.EqualTo(1));

        Console.WriteLine("We got to the end.");
    }

    [Test]
    public void given_id_is_inaccurate_then_test_does_not_continue_and_marked_inconclusive()
    {
        var id = GetId();
        Assume.That(id, Is.EqualTo(2));

        Console.WriteLine("We got to the end.");
    }

    private int GetId()
    {
        return 1;
    }
}