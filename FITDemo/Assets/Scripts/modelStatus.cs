using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum Status
{
    merged,
    split,
    single
};
public class modelStatus
{
    internal static Status status = Status.merged;
}
