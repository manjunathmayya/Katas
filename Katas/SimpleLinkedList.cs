using System.Linq;
using Xunit;
using System;
using System.Collections;
using System.Collections.Generic;


public class SimpleLinkedListTests
{
    [Fact]
    public void Single_item_list_value()
    {
        var list = new SimpleLinkedList<int>(1);
        Assert.Equal(1, list.Value);
    }

    [Fact]
    public void Single_item_list_has_no_next_item()
    {
        var list = new SimpleLinkedList<int>(1);
        Assert.Null(list.Next);
    }

    [Fact]
    public void Two_item_list_first_value()
    {
        var list = new SimpleLinkedList<int>(2).Add(1);
        Assert.Equal(2, list.Value);
    }

    [Fact]
    public void Two_item_list_second_value()
    {
        var list = new SimpleLinkedList<int>(2).Add(1);
        Assert.Equal(1, list.Next.Value);
    }

    [Fact]
    public void Two_item_list_second_item_has_no_next()
    {
        var list = new SimpleLinkedList<int>(2).Add(1);
        Assert.Null(list.Next.Next);
    }

    [Fact]
    public void Implements_enumerable()
    {
        var values = new SimpleLinkedList<int>(2).Add(1);
        Assert.Equal(new[] { 2, 1 }, values);
    }

    [Fact]
    public void From_enumerable()
    {
        var list = new SimpleLinkedList<int>(new[] { 11, 7, 5, 3, 2 });
        Assert.Equal(11, list.Value);
        Assert.Equal(7, list.Next.Value);
        Assert.Equal(5, list.Next.Next.Value);
        Assert.Equal(3, list.Next.Next.Next.Value);
        Assert.Equal(2, list.Next.Next.Next.Next.Value);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(10)]
    [InlineData(100)]
    public void Reverse(int length)
    {
        var values = Enumerable.Range(1, length).ToArray();
        var list = new SimpleLinkedList<int>(values);
        var reversed = list.Reverse();
        Assert.Equal(values.Reverse(), reversed);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(10)]
    [InlineData(100)]
    public void Roundtrip(int length)
    {
        var values = Enumerable.Range(1, length);
        var listValues = new SimpleLinkedList<int>(values);
        Assert.Equal(values, listValues);
    }
}


public class MyList<T> : IEnumerator<T>
{
    private List<T> list;
    int _position = -1;

    public MyList()
    {
        list = new List<T>();
    }
    public MyList(List<T> values)
    {
        list = new List<T>();
        list = values;
    }

    public void Add(T value)
    {
        list.Add(value);
    }

    public T Get(int index)
    {
        return list[index];
    }

    public bool MoveNext()
    {
        _position++;
        return (_position < list.Count);
    }

    public void Reset()
    {
        _position = -1;
    }

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }

    public T Current
    {
        get
        {
            try
            {
                return list[_position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }

    protected virtual void Dispose(bool disposing) { }

    public void Dispose() {}
}

public class SimpleLinkedList<T> : IEnumerable<T>
{
    private MyList<T> _list;
    private int _length;
    private int _nextIndex;

    private void ResetNextIndex()
    {
        _nextIndex = 0;
    }

    public SimpleLinkedList(T value)
    {
        ResetNextIndex();
        _list = new MyList<T>();

        _list.Add(value);
        _length = 1;
    }

    public SimpleLinkedList(IEnumerable<T> values)
    {
        ResetNextIndex();
        _list = new MyList<T>(values.ToList<T>());
        _length = values.Count();
       
    }

    public T Value
    {
        get
        {
            int index = _nextIndex;
            ResetNextIndex();
            return _list.Get(index);
        }
    }

    public SimpleLinkedList<T> Next
    {
        get
        {
            if (_length == 1)
            {
                return null;
            }
            else
            {
                _nextIndex++;
                if (_nextIndex < _length)
                    return this;
                else
                    return null;
            }
        }
    }

    public SimpleLinkedList<T> Add(T value)
    {
        _list.Add(value);
        _length++;
        return this;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _list;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator)GetEnumerator();
    }
}