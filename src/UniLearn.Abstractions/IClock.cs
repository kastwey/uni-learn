using System;

namespace UniLearn.Abstractions;

public interface IClock
{
    DateTime Now();
}