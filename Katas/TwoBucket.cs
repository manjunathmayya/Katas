using System;
using System.Collections.Generic;
using Xunit;

namespace Katas
{
    public class TwoBucketTests
    {
        [Fact]
        public void Measure_using_bucket_one_of_size_3_and_bucket_two_of_size_5_start_with_bucket_one()
        {
            var sut = new TwoBucket(3, 5, Bucket.One);
            var actual = sut.Measure(1);
            Assert.Equal(4, actual.Moves);
            Assert.Equal(5, actual.OtherBucket);
            Assert.Equal(Bucket.One, actual.GoalBucket);
        }

        [Fact]
        public void Measure_using_bucket_one_of_size_3_and_bucket_two_of_size_5_start_with_bucket_two()
        {
            var sut = new TwoBucket(3, 5, Bucket.Two);
            var actual = sut.Measure(1);
            Assert.Equal(8, actual.Moves);
            Assert.Equal(3, actual.OtherBucket);
            Assert.Equal(Bucket.Two, actual.GoalBucket);
        }

        [Fact]
        public void Measure_using_bucket_one_of_size_7_and_bucket_two_of_size_11_start_with_bucket_one()
        {
            var sut = new TwoBucket(7, 11, Bucket.One);
            var actual = sut.Measure(2);
            Assert.Equal(14, actual.Moves);
            Assert.Equal(11, actual.OtherBucket);
            Assert.Equal(Bucket.One, actual.GoalBucket);
        }

        [Fact]
        public void Measure_using_bucket_one_of_size_7_and_bucket_two_of_size_11_start_with_bucket_two()
        {
            var sut = new TwoBucket(7, 11, Bucket.Two);
            var actual = sut.Measure(2);
            Assert.Equal(18, actual.Moves);
            Assert.Equal(7, actual.OtherBucket);
            Assert.Equal(Bucket.Two, actual.GoalBucket);
        }

        [Fact]
        public void Measure_one_step_using_bucket_one_of_size_1_and_bucket_two_of_size_3_start_with_bucket_two()
        {
            var sut = new TwoBucket(1, 3, Bucket.Two);
            var actual = sut.Measure(3);
            Assert.Equal(1, actual.Moves);
            Assert.Equal(0, actual.OtherBucket);
            Assert.Equal(Bucket.Two, actual.GoalBucket);
        }

        [Fact]
        public void Measure_using_bucket_one_of_size_2_and_bucket_two_of_size_3_start_with_bucket_one_and_end_with_bucket_two()
        {
            var sut = new TwoBucket(2, 3, Bucket.One);
            var actual = sut.Measure(3);
            Assert.Equal(2, actual.Moves);
            Assert.Equal(2, actual.OtherBucket);
            Assert.Equal(Bucket.Two, actual.GoalBucket);
        }
    }

    public enum Bucket
    {
        One,
        Two,
        None
    }

    public class TwoBucketResult
    {
        public TwoBucketResult(int moves, Bucket goalBucket, int otherBucket)
        {
            Moves = moves;
            GoalBucket = goalBucket;
            OtherBucket = otherBucket;
        }

        public int Moves { get; }

        public Bucket GoalBucket { get; }

        public int OtherBucket { get; }
    }

    public class Move
    {
        public Move(int bucket1, int bucket2)
        {
            Bucket1Value = bucket1;
            Bucket2Value = bucket2;
        }
        public int Bucket1Value;
        public int Bucket2Value;
    }

    public class Moves
    {
        private List<Move> moveList = new List<Move>();

        public void Add(int bucket1, int bucket2)
        {
            moveList.Add(new Move(bucket1, bucket2));
        }

        public Bucket GetGoalBucket(int goal)
        {
            if (moveList.Count > 0)
            {
                if (moveList[moveList.Count - 1].Bucket1Value == goal)
                    return Bucket.One;

                if (moveList[moveList.Count - 1].Bucket2Value == goal)
                    return Bucket.Two;
            }

            return Bucket.None;
        }
        public int Count()
        {
            return moveList.Count;
        }

        public int GetBucketValueFromLastMove(Bucket bucket)
        {
            if (bucket == Bucket.One)
                return moveList[moveList.Count - 1].Bucket1Value;

            return moveList[moveList.Count - 1].Bucket2Value;
        }
    }

    public class TwoBucket
    {
        private int _bucketOneCapacity;
        private int _bucketTwoCapacity;

        private int _bucketOneCurrentValue;
        private int _bucketTwoCurrentValue;

        private Bucket _startBucket;

        public TwoBucket(int bucketOneCapacity, int bucketTwoCapacity, Bucket startBucket)
        {
            _bucketOneCapacity = bucketOneCapacity;
            _bucketTwoCapacity = bucketTwoCapacity;
            _startBucket = startBucket;
        }


        public TwoBucketResult Measure(int goal)
        {
            Moves moves = new Moves();

            //Repeat until goal value is reached in any one of the buckets.
            while (moves.GetGoalBucket(goal) == Bucket.None)
            {
                if (_startBucket == Bucket.One)
                {
                    CalculateBucketValuesForCurrentMove(goal, ref _bucketOneCurrentValue, ref _bucketTwoCurrentValue,
                        _bucketOneCapacity, _bucketTwoCapacity);
                }
                else
                {
                    CalculateBucketValuesForCurrentMove(goal, ref _bucketTwoCurrentValue, ref _bucketOneCurrentValue,
                        _bucketTwoCapacity, _bucketOneCapacity);
                }
                moves.Add(_bucketOneCurrentValue, _bucketTwoCurrentValue);
            }

            Bucket otherBucket = moves.GetGoalBucket(goal) == Bucket.One ? Bucket.Two : Bucket.One;
            return new TwoBucketResult(moves.Count(), moves.GetGoalBucket(goal), moves.GetBucketValueFromLastMove(otherBucket));
        }

        private void CalculateBucketValuesForCurrentMove(int goal, ref int startBucketCurrentValue, ref int otherBucketCurrentValue, int startBucketCapacity, int otherBucketCapacity)
        {
            if (AreBothBucketsEmpty(startBucketCurrentValue, otherBucketCurrentValue))
            {
                startBucketCurrentValue = startBucketCapacity;
                otherBucketCurrentValue = 0;
            }
            else
            {
                if (otherBucketCurrentValue == 0)
                {
                    if (goal == otherBucketCapacity)
                    {
                        otherBucketCurrentValue = otherBucketCapacity;
                    }
                    else
                    {
                        if (startBucketCurrentValue > 0)
                        {
                            if (startBucketCurrentValue >= otherBucketCapacity)
                            {
                                startBucketCurrentValue = startBucketCurrentValue - otherBucketCapacity;
                                otherBucketCurrentValue = otherBucketCapacity;
                            }
                            else
                            {
                                otherBucketCurrentValue = startBucketCurrentValue;
                                startBucketCurrentValue = 0;
                            }
                        }
                    }
                }
                else if (startBucketCurrentValue == 0)
                {
                    startBucketCurrentValue = startBucketCapacity;
                }
                else
                {
                    if (otherBucketCurrentValue == otherBucketCapacity)
                    {
                        otherBucketCurrentValue = 0;
                    }
                    else
                    {
                        int val = otherBucketCapacity - otherBucketCurrentValue - startBucketCurrentValue;

                        if (val < 0)
                        {
                            otherBucketCurrentValue = otherBucketCapacity;
                        }
                        else
                        {
                            otherBucketCurrentValue += startBucketCurrentValue;
                        }

                        startBucketCurrentValue = (val > 0 ? 0 : val * (-1));
                    }
                }
            }
        }

        private static bool AreBothBucketsEmpty(int startBucketCurrentValue, int otherBucketCurrentValue)
        {
            return startBucketCurrentValue == 0 && otherBucketCurrentValue == 0;
        }
    }
}
