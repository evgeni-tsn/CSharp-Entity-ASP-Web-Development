using System;

[AttributeUsage(AttributeTargets.Struct
    | AttributeTargets.Class
    | AttributeTargets.Interface
    | AttributeTargets.Enum
    | AttributeTargets.Method)]
public class VersionAttribute : Attribute
{
    private const string CanBeNegative = "{0} number should be positive or 0";

    private int major;
    private int minor;

    public VersionAttribute(int major, int minor)
    {
        this.Major = major;
        this.Minor = minor;
    }

    public int Major
    {
        get
        {
            return this.major;
        }

        private set
        {
            IsNotNegative(value, "Major");
            this.major = value;
        }
    }

    public int Minor
    {
        get
        {
            return this.minor;
        }

        private set
        {
            IsNotNegative(value, "Minor");
            this.minor = value;
        }
    }

    private static void IsNotNegative(int value, string title)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(
                title,
                string.Format(CanBeNegative, title));
        }
    }

}