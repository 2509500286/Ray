﻿using Orleans;
using Ray.Core;

namespace Ray.IGrains.Actors
{
    public interface IAccountDb : IConcurrentFollow, IGrainWithIntegerKey
    {
    }
}
