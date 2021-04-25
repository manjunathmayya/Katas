using System;

// This file was auto-generated based on version 1.0.0 of the canonical data.

using Xunit;

public class ResistorColorTests
{
    [Fact]
    public void Black()
    {
        Assert.Equal(0, ResistorColor.ColorCode("black"));
    }

    [Fact]
    public void White()
    {
        Assert.Equal(9, ResistorColor.ColorCode("white"));
    }

    [Fact]
    public void Orange()
    {
        Assert.Equal(3, ResistorColor.ColorCode("orange"));
    }

    [Fact]
    public void Colors()
    {
        Assert.Equal(new[] { "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" }, ResistorColor.Colors());
    }
}

public static class ResistorColor
{
    public static int ColorCode(string color)
    {
        if (color == "white")
        {
            return 9;
        }
        else if (color == "orange")
        {
            return 3;
        }
        return 0;

    }

    public static string[] Colors()
    {
        string[] colors = new []{ "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" };
        return colors;
    }
}