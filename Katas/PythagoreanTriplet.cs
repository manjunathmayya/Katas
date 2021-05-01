using System;
using System.Collections.Generic;
using Xunit;

public class PythagoreanTripletTests
{
    [Fact]
    public void Triplets_whose_sum_is_12()
    {
        Tuple<int, int, int>[] temp = new[] { new Tuple<int, int, int>(3, 4, 5) };

        Assert.Equal(temp, PythagoreanTriplet.TripletsWithSum(12));
    }

    [Fact]
    public void Triplets_whose_sum_is_108()
    {
        Assert.Equal(new[] { new Tuple<int, int, int>(27, 36, 45) }, PythagoreanTriplet.TripletsWithSum(108));
    }

    [Fact]
    public void Triplets_whose_sum_is_1000()
    {
        Assert.Equal(new[] { new Tuple<int, int, int>(200, 375, 425)}, PythagoreanTriplet.TripletsWithSum(1000));
    }

    [Fact]
    public void No_matching_triplets_for_1001()
    {
        Tuple<int, int, int>[] temp = new Tuple<int, int, int>[0];
        Assert.Equal( temp, PythagoreanTriplet.TripletsWithSum(1001));
    }

    [Fact]
    public void Returns_all_matching_triplets()
    {
        Assert.Equal(new[] {
                new Tuple<int, int, int>(9, 40, 41),
                new Tuple<int, int, int>(15, 36, 39)
            }, PythagoreanTriplet.TripletsWithSum(90));
        }

    [Fact]
    public void Several_matching_triplets()
    {
        Assert.Equal(new[]
        {
                new Tuple<int, int, int>(40, 399, 401),
                new Tuple<int, int, int>(56, 390, 394),
                new Tuple<int, int, int>(105, 360, 375),
                new Tuple<int, int, int>(120, 350, 370),
                new Tuple<int, int, int>(140, 336, 364),
                new Tuple<int, int, int>(168, 315, 357),
                new Tuple<int, int, int>(210, 280, 350),
                new Tuple<int, int, int>(240, 252, 348)
            }, PythagoreanTriplet.TripletsWithSum(840));
        }

    [Fact]
    public void Triplets_for_large_number()
    {
        Assert.Equal(new[]
        {
                new Tuple<int, int, int>(1200, 14375, 14425),
                new Tuple<int, int, int>(1875, 14000, 14125),
                new Tuple<int, int, int>(5000, 12000, 13000),
                new Tuple<int, int, int>(6000, 11250, 12750),
                new Tuple<int, int, int>(7500, 10000, 12500)
            }, PythagoreanTriplet.TripletsWithSum(30000));
        }
}

public static class PythagoreanTriplet
{
    public static IEnumerable<Tuple<int, int, int>> TripletsWithSum(int sum)
    {
        List<Tuple<int, int, int>> list = new List<Tuple<int, int, int>>();

        for (int a = 1; a <= sum / 3; a++)
        {
            for (int b = 1; b <= sum / 2; b++)
            {
                int c = sum - a - b;

                if ((a + b + c == sum) && ((a * a + b * b) == c * c))
                {
                    bool alreadyExists = false;
                    foreach (var item in list)
                    {
                        if (item.Item1 == b && item.Item2 == a)
                        {
                            alreadyExists = true;
                            break;
                        }
                    }
                    if (!alreadyExists)
                        list.Add(new Tuple<int, int, int>(a, b, c));
                }
            }
        }

        return list;
    }


    //Another solution.
    //public static IEnumerable<Tuple<int,int,int>> TripletsWithSum(int sum)
    //{
    //    for (int a = 1; a < sum / 3; a++)
    //    {
    //        for (int b = a + 1, c = sum - a - b; b < c; b++, c = sum - a - b)
    //        {
    //            if ((a < b) && (b < c) && (a * a + b * b == c * c)) yield return new Tuple<int, int,int >(a, b, c);
    //        }
    //    }
    //}
}


