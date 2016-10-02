using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _03.GenericList;

[Version(0, 4152647)]
public class GenericList<T> : IGenericList<T>, IEnumerable<T>
{
    private const int ListInitialCapacity = 16;

    private T[] internalStorage;

    private int capacity;
    private int currentIndex;

    public GenericList(int capacity = ListInitialCapacity)
    {
        this.Capacity = capacity;
        this.internalStorage = new T[this.Capacity];
        this.currentIndex = 0;
    }

    public int Capacity
    {
        get
        {
            return this.capacity;
        }

        private set
        {
            if (value <= 0)
            {
                value = ListInitialCapacity;
            }

            this.capacity = value;
        }
    }

    public int Size
    {
        get
        {
            return this.currentIndex;
        }
    }

    public void Add(T item)
    {
        if (this.currentIndex >= this.Capacity)
        {
            this.IncreaseCapacity();
        }

        this.internalStorage[this.currentIndex] = item;
        this.currentIndex++;
    }

    public void Insert(int index, T item)
    {
        if (this.currentIndex == index)
        {
            this.Add(item);
            return;
        }

        this.ValidateIndex(index);

        if (this.currentIndex >= this.Capacity - 1)
        {
            this.IncreaseCapacity();
        }

        for (int i = this.currentIndex; i > index; i--)
        {
            this.internalStorage[i] = this.internalStorage[i - 1];
        }

        this.internalStorage[index] = item;
        this.currentIndex++;
    }

    public void RemoveAt(int index)
    {
        this.ValidateIndex(index);
        for (var i = index; i < this.currentIndex; i++)
        {
            this.internalStorage[i] = this.internalStorage[i + 1];
        }

        this.currentIndex--;
        this.internalStorage[this.currentIndex] = default(T);
    }

    public void AddRange(params T[] items)
    {
        foreach (var item in items)
        {
            this.Add(item);
        }
    }

    public void Clear()
    {
        for (var i = 0; i < this.currentIndex; i++)
        {
            this.internalStorage[i] = default(T);
        }

        this.currentIndex = 0;
    }

    public int GetIndex(T item)
    {
        for (var i = 0; i < this.currentIndex; i++)
        {
            if (this.internalStorage[i].Equals(item))
            {
                return i;
            }
        }

        return -1;
    }

    public bool Contains(T item)
    {
        for (var i = 0; i < this.currentIndex; i++)
        {
            if (this.internalStorage[i].Equals(item))
            {
                return true;
            }
        }

        return false;
    }

    public T this[int index]
    {
        get
        {
            this.ValidateIndex(index);
            return this.internalStorage[index];
        }

        set
        {
            this.ValidateIndex(index);
            this.internalStorage[index] = value;
        }
    }

    public override string ToString()
    {
        return
            this.currentIndex == 0
            ? $"Empty GenericList<{typeof(T)}>"
            : $"[{string.Join(", ", this.internalStorage.Take(this.currentIndex))}]";
    }

    public string Version()
    {
        var versionNum = string.Empty;
        var type = typeof(GenericList<T>);
        var allAttributes = type.GetCustomAttributes(false);
        foreach (var attr in allAttributes)
        {
            var attribute = attr as VersionAttribute;
            if (attribute != null)
            {
                var version = attribute;
                versionNum = $"GenericList<T> version {version.Major}.{version.Minor}";
            }
        }

        return versionNum;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (var i = 0; i < this.currentIndex; i++)
        {
            yield return this.internalStorage[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private void IncreaseCapacity()
    {
        this.capacity = this.internalStorage.Length * 2;
        var newInternalStorage = new T[this.capacity];
        for (var i = 0; i < this.internalStorage.Length; i++)
        {
            newInternalStorage[i] = this.internalStorage[i];
        }

        this.internalStorage = newInternalStorage;
    }

    private void ValidateIndex(int index)
    {
        if (index >= this.currentIndex || index < 0)
        {
            throw new ArgumentOutOfRangeException();
        }
    }
}